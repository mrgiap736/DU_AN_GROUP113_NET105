using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DU_AN_GROUP113_NET105.Models.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
                
        }

        public ProjectContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<DiscountCode> DiscountCode { get; set; }
        public DbSet<DiscountCategory> DiscountCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MRG;Database=ProjectASM_GR113;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
