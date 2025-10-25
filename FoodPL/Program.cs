using FoodDAL.Context;
using FoodDAL.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FoodDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conn1"));
            });
            builder.Services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<FoodDbContext>();
            builder.Services.ConfigureApplicationCookie(config =>
           config.LoginPath = "/Account/SignIn"
           );


            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
