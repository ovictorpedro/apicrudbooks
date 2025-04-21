using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class BookContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Books@321' -p 1200:1433 --name azures-books-db -d mcr.microsoft.com/azure-sql-edge
            optionsBuilder.UseSqlServer("Server=localhost,1200; Database=Library; User Id=sa; Password=Books@321; TrustServerCertificate=yes");
            base.OnConfiguring(optionsBuilder);
        }        
    }
}