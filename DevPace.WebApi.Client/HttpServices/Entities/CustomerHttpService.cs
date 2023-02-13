using DevPace.WebApi.Client.HttpServices.Interfaces;
using DevPace.WebApi.Common.Models;
using DevPace.WebApi.Common.Models.Validation;

namespace DevPace.WebApi.Client.HttpServices.Entities
{
    public class CustomerHttpService : HttpServiceBase, ICustomerHttpService
    {
        private readonly string _controllerPrefix = "customers";

        public CustomerHttpService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public Task<CustomerResponse> GetCustomers(CustomerFiltered filtered)
        {
            return Send<CustomerFiltered, CustomerResponse>($"{_controllerPrefix}", HttpMethod.Get, filtered);
        }

        public Task<Customer?> GetByIdAsync(long id)
        {
            return Send<Customer?>($"{_controllerPrefix}/{id}", HttpMethod.Get);
        }
        public Task SaveAsync(Customer entity)
        {
            return Send($"{_controllerPrefix}", HttpMethod.Post, entity);
        }

        public Task DeleteByIdAsync(long id)
        {
            return Send($"{_controllerPrefix}/{id}", HttpMethod.Delete);
        }

        public Task<bool> CheckForUniqueName(CustomerNameValidationModel model)
        {
            return Send<CustomerNameValidationModel, bool>($"{_controllerPrefix}/check", HttpMethod.Get, model);
        }
    }
}
