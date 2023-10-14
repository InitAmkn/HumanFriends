using HumanFriends.DAL;
using HumanFriends.DAL.Interfaces;
using HumanFriends.DAL.Repositories;
using HumanFriends.Domain.Entity;
using HumanFriends.Service.Implementations;
using HumanFriends.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HumanFriends
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql("Server=host.docker.internal;Username=postgres;Password=123;Database=Animal_db"));

            builder.Services.AddScoped<IBaseRepository<Animal>, AnimalRepository>();
            builder.Services.AddScoped<IBaseService<Animal>, AnimalService>();
            builder.Services.AddScoped<IBaseRepository<TypeAnimal>, TypeAnimalRepository>();
            builder.Services.AddScoped<IBaseRepository<ApplicabilityAnimal>, ApplicabilityAnimalRepository>();
            builder.Services.AddScoped<IBaseRepository<ApplicabilityCommand>, ApplicabilityCommandRepository>();
            builder.Services.AddScoped<IBaseRepository<Command>, CommandRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}