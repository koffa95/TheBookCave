using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class MyCaveController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private CartService _cartService;
        public MyCaveController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _cartService = new CartService();
            _signInManager = signInManager;
            _userManager = userManager;
        }
       [HttpPost]
        public ActionResult AddToCart(int bookId)
        {
            var newCart = new Cart() { bookId = bookId };
           
            var db = new DataContext();

            db.Add(newCart);
            db.SaveChanges();
            return this.Json(new { success = true });
        }
        public ActionResult RemoveFromCart(int bookId)
        {

            var newCart = new Cart() { bookId = bookId };
           
            var db = new DataContext();

            db.Remove(newCart);
            db.SaveChanges();
            return this.Json(new { success = true });
            
        }
        public ActionResult EmptyCart()
        {
           
            var db = new DataContext();

            db.Cart.RemoveRange();
            db.SaveChanges();
            return RedirectToAction("Cart", "MyCave" );
            
        }
        public IActionResult Cart()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }
       
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if(!ModelState.IsValid) {return View();}
            var user = new ApplicationUser {UserName = model.username};
            var result = await _userManager.CreateAsync(user, model.password);
            if(!result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("Name", "model.name"));
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("SignUp", "MyCave");
            }
            return View();
        }
    }
}
