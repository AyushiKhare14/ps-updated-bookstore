using C_BookStoreBackEndAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace C_BookStoreBackEndAPI.Data
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        public DbSet<Genre> Genres {  get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
