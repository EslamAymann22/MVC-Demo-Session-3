using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager 
            ,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel MyModel)
        {
            if (ModelState.IsValid)
            {
                var User = new ApplicationUser()
                {
                    UserName = MyModel.Email.Split('@')[0],
                    Email = MyModel.Email,
                    FName = MyModel.FName,
                    LName = MyModel.LName,
                    IsAgree = MyModel.IsAgree
                };
                var Result = await _userManager.CreateAsync(User, MyModel.Password);

                if (Result.Succeeded)

                    return RedirectToAction("Login");

                else
                    foreach (var error in Result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);


            }
            return View(MyModel);
        }

        #endregion


        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel MyModel) {

            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByEmailAsync(MyModel.Email);

                if(User is not null)
                {
                    var check = await _userManager.CheckPasswordAsync(User, MyModel.Password);
                    if (check)
                    {
                       var Log = await _signInManager.PasswordSignInAsync(User, MyModel.Password,MyModel.RememberMe,false);

                        if (Log.Succeeded)
                            return  RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError(string.Empty, "Password is Incorrect");
                }
                else
                    ModelState.AddModelError(string.Empty, "Email is not Exists");
                
            }
            return View(MyModel);
        }

        #endregion


        #region SignOut

        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion

        // Sing out
        // Forget Password
        // reset Password
    }
}

