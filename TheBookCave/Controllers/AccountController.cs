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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel _register)
        {
            if(!ModelState.IsValid) {return View();}
            var user = new ApplicationUser { UserName = _register.username};
            var result = await _userManager.CreateAsync(user, _register.password);
            if(!result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("Name", "_register.name"));
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}