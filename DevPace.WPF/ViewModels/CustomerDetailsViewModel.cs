using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using DevPace.BusinessLogic.Dto.Customer;
using DevPace.BusinessLogic.Services.Interfaces;
using DevPace.WPF.Common;
using DevPace.WPF.Models.Customer;
using DevPace.WPF.ViewModels.Base;
using Microsoft.VisualStudio.Threading;
using DevPace.WPF.Commands;
using System.ComponentModel.DataAnnotations;

namespace DevPace.WPF.ViewModels
{
    public class CustomerDetailsViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        private DynamicParameters _dynamicParameters;

        private long? _id;

        private const int CompanyNameSize = 10;

        #region NameProperty

        private string? _name;

        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                CheckNameUnique().Forget();
            }
        }

        #endregion

        #region CompanyNameProperty

        private string? _companyName;

        public string? CompanyName
        {
            get => _companyName;
            set
            {
                _companyName = value;
                OnPropertyChanged(nameof(CompanyName));
            }
        }

        #endregion

        #region EmailProperty

        private string? _email;

        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        #endregion

        #region PhoneProperty

        private string? _phone;

        public string? Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        #endregion

        public string Error { get; }

        public bool IsNameUnique { get; set; } = true;

        public AsyncCommand<Window> SaveCustomerCommand { get; set; }

        public AsyncCommand<Window> DeleteCustomerCommand { get; set; }

        public CustomerDetailsViewModel(
            ICustomerService customerService,
            DynamicParameters dynamicParameters,
            IMapper mapper)
        {
            _customerService = customerService;
            _dynamicParameters = dynamicParameters;
            _mapper = mapper;

            SaveCustomerCommand = new AsyncCommand<Window>(SaveCustomer, CanSave);

            DeleteCustomerCommand = new AsyncCommand<Window>(DeleteCustomer, CanDelete);

            Initialize();
        }
        
        public string this[string columnName]
        {
            get
            {
                string error = "";
                switch (columnName)
                {
                    case nameof(Name):
                        IsNameValid(out error);
                        break;
                    case nameof(CompanyName):
                        IsCompanyNameValid(out error);
                        break;
                    case nameof(Email):
                        IsEmailValid(out error);
                        break;
                }

                return error;
            }
        }

        protected override void CanExecuteChanged()
        {
            SaveCustomerCommand.OnCanExecuteChanged();
            DeleteCustomerCommand.OnCanExecuteChanged();
        }

        private async Task Initialize()
        {
            var id = _dynamicParameters.GetItem<long?>("id");
            var customerDto = id.HasValue ? await _customerService.GetByIdAsync(id.Value) : null;
            CustomerModel? customer = _mapper.Map<CustomerModel>(customerDto);

            if (customer != null)
            {
                _id = customer.Id;
                Name = customer.Name;
                CompanyName = customer.CompanyName;
                Email = customer.Email;
                Phone = customer.Phone;
            }
        }

        private async Task CheckNameUnique()
        {
            IsNameUnique = await _customerService.CheckForUniqueName(_id, Name);
            OnPropertyChanged(nameof(Name));
        }

        private async Task SaveCustomer(Window window)
        {
            CustomerDto customer = new CustomerDto
            {
                Id = _id,
                Name = Name,
                CompanyName = CompanyName,
                Email = Email,
                Phone = Phone
            };

            await _customerService.SaveAsync(customer);

            window.Close();
        }

        private bool CanSave(Window window)
        {
            return IsNameValid(out _) && IsCompanyNameValid(out _) && IsEmailValid(out _);
        }

        private async Task DeleteCustomer(Window window)
        {
            if (_id is not null)
            {
                await _customerService.DeleteByIdAsync(_id.Value);

                window.Close();
            }
        }

        private bool CanDelete(Window window)
        {
            return _id is not null;
        }

        private bool IsNameValid(out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(Name))
            {
                error = "enter name";
                return false;
            }
            else if (!IsNameUnique)
            {
                error = "name is not unique";
                return false;
            }

            return true;
        }

        private bool IsCompanyNameValid(out string error)
        {
            error = "";
            if (CompanyName is not null && CompanyName.Length > CompanyNameSize)
            {
                error = "invalid size";
                return false;
            }

            return true;
        }

        private bool IsEmailValid(out string error)
        {
            error = "";
            if (Email is not null && !new EmailAddressAttribute().IsValid(Email))
            {
                error = "invalid email format";
                return false;
            }

            return true;
        }
    }
}
