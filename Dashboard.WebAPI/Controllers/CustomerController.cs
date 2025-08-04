using Dashboard.Application.Commands.Users;
using Dashboard.Application.DTOs.Customers;
using Dashboard.Application.Queries.Customer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.WebAPI.Controllers
{
    [ApiController]
    [Route("customers")]
    [Authorize]
    public class CustomerController(IMediator mediatR) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            var customers = await mediatR.Send(new GetAllCustomersQuery());
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = await mediatR.Send(new GetCustomerByIdQuery(id));
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
