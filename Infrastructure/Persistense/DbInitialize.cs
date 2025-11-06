using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities.Identity;
using Store.G04.Domain.Entities.Products;
using Store.G04.Persistence.Data.Contexts;
using Store.G04.Persistence.Identity.Contexts;
using System.Text.Json;

namespace Store.G04.Persistence
{
    // CLR
    public class DbInitialize
        (StoreDbContext _context,
        IdentityStoreDbContext _identityContext,
        UserManager<AppUser> _userManager,
        RoleManager<IdentityRole> _roleManager
        ) /*Primary Constructor*/ : IDbInitializer
    {

        public async Task InitializeAsync()
        {
            // 1. Create DB
            // 2. Update DB
            if (_context.Database.GetPendingMigrations().Any())
            {
                await _context.Database.MigrateAsync();
            }

            // 3. Data seeding  //////Must Be Brand & Types Before Product/////////

            // 3.1 ProductBrands
            if (!_context.ProductBrands.Any())
            {
                // 3.1.1 Read JSON file
                var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistense\Data\DataSeeding\brands.json");

                // 3.1.2 Convert JSONString To List<ProductBrand> 
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                // 3.1.3 Add List To The DB
                if (brands is not null && brands.Count > 0)
                {
                    await _context.ProductBrands.AddRangeAsync(brands);
                    await _context.SaveChangesAsync();
                }
            }

            // 3.2 ProductTypes
            if (!_context.ProductTypes.Any())
            {
                // 3.2.1 Read JSON file
                var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistense\Data\DataSeeding\types.json");

                // 3.2.2 Convert JSONString To List<ProductBrand> 
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                // 3.2.3 Add List To The DB
                if (types is not null && types.Count > 0)
                {
                    await _context.ProductTypes.AddRangeAsync(types);
                    await _context.SaveChangesAsync();
                }
            }
            // 3.3 Products
            if (!_context.Products.Any())
            {
                // 3.3.1 Read JSON file
                var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistense\Data\DataSeeding\products.json");

                // 3.3.2 Convert JSONString To List<ProductBrand> 
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                // 3.3.3 Add List To The DB
                if (products is not null && products.Count > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }
            }

            _context.SaveChangesAsync();
        }

        public async Task InitializeIdentityAsync()
        {
            // 1. Create DB
            // 2. Update DB
            if (_identityContext.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Any())
            {
                await _identityContext.Database.MigrateAsync();
            }

            // 3. Data seed
            if (!_identityContext.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!_identityContext.Users.Any())
            {
                var superAdmin = new AppUser
                {
                    DisplayName = "SuperAdmin",
                    UserName = "SuperAdmin",
                    Email = "SuperAdmin@gmail.com",
                    PhoneNumber = "01234567890"
                };

                var admin = new AppUser
                {
                    DisplayName = "Admin",
                    UserName = "Admin",
                    Email = "Admin@gmail.com",
                    PhoneNumber = "01234567890"
                };

                await _userManager.CreateAsync(superAdmin, "P@ssW0rd");
                await _userManager.CreateAsync(admin, "P@ssW0rd");

                await _userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}