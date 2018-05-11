using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services
{
    public class CartService
    {
        private CartRepo _cartRepo;
        public CartService()
        {
            _cartRepo = new CartRepo();
        }
        public List<CartViewModel> GetCart()
        {
            var cart = _cartRepo.GetCart();
            return cart; 
        }
    }
}