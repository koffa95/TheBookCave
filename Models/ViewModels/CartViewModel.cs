using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels
{
    public class CartViewModel
    {
        public int id {get; set;}
        public int bookId {get; set;}
        public Book book {get; set;}
    }
}    