using Microsoft.EntityFrameworkCore;
using InevntoryManagementSystem.Models;


namespace InevntoryManagementSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        //Business
        public DbSet<Products> Products { get; set; }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Stocks> Stocks { get; set; }

        public DbSet<Sales> Sales { get; set; } 
        public DbSet<Customers> Customers { get; set; }

        public DbSet<Bill> Bill { get; set; }


        public DbSet<ReportToPDF> ReportToPDF { get; set; }
       

       


    }
}
