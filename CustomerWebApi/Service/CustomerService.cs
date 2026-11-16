using AutoMapper;
using CustomerWebApi.Dtos;
using CustomerWebApi.Models;
using CustomerWebApi.Repository;

namespace CustomerWebApi.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repo;
        private IMapper mapper;

        public CustomerService(ICustomerRepository _repo, IMapper _mapper)
        {
            this.repo = _repo;
            this.mapper = _mapper;
        }
        public Task<string> addCustomer(CustomerDto customerDto)
        {
            Customer customer = mapper.Map<Customer>(customerDto);
            return repo.addCustomer(customer);
        }

        public Task<string> deleteCustomer(int id)
        {
            return repo.deleteCustomer(id);
        }

        public Task<IEnumerable<CustomerDto>> getAllCustomers()
        {
            return Task.Run(async () =>
            {
                var customers = await repo.getAllCustomers();
                return mapper.Map<IEnumerable<CustomerDto>>(customers);
            });
        }

        public Task<CustomerDto> getCustomerById(int id)
        {
            return Task.Run(async () =>
            {
                var customer = await repo.getCustomerById(id);
                return mapper.Map<CustomerDto>(customer);
            });
        }


        public Task<string> updateCustomer(int id, CustomerDto customerDto)
        {
            Customer customer = mapper.Map<Customer>(customerDto);
            return repo.updateCustomer(id, customer);
        }
    }
}
