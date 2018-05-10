using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;

namespace TheBookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()
        {
            var db = new DataContext();

            if(!db.Authors.Any())
            {
                var initialAuthors = new List<Author>
                {
                    new Author { name = "Halldor Laxness", age = 96, alive = false},
                    new Author { name = "Arnaldur Indridason", age = 57, alive = true},
                    new Author { name = "Audur Ava Olafsdottir", age = 60, alive = true},
                    new Author { name = "William Shakespeare", age = 52, alive = false},
                    new Author { name = "J.R.R. Tolkien", age = 81, alive = false}
                };

                db.AddRange(initialAuthors);
                db.SaveChanges();
            }
            if(!db.Books.Any())
            {
                var initialBooks = new List<Book>
                {
                    new Book { title = "Salka Valka", authorId = 1, genre = "fiction", releaseYear = 1931 , publisher = "Vaka Helgfell", translator = "none", originalLanguage = "Icelandic", language = "Icelandic", pages = 451, price = 2699 },
                    new Book { title = "Macbeth", authorId = 4, genre = "play", releaseYear = 1623 , publisher = "XXX", translator = "none", originalLanguage = "English", language = "english", pages = 73, price = 3000 }
                };

                db.AddRange(initialBooks);
                db.SaveChanges();
            }
            if(!db.Users.Any())
            {
                var initialUser = new List<User>
                {
                    new User { username = "Group2", password = "admin", staff = true },
                };

                db.AddRange(initialUser);
                db.SaveChanges();
            }
        }
    }
}
