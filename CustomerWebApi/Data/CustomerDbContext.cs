namespace CustomerWebApi.Data
{

    using global::CustomerWebApi.Models;
    using Microsoft.EntityFrameworkCore;


    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers => Set<Customer>();
    }

}
