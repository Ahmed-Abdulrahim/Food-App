using FoodDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL.Interfaces
{
    public interface ICategoryRepo
    {
        void Add(Category model);
        void Update(Category model);
        void Delete(Category model);
        IEnumerable<Category> GetAll();
      Category GetByCategoryId(int id);
        Task<int> Save();
    }
}
