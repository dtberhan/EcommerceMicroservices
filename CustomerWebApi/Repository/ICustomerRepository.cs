using CustomerWebApi.Models;

namespace CustomerWebApi.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> getAllCustomers();
        Task<Customer> getCustomerById(int id);
        Task<string> addCustomer(Customer customer);
        Task<string> updateCustomer(int id, Customer customer);
        Task<string> deleteCustomer(int id);

    }
}
