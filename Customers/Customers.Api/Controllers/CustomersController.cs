using Customers.Infrastructure.Abstraction;
using Customers.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customers.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> SignInAsync([FromBody]LoginDto login)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Please check all fileds");
            }
            var customer = await _service.LoginAsync(login);

            if(customer is not null)
            {
                return Ok(customer);

            }
            return NotFound("Login failed, please check your username or password");

        }


        [HttpPost]
        public async Task<ActionResult> Register(AddCustomerDto addCustomer) {

            var customer = await _service.RegisterAsync(addCustomer);

            if (customer is not null)
            {
                return Ok(customer);

            }
            return NotFound();

        }
    }
}

