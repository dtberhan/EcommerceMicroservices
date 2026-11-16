using CustomerWebApi.Data;
using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<string> addCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return "Record added successfully";

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return ("Some error occured. Please try again\n" + ex.Message);
            }
        }

        public async Task<IEnumerable<Customer>> getAllCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> getCustomerById(int id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    throw new KeyNotFoundException($"Customer with ID {id} not found.");
                }
                return customer;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while retrieving the customer: " + ex.Message);
            }
        }

        public async Task<string> updateCustomer(int id, Customer customer)
        {
            try
            {
                var existingCustomer = await _context.Customers.FindAsync(id);
                if (existingCustomer == null)
                {
                    throw new KeyNotFoundException($"Customer with ID {id} not found.");
                }

                _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
                await _context.SaveChangesAsync();
                return "Record updated successfully";
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return ("Some error occured. Please try again\n" + ex.Message);
            }
        }

        public async Task<string> deleteCustomer(int id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                    return "Customer not found!";

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return "Record deleted successfully";
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return ("Some error occured. Please try again\n" + ex.Message);
            }
        }
    }
}


