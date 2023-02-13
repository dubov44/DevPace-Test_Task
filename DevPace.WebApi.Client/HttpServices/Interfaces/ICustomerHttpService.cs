using DevPace.WebApi.Common.Models;
using DevPace.WebApi.Common.Models.Validation;

namespace DevPace.WebApi.Client.HttpServices.Interfaces
{
    public interface ICustomerHttpService
    {
        Task<CustomerResponse> GetCustomers(CustomerFiltered filteredDto);

        Task<Customer?> GetByIdAsync(long id);

        Task SaveAsync(Customer entity);

        Task DeleteByIdAsync(long id);

        Task<bool> CheckForUniqueName(CustomerNameValidationModel model);
    }
}
