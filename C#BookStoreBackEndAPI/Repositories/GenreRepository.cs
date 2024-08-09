using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Repositories.Interfaces;

namespace C_BookStoreBackEndAPI.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookStoreDBContext _context;
        public GenreRepository(BookStoreDBContext context)
        {
            _context = context;
        }

        public int Create(Genre genre)
        {
            _context.Genres.Add(genre);
            var createStatus = _context.SaveChanges();
            // return createStatus;
            return genre.Id;

        }

        public bool Delete(int id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null)
            {
                return false; // Entity doesn't exist, so return false
            }
            _context.Genres.Remove(genre);
            var success = _context.SaveChanges();
            return success != 0 ? true : false;
        }

        public List<Genre> GetAll()
        {
            var genres = _context.Genres.ToList();
            return genres;
        }

        public Genre? GetById(int id)
        {
            var genre = _context.Genres.Find(id);
            return genre;
        }

        public int Update( int id, Genre genre)
        {
            var genreFromDb = _context.Genres.Find(id);
            var updateStatus = 0;
            if (genreFromDb != null)
            {
                updateStatus = _context.SaveChanges();
            }
            return updateStatus;
        }
    }
}
