using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C_BookStoreBackEndAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDBContext _context;

        /// <summary>
        /// Constructor with Db Context object
        /// </summary>
        /// <param name="context">Db Context object passed using DI</param>
        public AuthorRepository(BookStoreDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<int> CreateAsync(Author author)
        {
            _context.Authors.Add(author);
            var createStatus = await _context.SaveChangesAsync();
            return author.Id;

        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if (author == null)
            {
                return false; // Entity doesn't exist, so return false
            }
            _context.Authors.Remove(author);
            var success = await _context.SaveChangesAsync();
            return success != 0 ? true : false;
        }

        /// <inheritdoc/>
        public async Task<List<Author>> GetAllAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

        /// <inheritdoc/>
        public async Task<Author?> GetByIdAsync(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            return author;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateAsync(int authorId, Author author)
        {
            var authorFromDb = await _context.Authors.FindAsync(authorId);
            var updateStatus = 0;
            if (authorFromDb != null)
            {
                updateStatus = await _context.SaveChangesAsync();
            }
            return updateStatus;
        }
    }
}
