
using Ecommerce.Infrastructure;
using Ecommerce.Infrastructure.DataSeed;
using Ecommerce.Infrastructure.Repositories;
using ECommerce.API.Helper;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling 
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ECommerceContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });

            builder.Services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));

            builder.Services.AddScoped<IUnitofWork, UnitofWork>();

            builder.Services.AddAutoMapper(typeof(MappingProfiles));


            var app = builder.Build();

           using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var _dbcontext = services.GetRequiredService<ECommerceContext>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
               await _dbcontext.Database.MigrateAsync();
                DataSeeding.AddData(_dbcontext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "this error happened during migration");

            }


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
