using C_BookStoreBackEndAPI.CustomException;
using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<int> CreateAsync(Genre genre)
        {
            try
            {
                ValidateEntity(genre);
                bool genreExists = _context.Genres.Any(g => g.GenreName.ToLower() == genre.GenreName.ToLower());

                if (genreExists)
                {
                    throw new InvalidOperationException("A genre with the same name already exists.");
                }
                _context.Genres.Add(genre);
                var createStatus = await _context.SaveChangesAsync();
                return genre.Id;
            }
            catch (ValidationException ex)
            {
          
                throw new InvalidOperationException($"Validation failed: {ex.Message}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int genreId)
        {
            try 
            { 
                // Check if any books are associated with the genre
                var isAssociatedWithBooks = _context.Books.Any(book => book.GenreId == genreId);
                if (isAssociatedWithBooks)
                {
                    return false; 
                }


                var genre = await _context.Genres.FindAsync(genreId);
                if (genre == null)
                {
                    return false; // Entity doesn't exist, so return false
                }
                _context.Genres.Remove(genre);
                var success = await _context.SaveChangesAsync();
                return success != 0 ? true : false;
            }
            catch (Exception)
            {
                throw ;
            }
        }

        /// <inheritdoc/>
        public async Task<List<Genre>> GetAllAsync()
        {
            try
            {
               //throw new InternalServerErrorException("CUSTOM EXCEPTION");
                var genres = await _context.Genres.ToListAsync();
                return genres;
            }
            catch (Exception) 
            {
                throw ;
            }
            
        }

        /// <inheritdoc/>
        public async Task<Genre?> GetByIdAsync(int genreId)
        {
            try
            {
                var genre = await _context.Genres.FindAsync(genreId);
                return genre;
            }
            catch (Exception)
            {
                throw ;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
         public async Task<Genre?> GetByIdWithBooksAsync(int genreId)
        {
            try
            {
                var genre = await _context.Genres.Include(b => b.Books)
                    .Where(b => b.Id == genreId).FirstOrDefaultAsync();
                return genre;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <inheritdoc/>
        public async Task<int> UpdateAsync( int genreId, Genre genre)
        {
            try
            {
                var genreFromDb = await _context.Genres.FindAsync(genreId);
                var updateStatus = 0;
                if (genreFromDb != null)
                {
                    updateStatus = await _context.SaveChangesAsync();
                }
                return updateStatus;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void ValidateEntity(Genre genre)
        {
            var validationContext = new ValidationContext(genre, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(genre, validationContext, validationResults, validateAllProperties: true);

            if (!isValid)
            {
                var errors = string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
                throw new ValidationException($"Validation failed: {errors}");
            }
        }
    }
}
