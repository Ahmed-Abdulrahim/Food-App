using FoodBLL.DTO;
using FoodDAL.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace FoodPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> appUser;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> _AppUser , SignInManager<AppUser> _signInManager)
        {
            appUser = _AppUser;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpData model) 
        {
            var FoundUser = await appUser.FindByNameAsync(model.UserName);
            if (FoundUser != null) 
            {
                ModelState.AddModelError("UserName", "Username already exists!");
                return View(model);
            }
            var FoundEmail = await appUser.FindByEmailAsync(model.Email);
            if (FoundEmail != null) 
            {
                ModelState.AddModelError("Email", "Email is Already Exists");
                return View(model);
            }
            var user = new AppUser 
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                City = model.City,
                Address = model.Address,
                PostalCode = model.PostalCode,
                
            };
            var res = await appUser.CreateAsync(user, model.Password);
            if (res.Succeeded) 
            {
              return  RedirectToAction("SignIn");
            }
            foreach (var e in res.Errors)
            {
                if (e.Description.Contains("Passwords"))
                    ModelState.AddModelError("Password", e.Description);
                else
                    ModelState.AddModelError("", e.Description);
            }
            return View(model);
        }

        [HttpGet]
        public  IActionResult SignIn() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInData model) 
        {
            if (ModelState.IsValid) 
            {
                var userEmail = await appUser.FindByEmailAsync(model.Email);
                if (userEmail != null) 
                {
                    var userPass =await appUser.CheckPasswordAsync(userEmail, model.Password);
                    if (userPass)
                    {
                        var res = await signInManager.PasswordSignInAsync(userEmail, model.Password, model.RememberMe, false);
                        if (res.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
    }
}
