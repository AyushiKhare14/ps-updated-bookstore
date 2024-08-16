using C_BookStoreBackEndAPI.Models;

namespace C_BookStoreBackEndAPI.Repositories.Interfaces
{
    /// <summary>
    /// Interface declaring methods for performing CRUD operations on Genre Table
    /// </summary>
    public interface IGenreRepository
    {
        /// <summary>
        /// Retrieve all genere
        /// </summary>
        /// <returns>Returns all genres</returns>
        Task<List<Genre>> GetAllAsync();

        /// <summary>
        /// Retrieve a genere by its id
        /// </summary>
        /// <param name="genreId">GenreId for genre to be fetched</param>
        /// <returns>Returns genre if found else returns null</returns>
        Task<Genre?> GetByIdAsync(int genreId);

        /// <summary>
        /// Retrieves Books with genre
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        Task<Genre?> GetByIdWithBooksAsync(int genreId);

        /// <summary>
        /// Creates a new genre
        /// </summary>
        /// <param name="genre">Genre to be created</param>
        /// <returns>Returns newly generated genre id</returns>
        Task<int> CreateAsync(Genre genre);

        /// <summary>
        /// Updates genre by Id
        /// </summary>
        /// <param name="genreId">Genre Id to be updated</param>
        /// <param name="genre">Updated genre</param>
        /// <returns>Return number of genre gets updated.</returns>
        Task<int> UpdateAsync(int genreId, Genre genre);

        /// <summary>
        /// Deletes a genre
        /// </summary>
        /// <param name="genreId">GenreId for the genre which is expected to get delete</param>
        /// <returns>Returns bool value indicating success status of deleteing genre</returns>
        Task<bool> DeleteAsync(int genreId);
    }
}
