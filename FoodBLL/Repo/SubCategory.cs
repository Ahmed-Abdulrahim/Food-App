using FoodBLL.Interfaces;
using FoodDAL.Context;
using FoodDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL.Repo
{
    public class SubCategoryRepo : IFoodRepo<SubCategory>
    {
        private readonly FoodDbContext context;

        public SubCategoryRepo(FoodDbContext _context)
        {
            context = _context;
        }
        public void Add(SubCategory model) => context.SubCategory.Add(model);


        public void Delete(SubCategory model) => context.SubCategory.Remove(model);


        public IEnumerable<SubCategory> GetAll() => context.SubCategory.Include(c=>c.Categories).ToList();


        public SubCategory GetByCategoryId(int id) => context.SubCategory.Include(c=>c.Categories).FirstOrDefault(s => s.Id == id);


        public Task<int> Save() => context.SaveChangesAsync();


        public void Update(SubCategory model) => context.SubCategory.Update(model);
    }
}
