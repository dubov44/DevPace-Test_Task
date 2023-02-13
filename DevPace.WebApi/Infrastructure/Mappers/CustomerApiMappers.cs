using AutoMapper;
using DevPace.BusinessLogic.Dto.Customer;
using DevPace.WebApi.Common.Models;

namespace DevPace.WebApi.Infrastructure.Mappers
{
    public class CustomerApiMappers : Profile
    {
        public CustomerApiMappers()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CustomerFiltered, CustomerFilteredDto>();
            CreateMap<CustomerFilteredDto, CustomerFiltered>();
        }
    }
}
