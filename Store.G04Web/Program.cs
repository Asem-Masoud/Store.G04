using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Store.G04.Domain.Contracts;
using Store.G04.Persistence;
using Store.G04.Persistence.Data.Contexts;
using Store.G04.Services;
using Store.G04.Services.Abstractions;
using Store.G04.Services.Mapping.Products;
using System.Threading.Tasks;

namespace Store.G04Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<StoreDbContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDbInitializer, DbInitialize>(); // Initialize Db
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManger, ServiceManger>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new ProductProfile()));


            var app = builder.Build();

            #region Initialize Db
            using var scope = app.Services.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>(); // ASK CLR to Create object From IDbInitializer
            await dbInitializer.InitializeAsync();
            #endregion

            app.UseStaticFiles();  // For wwwroot folder

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
