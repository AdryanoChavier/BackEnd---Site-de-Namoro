using BackEnd.Data;
using BackEnd.Extensions;
using BackEnd.Interfaces;
using BackEnd.Middleware;
using BackEnd.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BackEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAplicationServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
           

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
                .WithOrigins("http://localhost:4200", "https://localhost:4200"));

            app.UseAuthentication();
            app.UseAuthorization();

        
            app.MapControllers();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await Seed.SeedUsuarios(context);
            }
            catch (Exception ex) 
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Aconteceu um erro na migration");
            }

            app.Run();
        }
    }
}