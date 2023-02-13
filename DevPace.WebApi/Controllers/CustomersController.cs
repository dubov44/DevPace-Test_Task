using AutoMapper;
using DevPace.BusinessLogic.Dto.Customer;
using DevPace.BusinessLogic.Services.Interfaces;
using DevPace.WebApi.Common.Models;
using DevPace.WebApi.Common.Models.Validation;
using Microsoft.AspNetCore.Mvc;

namespace DevPace.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(
            ICustomerService customerService,
            IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<CustomerResponse> GetAllFilteredAsync([FromBody]CustomerFiltered filtered)
        {
            var filteredDto = _mapper.Map<CustomerFilteredDto>(filtered);
            var temp = await _customerService.GetAllFilteredAsync(filteredDto);

            return new CustomerResponse
            {
                Customers = _mapper.Map<IEnumerable<Customer>>(temp.Item1),
                Count = temp.Item2
            };
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Customer?> GetByIdAsync(long id)
        {
            var customerDto = await _customerService.GetByIdAsync(id);
            return _mapper.Map<Customer>(customerDto);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> SaveAsync([FromBody]Customer entity)
        {
            var entityDto = _mapper.Map<CustomerDto>(entity);

            await _customerService.SaveAsync(entityDto);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _customerService.DeleteByIdAsync(id);

            return Ok();
        }

        [HttpGet]
        [Route("check")]
        public async Task<bool> CheckIsNameUnique([FromBody] CustomerNameValidationModel model)
        {
            return await _customerService.CheckForUniqueName(model.Id, model.Name);
        }
    }
}
