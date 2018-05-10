using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheBookCave.Data.EntityModels;
using System;
using TheBookCave.Services;
using System.Collections.Generic;

namespace TheBookCave.Controllers
{
    public class BookController: Controller
    {
        private BookService _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }
        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        
        }
        public IActionResult Details(int id)
        {
            var model = _bookService.GetAllBooks();
            if(id <= model.Count && id > 0)
            {
                var clickedBook = model.Where(h => h.bookId == id);
                if(clickedBook != null)
                {
                    return View(clickedBook.ToList());
                }
            }
            return View("NotFound");
        }
    }
}    