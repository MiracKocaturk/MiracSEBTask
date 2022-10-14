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
        public ActionResult<IEnumerable<RetrieveCustomerDto>> GetCustomers()
        {
            var customers = customerRepository.GetCustomers().Select(customer => new RetrieveCustomerDto
            { 
                Id =customer.Id,
                SocialSecurityNumber=customer.SocialSecurityNumber,
                EmailAddress = customer.EmailAddress,
                PhoneNumber =customer.PhoneNumber
            });
            return Ok(customers);
        }

        //GET /customers/{id}
        [HttpGet("{id}")]
        public ActionResult<RetrieveCustomerDto> GetCustomer(Guid id)
        {
            var customer = customerRepository.GetCustomer(id);
            
            if (customer is null)
            {
                return NotFound();
            }
            RetrieveCustomerDto customerDto = new()
            {
                Id = customer.Id,
                SocialSecurityNumber = customer.SocialSecurityNumber,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber
            };
            return Ok(customerDto);
        }

        //POST /customers/
        [HttpPost]
        public ActionResult<RetrieveCustomerDto> CreateCustomer(CreateCustomerDto customerDto)
        {
            Customer customer = new Customer()
            {
                Id = Guid.NewGuid(),
                SocialSecurityNumber = customerDto.SocialSecurityNumber,
                EmailAddress = customerDto.EmailAddress,
                PhoneNumber = customerDto.PhoneNumber
            };

            customerRepository.CreateCustomer(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, new RetrieveCustomerDto
            {
                Id = customer.Id,
                SocialSecurityNumber = customer.SocialSecurityNumber,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber
            });
        }

    }
}
