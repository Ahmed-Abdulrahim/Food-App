using FoodDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL.Interfaces
{
    public interface IFoodRepo<T>
    {
        void Add(T model);
        void Update(T model);
        void Delete(T model);
        IEnumerable<T> GetAll();
      T GetByCategoryId(int id);
        Task<int> Save();
    }
}
