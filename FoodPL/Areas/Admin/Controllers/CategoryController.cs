using FoodBLL.Interfaces;
using FoodBLL.Repo;
using FoodDAL.Models;
using FoodPL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodPL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoryController(ICategoryRepo _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var catlist = categoryRepo.GetAll();
            var models = new List<CategoryVM>();
            foreach (var cat in catlist) 
            {
                models.Add(new CategoryVM 
                {
                    Id = cat.Id,
                    Title = cat.Title,
                });
            }
            return View(models);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
      
        public async Task<IActionResult> Create(CategoryVM model) 
        {
            if (ModelState.IsValid) 
            {
                var model1 = new Category 
                {
                    Title = model.Title,
                };
                categoryRepo.Add(model1);
                var res = await categoryRepo.Save();
                if (res > 0) 
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var model = categoryRepo.GetByCategoryId(id.Value);
            if(model == null) return NotFound();
            var model1 = new CategoryVM
            {
                Id = model.Id,
                Title = model.Title,
            };
            return View(model1);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int? id ,CategoryVM model)
        {
            if (id != model.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var model1 = new Category
                {
                   Id=model.Id,
                    Title = model.Title,
                };
                categoryRepo.Update(model1);
                var res = await categoryRepo.Save();
                if (res > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id) 
        {
            if (id == null) return BadRequest();
            var res = categoryRepo.GetByCategoryId(id.Value);
            if (res == null) return NotFound();
            var model = new CategoryVM
            {
                Title = res.Title,
                Id = res.Id,
            };
            return View(model);
           

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id) 
        {
            if (id == null) return BadRequest();
            var model = categoryRepo.GetByCategoryId(id.Value);
            if (model == null) return NotFound();
             categoryRepo.Delete(model);
            var res = await categoryRepo.Save();
            if (res > 0) 
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
