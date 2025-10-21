using Microsoft.EntityFrameworkCore;
using Store.G04.Domain.Entities.Products;
using Store.G04.Persistence.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Persistence.Data.Contexts
{
    // CLR
    public class StoreDbContext : DbContext
    {

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            /*
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductBrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            */

            base.OnModelCreating(modelBuilder);
        }
    }
}