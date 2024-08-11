using C_BookStoreBackEndAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace C_BookStoreBackEndAPI.Data
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {  }

        public virtual DbSet<Genre> Genres {  get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
