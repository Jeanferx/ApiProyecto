
using ApiProductos.Data.Context;
using ApiProductos.Data.Repository;
using ApiProductos.Data.Repository.Interface;
using ApiProductos.Mappers;
using ApiProductos.Mappers.Interface;
using ApiProductos.Middleware;
using ApiProductos.Service;
using ApiProductos.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiProductos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Servicios
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DBContext
            builder.Services.AddDbContext<ContextProductos>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repository, Service y Mapper
            builder.Services.AddScoped<IRepositoryProductos, RepositoryProductos>();
            builder.Services.AddScoped<IServiceProductos, ServiceProductos>();
            builder.Services.AddScoped<IMapperDtoProductos, MapperdtoProductos>();
            builder.Services.AddScoped<IMapperEntityProductos, MapperEntityProductos>();
            // JWT Service

            builder.Services.AddAuthorization();

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Crear DB si no existe
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ContextProductos>();
                dbContext.Database.EnsureCreated();
            }

            // Pipeline HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAngular");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<mensajeMidd>();
            app.MapControllers();
            app.Run();
        }
    }
}
