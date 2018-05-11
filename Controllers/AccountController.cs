using TheBookCave.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models.ViewModels;
using System.Threading.Tasks;
using TheBookCave.Data;
using System.Security.Claims;

namespace TheBookCave.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid) {return View();}
            var user = new ApplicationUser {UserName = model.username, Email = model.username};
            var result = await _userManager.CreateAsync(user, model.password);
            if(result.Succeeded)
            {
                //await _userManager.AddClaimAsync(user, new Claim("Name", "model.name"));
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if(!ModelState.IsValid) {return View();}
            var result = await _signInManager.PasswordSignInAsync(model.username, model.password, model.rememberMe, false);
            
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}