using Microsoft.EntityFrameworkCore;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Cart> Cart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder 
                .UseSqlServer(
                "server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H02;Persist Security Info=False;User ID=VLN2_2018_H02_usr;Password=2anyDust91;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
    }
}