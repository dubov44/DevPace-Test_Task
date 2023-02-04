using DevPace.BusinessLogic.Dto.Customer;

namespace DevPace.BusinessLogic.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();

        Task<Tuple<IEnumerable<CustomerDto>, int>> GetAllFilteredAsync(CustomerFilteredDto filteredDto);

        Task<CustomerDto?> GetByIdAsync(long id);

        Task<CustomerDto> SaveAsync(CustomerDto entity);

        Task<bool> DeleteByIdAsync(long id);

        Task<bool> CheckForUniqueName(long? id, string name);
    }
}
