using AutoMapper;
using DevPace.BusinessLogic.Dto.Customer;
using DevPace.WPF.Models.Customer;

namespace DevPace.WPF.Infrastructure.Mappers
{
    public class CustomerMappersWpf : Profile
    {
        public CustomerMappersWpf()
        {
            CreateMap<CustomerDto, CustomerModel>();
            CreateMap<CustomerModel, CustomerDto>();
        }
    }
}
