using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories
{
    public class CartRepo
    {
        private DataContext _db;
        public CartRepo()
        {
            _db = new DataContext();
        }
        public List<CartViewModel> GetCart()
        {
            var cart = (from c in _db.Cart
                        join b in _db.Books on c.bookId equals b.id
                        select new CartViewModel
                        {
                            id = c.id,
                            bookId = c.bookId,
                            book = b
                        }).ToList();

            return cart;
        }
    }
}