using System.Collections.Generic;

namespace TheBookCave.Data.EntityModels
{
    public class Cart
    {
        public int id {get;set;}
        public Book book {get; set;}
        public int bookId {get; set;}
    }
}    