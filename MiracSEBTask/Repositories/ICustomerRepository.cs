using MiracSEBTask.Models;

namespace MiracSEBTask.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(Guid id);
        IEnumerable<Customer> GetCustomers();

        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid id);
    }
}