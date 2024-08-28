using ecom.Models;
using ecom.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecom.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager)
        {
            this.UserManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel uservm)
        {
            if (ModelState.IsValid)
            {
                AppUser userModel = await UserManager.FindByNameAsync(uservm.UserName);
                if (userModel!=null)
                {
                    bool found = await UserManager.CheckPasswordAsync(userModel, uservm.Password);
                    if (found==true)
                    {
                       await signInManager.SignInAsync(userModel, uservm.RemeberMe);
                        return RedirectToAction("Index", "Product");   
                    }
                }
                ModelState.AddModelError("", "user name or password wrong");
            }
            return View(uservm);
        }  


        
        [HttpGet]
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> register(RegisterUserViewModel NewUservm)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = NewUservm.UserName;
                user.Address = NewUservm.Address;
                user.PasswordHash = NewUservm.Password;

                IdentityResult result = await UserManager.CreateAsync(user,NewUservm.Password);
                if (result.Succeeded)
                {
                   await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Password", item.Description);

                    }
                }


            }
            return View(NewUservm);
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public class task<T>
        {
        }
    }
}
