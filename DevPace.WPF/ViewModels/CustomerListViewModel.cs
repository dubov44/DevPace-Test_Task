using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using DevPace.Shared.Enums;
using DevPace.WebApi.Client.HttpServices.Interfaces;
using DevPace.WebApi.Common.Models;
using DevPace.WPF.Commands;
using DevPace.WPF.Common;
using DevPace.WPF.Models.Customer;
using DevPace.WPF.ViewModels.Base;
using DevPace.WPF.Views;
using Microsoft.VisualStudio.Threading;

namespace DevPace.WPF.ViewModels
{
    public class CustomerListViewModel : ViewModelBase

    {
        private readonly IMapper _mapper;

        private readonly ICustomerHttpService _customerService;

        private DynamicParameters _dynamicParameters;

        private int _totalCustomers;

        #region Commands

        public Command<long?> OpenCustomerDetailsCommand { get; set; }

        public Command NextCommand { get; set; }

        public Command FirstCommand { get; set; }

        public Command LastCommand { get; set; }

        public Command PreviousCommand { get; set; }

        public Command SearchCommand { get; set; }

        #endregion

        #region CustomerListProperty

        private ObservableCollection<CustomerModel> _customerList;

        public ObservableCollection<CustomerModel> CustomerList
        {
            get => _customerList;
            set
            {
                _customerList = value;
                OnPropertyChanged(nameof(CustomerList));
            }
        }

        #endregion

        #region NameFilterProperty

        private string _nameFilter;

        public string NameFilter
        {
            get => _nameFilter;
            set
            {
                _nameFilter = value;
                OnPropertyChanged(nameof(NameFilter));
            }
        }

        #endregion

        #region CompanyNameFilterProperty

        private string _companyNameFilter;

        public string CompanyNameFilter
        {
            get => _companyNameFilter;
            set
            {
                _companyNameFilter = value;
                OnPropertyChanged(nameof(CompanyNameFilter));
            }
        }

        #endregion

        #region EmailFilterProperty

        private string _emailFilter;

        public string EmailFilter
        {
            get => _emailFilter;
            set
            {
                _emailFilter = value;
                OnPropertyChanged(nameof(EmailFilter));
            }
        }

        #endregion

        #region PhoneFilterProperty

        private string _phoneFilter;

        public string PhoneFilter
        {
            get => _phoneFilter;
            set
            {
                _phoneFilter = value;
                OnPropertyChanged(nameof(PhoneFilter));
            }
        }

        #endregion

        #region CurrentPageProperty

        private int _currentPage = 1;

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                UpdateEnableState();
            }
        }

        #endregion

        #region NumberOfPagesProperty

        private int _numberOfPages;

        public int NumberOfPages
        {
            get => _numberOfPages;
            set
            {
                _numberOfPages = value;
                OnPropertyChanged(nameof(NumberOfPages));
                UpdateEnableState();
            }
        }

        #endregion

        #region SelectedRecordProperty

        private int _selectedRecord = 10;

        public int SelectedRecord
        {
            get => _selectedRecord;
            set
            {
                _selectedRecord = value;
                OnPropertyChanged(nameof(SelectedRecord));
                FirstPage();
            }
        }

        #endregion

        #region IsFirstEnabledProperty

        private bool _isFirstEnabled;

        public bool IsFirstEnabled
        {
            get => _isFirstEnabled;
            set
            {
                _isFirstEnabled = value;
                OnPropertyChanged(nameof(IsFirstEnabled));
            }
        }

        #endregion

        #region IsPreviousEnabledProperty

        private bool _isPreviousEnabled;

        public bool IsPreviousEnabled
        {
            get => _isPreviousEnabled;
            set
            {
                _isPreviousEnabled = value;
                OnPropertyChanged(nameof(IsPreviousEnabled));
            }
        }

        #endregion

        #region IsNextEnabledProperty

        private bool _isNextEnabled;

        public bool IsNextEnabled
        {
            get => _isNextEnabled;
            set
            {
                _isNextEnabled = value;
                OnPropertyChanged(nameof(IsNextEnabled));
            }
        }

        #endregion

        #region IsLastEnabledProperty

        private bool _isLastEnabled;

        public bool IsLastEnabled
        {
            get => _isLastEnabled;
            set
            {
                _isLastEnabled = value;
                OnPropertyChanged(nameof(IsLastEnabled));
            }
        }

        #endregion

        #region SortFieldProperty

        private SortField _sortField = SortField.Name;

        public SortField SortField
        {
            get => _sortField;
            set
            {
                _sortField = value;
                OnPropertyChanged(nameof(SortField));
            }
        }

        #endregion

        #region AscendingProperty

        private bool _ascending = true;

        public bool Ascending
        {
            get => _ascending;
            set
            {
                _ascending = value;
                OnPropertyChanged(nameof(Ascending));
            }
        }

        #endregion

        public CustomerListViewModel(
            ICustomerHttpService customerService,
            DynamicParameters dynamicParameters,
            IMapper mapper)
        {
            _customerService = customerService;
            _dynamicParameters = dynamicParameters;
            _mapper = mapper;
            OpenCustomerDetailsCommand = new Command<long?>(OpenEditWindow);
            FirstCommand = new Command(FirstPage);
            LastCommand = new Command(LastPage);
            PreviousCommand = new Command(PreviousPage);
            NextCommand = new Command(NextPage);
            SearchCommand = new Command(Search);
            InitializeAsync().Forget();
        }

        private Task InitializeAsync()
        {
            return RefreshAsync();
        }

        private void OpenEditWindow(long? id)
        {
            _dynamicParameters["id"] = id;
            Window window = new CustomerDetailsView();
            window.Closed += (sender, args) =>
            {
                RefreshAsync().Forget();
            };
            window.Show();
        }

        private async Task RefreshAsync()
        {
            CustomerFiltered filter = new CustomerFiltered
            {
                Name = NameFilter,
                CompanyName = CompanyNameFilter,
                Email = EmailFilter,
                Phone = PhoneFilter,
                SortField = SortField,
                Ascending = Ascending,
                Skip = SelectedRecord * (CurrentPage - 1),
                Take = SelectedRecord
            };
            var customerList = await _customerService.GetCustomers(filter);
            _totalCustomers = customerList.Count;

            NumberOfPages = (int)Math.Ceiling((double)_totalCustomers / SelectedRecord);
            NumberOfPages = NumberOfPages == 0 ? 1 : NumberOfPages;

            CustomerList = new ObservableCollection<CustomerModel>(_mapper.Map<IEnumerable<CustomerModel>>(customerList.Customers));
        }

        private void UpdateEnableState()
        {
            IsFirstEnabled = CurrentPage > 1;
            IsPreviousEnabled = CurrentPage > 1;
            IsNextEnabled = CurrentPage < NumberOfPages;
            IsLastEnabled = CurrentPage < NumberOfPages;
        }

        private void PreviousPage()
        {
            CurrentPage--;
            RefreshAsync().Forget();
        }

        private void LastPage()
        {
            CurrentPage = NumberOfPages;
            RefreshAsync().Forget();
        }

        private void FirstPage()
        {
            CurrentPage = 1;
            RefreshAsync().Forget();
        }

        private void NextPage()
        {
            CurrentPage++;
            RefreshAsync().Forget();
        }

        private void Search()
        {
            RefreshAsync().Forget();
            FirstPage();
        }
    }
}
