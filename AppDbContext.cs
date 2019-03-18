using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Task2_v2_0_0 {
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}