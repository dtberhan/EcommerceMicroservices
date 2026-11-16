using CustomerWebApi.Dtos;

namespace CustomerWebApi.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> getAllCustomers();
        Task<CustomerDto> getCustomerById(int id);
        Task<string> addCustomer(CustomerDto customerDto);
        Task<string> updateCustomer(int id, CustomerDto customerDto);
        Task<string> deleteCustomer(int id);
    }
}
