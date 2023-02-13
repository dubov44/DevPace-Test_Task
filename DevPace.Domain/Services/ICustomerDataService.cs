using DevPace.Domain.Models;

namespace DevPace.Domain.Services
{
    public interface ICustomerDataService
    {
        Task<Tuple<IEnumerable<Customer>, int>> GetFilteredAsync(CustomerSearch filteredCustomer);

        Task<bool> CheckForUniqueName(long? id, string name);
    }
}
