using InfnetMVC.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace InfnetMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<InfnetDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("InfnetDbContext")); //se um dia eu decidir usar postgres vou alterar aqui
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<InfnetDbContext>(); //aqui estou adicionando o controle de usuarios do identity

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthentication(); //estou dizendo que vou utilizar autenticaçao

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Funcionarios}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
