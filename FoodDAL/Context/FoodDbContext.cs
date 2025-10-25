using FoodDAL.Models;
using FoodDAL.Models.Auth;
using FoodDAL.Models.Order;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDAL.Context
{
    public class FoodDbContext :IdentityDbContext<AppUser>
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options):base(options)
        {
            
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
