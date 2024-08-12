using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C_BookStoreBackEndAPI.Repositories
{
    /// <summary>
    /// Class defining methods for performing CRUD operations on Book Table
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDBContext _context;

        /// <summary>
        /// Constructor with Db Context object
        /// </summary>
        /// <param name="context">Db Context object passed using DI</param>
        public BookRepository(BookStoreDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        /// <inheritdoc/>
        public async Task<int> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            var createStatus = await _context.SaveChangesAsync();
            return book.Id;

        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                return false; 
            }
            _context.Books.Remove(book);
            var success = await _context.SaveChangesAsync();
            return success != 0 ? true : false;
        }

        /// <inheritdoc/>
        public async Task<List<Book>> GetAllAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        /// <inheritdoc/>
        public async Task<Book?> GetByIdAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            return book;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateAsync(int bookId, Book book)
        {
            var bookFromDb = await _context.Books.FindAsync(bookId);
            var updateStatus = 0;
            if (bookFromDb != null)
            {
                updateStatus = await _context.SaveChangesAsync();
            }
            return updateStatus;
        }
    }
}
