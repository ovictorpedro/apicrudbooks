using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class BookContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=LocalDb/books.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}