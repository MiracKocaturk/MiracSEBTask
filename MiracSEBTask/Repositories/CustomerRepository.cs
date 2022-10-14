using Microsoft.AspNetCore.Http.Features;
using MiracSEBTask.Models;
using System.Linq;
using System.Net.Mail;

namespace MiracSEBTask.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers = new List<Customer>()
        {
            new Customer { Id = Guid.NewGuid(), SocialSecurityNumber = "8501011234",EmailAddress = "test1@test.com",PhoneNumber = "+46731234567" },
            new Customer { Id = Guid.NewGuid(), SocialSecurityNumber = "8501011235",EmailAddress = "test2@test.com",PhoneNumber = "+46731234567" },
            new Customer { Id = Guid.NewGuid(), SocialSecurityNumber = "8501011236",EmailAddress = "test3@test.com",PhoneNumber = "+46731234567" }
        };

        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }

        public Customer GetCustomer(Guid id)
        {
            return customers.SingleOrDefault(customer => customer.Id == id);
        }

        public void CreateCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var index=customers.FindIndex(existing => existing.Id==customer.Id);
            customers[index] = customer;
        }

        public void DeleteCustomer(Guid id)
        {
            var index = customers.FindIndex(existing => existing.Id == id);
            customers.RemoveAt(index);

        }
    }
}
