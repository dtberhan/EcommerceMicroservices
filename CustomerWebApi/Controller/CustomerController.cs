using CustomerWebApi.Dtos;
using CustomerWebApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService _customerService)
        {
            this.customerService = _customerService;
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(CustomerDto customerDto)
        {
            var result = await customerService.addCustomer(customerDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            var result = await customerService.getAllCustomers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var result = await customerService.getCustomerById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            var result = await customerService.updateCustomer(id, customerDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var result = await customerService.deleteCustomer(id);
            return Ok(result);
        }
    }
}
