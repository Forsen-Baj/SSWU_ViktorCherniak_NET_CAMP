using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_13_1
{
    public class RentalContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalItem> RentalItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supply> Supplies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VLMIJA9;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Initial Catalog=RentalDB");
        }
        
    }
}
