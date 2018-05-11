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
                var clickedBook = model.Where(h => h.bookId == id).ToList();
                if(clickedBook != null)
                {
                    return View(clickedBook);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Index(string SearchText)
        {
            var model = _bookService.GetAllBooks();
            if(!string.IsNullOrEmpty(SearchText))
            {
                var result = model.Where
                (m => m.title.IndexOf(SearchText, System.StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                return View(result);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Filter([FromQuery] int filter)
        {
            var model = _bookService.GetAllBooks();
           if(filter == 1)
            {
                model = model.OrderBy(x => x.title).ToList();
            }
            else if(filter == 2)
            {
                model = model.OrderBy(x => x.author).ToList();
            }
            else{
                model = model.OrderBy(x => x.price).ToList();
            }

            return View("Index", model);
        }
         [HttpGet]
        public ActionResult FilterGenre([FromQuery] int filter)
        {
            var model = _bookService.GetAllBooks();
           if(filter == 1)
            {
                model = model.Where( x => x.genre.Contains("adventure")).ToList();
            }
            else if(filter == 2)
            {
                model = model.Where( x => x.genre.Contains("children")).ToList();
            }
            else if(filter == 3)
            {
                model = model.Where( x => x.genre.Contains("crime")).ToList();
            }
            else if(filter == 4)
            {
                model = model.Where( x => x.genre.Contains("fantasy")).ToList();
            }
            else if(filter == 5)
            {
                model = model.Where( x => x.genre.Contains( "fiction")).ToList();
            }
            else if(filter == 6)
            {
                model = model.Where( x => x.genre.Contains( "fun" )).ToList();
            }
            else if(filter == 7)
            {
                model = model.Where( x => x.genre.Contains("technicalBook" )).ToList();
            }
            else if(filter == 8)
            {
                model = model.Where( x => x.genre.Contains( "thriller")).ToList();
            }
            else if(filter == 9)
            {
                model = model.Where( x => x.genre.Contains("translated")).ToList();
            }
            else if(filter == 10)
            {
                model = model.Where( x => x.genre.Contains("youngAdult")).ToList();
            }

            return View("Index", model);
        }

    }
}    