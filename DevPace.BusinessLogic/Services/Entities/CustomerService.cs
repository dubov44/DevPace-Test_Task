using AutoMapper;
using DevPace.BusinessLogic.Dto.Customer;
using DevPace.BusinessLogic.Services.Interfaces;
using DevPace.Domain.Models;
using DevPace.Domain.Services;

namespace DevPace.BusinessLogic.Services.Entities
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IDataService<Customer> _dataService;
        private readonly ICustomerDataService _customerDataService;

        public CustomerService(
            IMapper mapper,
            IDataService<Customer> dataService,
            ICustomerDataService customerDataService)
        {
            _mapper = mapper;
            _dataService = dataService;
            _customerDataService = customerDataService;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _dataService.GetAllAsync();

            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<Tuple<IEnumerable<CustomerDto>, int>> GetAllFilteredAsync(CustomerFilteredDto filteredDto)
        {
            var customers = await _customerDataService.GetFilteredAsync(_mapper.Map<CustomerSearch>(filteredDto));

            return new Tuple<IEnumerable<CustomerDto>, int>(
                _mapper.Map<IEnumerable<CustomerDto>>(customers.Item1), customers.Item2);
        }

        public async Task<CustomerDto?> GetByIdAsync(long id)
        {
            var customer = await _dataService.GetByIdAsync(id);

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> SaveAsync(CustomerDto entity)
        {
            if (entity.Id is null)
            {
                return await CreateAsync(entity);
            }

            return await UpdateAsync(entity.Id.Value, entity);
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            return await _dataService.DeleteByIdAsync(id);
        }

        public async Task<bool> CheckForUniqueName(long? id, string name)
        {
            return await _customerDataService.CheckForUniqueName(id, name);
        }

        private async Task<CustomerDto> CreateAsync(CustomerDto entity)
        {
            var dbCustomer = _mapper.Map<Customer>(entity);
            var createdCustomer = await _dataService.CreateAsync(dbCustomer);

            return _mapper.Map<CustomerDto>(createdCustomer);
        }

        private async Task<CustomerDto> UpdateAsync(long id, CustomerDto entity)
        {
            var dbCustomer = _mapper.Map<Customer>(entity);
            var createdCustomer = await _dataService.UpdateAsync(id, dbCustomer);

            return _mapper.Map<CustomerDto>(createdCustomer);
        }
    }
}
