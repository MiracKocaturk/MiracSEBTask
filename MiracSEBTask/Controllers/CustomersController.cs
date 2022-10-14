using Microsoft.AspNetCore.Mvc;
using MiracSEBTask.Models;
using MiracSEBTask.Repositories;
using System.Collections;

namespace MiracSEBTask.Controllers
{
    
    
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private readonly  CustomerRepository customerRepository;
        public CustomersController()
        {
            customerRepository = new CustomerRepository();
        }

        // GET /customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var customers = customerRepository.GetCustomers();
            return Ok(customers);
        }

        //GET /customers/{id}
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = customerRepository.GetCustomer(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
