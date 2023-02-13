using AutoMapper;
using DevPace.WebApi.Common.Models;
using DevPace.WPF.Models.Customer;

namespace DevPace.WPF.Infrastructure.Mappers
{
    public class CustomerMappersWpf : Profile
    {
        public CustomerMappersWpf()
        {
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();
        }
    }
}
