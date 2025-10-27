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
    public class CategoryRepo : IFoodRepo<Category>
    {
        private readonly FoodDbContext context;

        public CategoryRepo(FoodDbContext _context)
        {
            context = _context;
        }
        public void Add(Category model)=>context.Category.Add(model);


        public void Delete(Category model) => context.Category.Remove(model);
        

        public IEnumerable<Category> GetAll()=>context.Category.ToList();


        public Category GetByCategoryId(int id) => context.Category.FirstOrDefault(s => s.Id == id);
        

        public Task<int> Save()=>context.SaveChangesAsync();


        public void Update(Category model) => context.Category.Update(model);
        
    }
}
