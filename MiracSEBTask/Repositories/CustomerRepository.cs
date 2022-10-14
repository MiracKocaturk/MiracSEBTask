﻿using MiracSEBTask.Models;
using System.Linq;
using System.Net.Mail;

namespace MiracSEBTask.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers = new List<Customer>()
        {
            new Customer { Id = 1, SocialSecurityNumber=  "8501011234",EmailAddress=  "test1@test.com",PhoneNumber = "+46731234567" },
            new Customer { Id = 2, SocialSecurityNumber = "8501011235",EmailAddress = "test2@test.com",PhoneNumber = "+46731234567" },
            new Customer { Id = 3, SocialSecurityNumber = "8501011236",EmailAddress = "test3@test.com",PhoneNumber = "+46731234567" }
        };

        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            return customers.SingleOrDefault(customer => customer.Id == id);
        }
    }
}