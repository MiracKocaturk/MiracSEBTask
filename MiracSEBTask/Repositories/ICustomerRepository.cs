using MiracSEBTask.Models;

namespace MiracSEBTask.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetCustomers();
    }
}