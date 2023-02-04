using AutoMapper;
using DevPace.BusinessLogic.Dto.Customer;
using DevPace.Domain.Models;

namespace DevPace.BusinessLogic.Infrastructure.Mappers
{
    public class CustomerMappers : Profile
    {
        public CustomerMappers()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CustomerSearch, CustomerFilteredDto>();
            CreateMap<CustomerFilteredDto, CustomerSearch>();
        }
    }
}
