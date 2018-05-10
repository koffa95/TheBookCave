using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;
        public BookRepo()
        {
            _db = new DataContext();
        }
        public List<BookListViewModel> GetAllBooks()
        {
            var books = (from b in _db.Books
                         join a in _db.Authors on b.authorId equals a.id
                         orderby b.title ascending
                         select new BookListViewModel
                         {
                              bookId = b.id,
                              title = b.title,
                              author = a.name,
                              authorId = a.id,
                              genre = b.genre,
                              releaseYear = b.releaseYear,
                              publisher = b.publisher,
                              translator = b.translator,
                              originalLanguage = b.originalLanguage,
                              language = b.language,
                              pages = b.pages,
                              price = b.price,
                              image = b.image,
                              shortDescription = b.shortDescription
                         }).ToList();

            return books;
        }
    }
}