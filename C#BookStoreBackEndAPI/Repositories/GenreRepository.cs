using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C_BookStoreBackEndAPI.Repositories
{
    /// <summary>
    /// Class defining methods for performing CRUD operations on Genre Table
    /// </summary>
    public class GenreRepository : IGenreRepository
    {
        private readonly BookStoreDBContext _context;

        /// <summary>
        /// Constructor with Db Context object
        /// </summary>
        /// <param name="context">Db Context object passed using DI</param>
        public GenreRepository(BookStoreDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<int> CreateAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            var createStatus = await _context.SaveChangesAsync();
            return genre.Id;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int genreId)
        {
            var genre = await _context.Genres.FindAsync(genreId);
            if (genre == null)
            {
                return false; // Entity doesn't exist, so return false
            }
            _context.Genres.Remove(genre);
            var success = await _context.SaveChangesAsync();
            return success != 0 ? true : false;
        }

        /// <inheritdoc/>
        public async Task<List<Genre>> GetAllAsync()
        {
            var genres = await _context.Genres.ToListAsync();
            return genres;
        }

        /// <inheritdoc/>
        public async Task<Genre?> GetByIdAsync(int genreId)
        {
            var genre = await _context.Genres.FindAsync(genreId);
            return genre;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateAsync( int genreId, Genre genre)
        {
            var genreFromDb = await _context.Genres.FindAsync(genreId);
            var updateStatus = 0;
            if (genreFromDb != null)
            {
                updateStatus = await _context.SaveChangesAsync();
            }
            return updateStatus;
        }
    }
}
