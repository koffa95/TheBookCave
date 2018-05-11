using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheBookCave.Data.EntityModels;
using System;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class AuthorController: Controller
    {
        private AuthorService _authorService;
        public AuthorController()
        {
            _authorService = new AuthorService();
        }
        public IActionResult Index()
        {
            var authors = _authorService.GetAllAuthors();
            return View(authors);
        }
        public IActionResult Details(int id)
        {
            var author = _authorService.GetAllAuthors();
            if(id <= author.Count && id < 0)
            {
                var clickedAuthor = author.Where(h => h.authorId == id);
                if(clickedAuthor != null)
                {
                    return View(clickedAuthor.ToList());
                }
            }
            return View("NotFound");
        }
    }
}