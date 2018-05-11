using Microsoft.AspNetCore.Mvc;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class CartController : Controller
    {
        private CartService _cartService;
        public MyCaveController()
        {
            _cartService = new CartService();
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
            return RedirectToAction("Cart", "Cart" );
            
        }
        public IActionResult Cart()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }
    }
}
