using Microsoft.AspNetCore.Mvc;
using MiracSEBTask.Dtos;
using MiracSEBTask.Models;
using MiracSEBTask.Repositories;
using System.Collections;

namespace MiracSEBTask.Controllers
{
    
    
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private readonly  ICustomerRepository customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        // GET /customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customers = customerRepository.GetCustomers().Select(customer => new CustomerDto
            { 
                Id =customer.Id,
                SocialSecurityNumber=customer.SocialSecurityNumber,
                PhoneNumber=customer.PhoneNumber
            });
            return Ok(customers);
        }

        //GET /customers/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(Guid id)
        {
            var customer = customerRepository.GetCustomer(id);
            
            if (customer is null)
            {
                return NotFound();
            }
            CustomerDto customerDto = new()
            {
                Id = customer.Id,
                SocialSecurityNumber = customer.SocialSecurityNumber,
                PhoneNumber = customer.PhoneNumber
            };
            return Ok(customerDto);
        }
    }
}
