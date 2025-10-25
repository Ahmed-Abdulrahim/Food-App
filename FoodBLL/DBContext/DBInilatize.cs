using FoodBLL.Interfaces;
using FoodDAL.Context;
using FoodDAL.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL.DBContext
{
    public class DBInitialize : IInitialize
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly FoodDbContext context;

        public DBInitialize(RoleManager<IdentityRole> _roleManager , UserManager<IdentityUser> _userManager , FoodDbContext _context)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            context = _context;
        }
        public void Initialize()
        {
            try
            {
                if (context.Database.GetMigrations().Count() > 0) 
                {
                    context.Database.Migrate();
                }
            }
            catch 
            {
                throw;
            }

            if (context.Roles.Any(x => x.Name == "Admin")) return;
            roleManager.CreateAsync(new IdentityRole("Manager")).GetAwaiter().GetResult();
            roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            var user = new AppUser()
            {
                Name = "Admin",
                UserName = "Admin@Admin.com",
                Email = "Admin@Admin.com",
                City = "Cairo",
                Address = "Cairo,Egypt",
                PostalCode = "3333",

            };
            userManager.CreateAsync(user,"Admin@Admin.com").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
