using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities.Products;
using Store.G04.Persistence.Data.Contexts;
using System.Text.Json;

namespace Store.G04.Persistence
{
    // CLR
    public class DbInitialize(StoreDbContext _context) /*Primary Constructor*/ : IDbInitializer
    {

        public async Task InitializeAsync()
        {
            // 1. Create DB
            // 2. Update DB
            if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Any())
            {
                await _context.Database.MigrateAsync();
            }

            // 3. Data seeding  //////Must Be Brand & Types Before Product/////////

            // 3.1 ProductBrands
            if (_context.ProductBrands.Any())
            {// C:\Users\asemm\source\repos\Store.G04\Infrastructure\Persistense\Data\DataSeeding\brands.json
                // 3.1.1 Read JSON file
                var brandsdata = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\DataSeeding\brands.json");

                // 3.1.2 Convert JSONString To List<ProductBrand> 
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);

                // 3.1.3 Add List To The DB
                if (brands is not null && brands.Count > 0)
                {
                    await _context.ProductBrands.AddRangeAsync(brands);
                }
            }

            // 3.2 ProductTypes
            if (_context.ProductTypes.Any())
            {
                // 3.2.1 Read JSON file
                var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\DataSeeding\types.json");

                // 3.2.2 Convert JSONString To List<ProductBrand> 
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                // 3.2.3 Add List To The DB
                if (types is not null && types.Count > 0)
                {
                    await _context.ProductTypes.AddRangeAsync(types);
                }
            }
            // D:\Courses\Asp.Net (Rabaa)\Projects\08 Api\Store.G04\Infrastructure\Persistense\Data\DataSeeding\brands.json
            // 3.3 Products
            if (_context.Products.Any())
            {
                // 3.3.1 Read JSON file
                var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\DataSeeding\products.json");

                // 3.3.2 Convert JSONString To List<ProductBrand> 
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                // 3.3.3 Add List To The DB
                if (products is not null && products.Count > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                }
            }
            _context.SaveChangesAsync();
        }
    }
}