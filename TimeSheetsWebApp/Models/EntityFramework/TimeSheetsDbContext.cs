using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Models.EntityFramework.Configuration;

namespace TimeSheetsWebApp.Models.EntityFramework
{
    public class TimeSheetsDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoices> Invoice { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.1.72;Database=GeekBrains;Username=postgres;Password=qwe123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        }



    }

}
