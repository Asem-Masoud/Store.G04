using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.G04.Domain.Contracts;
using Store.G04.Persistence;
using Store.G04.Persistence.Data.Contexts;
using Store.G04.Services;
using Store.G04.Services.Abstractions;
using Store.G04.Services.Mapping.Products;
using Store.G04.Shared.ErrorModels;
using Store.G04Web.Extensions;
using Store.G04Web.Middlewares;
using System.ComponentModel;

namespace Store.G04Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            /*
            builder.Services.AddControllers(); // APIController

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DB

            //builder.Services.AddDbContext<StoreDbContext>(Options =>
            //{
            //    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});
            //builder.Services.AddScoped<IDbInitializer, DbInitialize>(); // Allow DI For DbInitializer
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddInfrastructureServices(builder.Configuration);


            //builder.Services.AddScoped<IServiceManger, ServiceManger>(); // Mapping
            //builder.Services.AddAutoMapper(M => M.AddProfile(new ProductProfile(builder.Configuration)));

            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.Configure<ApiBehaviorOptions>(config =>
            {
                config.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(m => m.Value.Errors.Any())
                      .Select(m => new ValidationError()
                      {
                          Field = m.Key,
                          Errors = m.Value.Errors.Select(e => e.ErrorMessage)
                      });

                    var response = new ValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(response);
                };
            });

            */

            builder.Services.RegisterAllServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            /*
            #region Initialize Db
            using var scope = app.Services.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>(); // ASK CLR to Create object From IDbInitializer
            await dbInitializer.InitializeAsync();
            #endregion

            app.UseMiddleware<GlobalErrorHandlingMiddleware>();

            //// Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();  // For wwwroot folder

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            */

            await app.ConfigureMiddleWares();

            app.Run();

        }
    }
}