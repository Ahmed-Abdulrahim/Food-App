using FoodBLL.Interfaces;
using FoodBLL.Repo;
using FoodDAL.Models;
using FoodPL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodPL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly IFoodRepo<SubCategory> subcategoryRepo;
        private readonly IFoodRepo<Category> categoryRepo;

        public SubCategoryController(IFoodRepo<SubCategory> _subcategoryRepo , IFoodRepo<Category> categoryRepo)
        {
            subcategoryRepo = _subcategoryRepo;
            this.categoryRepo = categoryRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var cartList = subcategoryRepo.GetAll();
           
            return View(cartList);
        }


        [HttpGet]
        public IActionResult Create()
        {
          var list = categoryRepo.GetAll();
            ViewBag.Category = new SelectList(list, "Id", "Title");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(SubCategory model)
        {
            if (ModelState.IsValid)
            {
                subcategoryRepo.Add(model);
                var res = await subcategoryRepo.Save();
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
            var model = subcategoryRepo.GetByCategoryId(id.Value);
            if (model == null) return NotFound();
            var list = categoryRepo.GetAll();
            ViewBag.Category = new SelectList(list, "Id", "Title");
            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int? id, SubCategory model)
        {
            if (id != model.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                subcategoryRepo.Update(model);
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
            var model = subcategoryRepo.GetByCategoryId(id.Value);
            if (model == null) return NotFound();
            
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var model = subcategoryRepo.GetByCategoryId(id.Value);
            if (model == null) return NotFound();
            subcategoryRepo.Delete(model);
            var res = await subcategoryRepo.Save();
            if (res > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
