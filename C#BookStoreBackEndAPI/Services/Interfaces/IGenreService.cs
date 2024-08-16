using C_BookStoreBackEndAPI.Dtos.Genre;

namespace C_BookStoreBackEndAPI.Services.Interfaces
{
    /// <summary>
    /// Interface declaring methods for performing CRUD operations using Genre Repository
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Retrieve all genere
        /// </summary>
        /// <returns>Returns all genere</returns>
        Task<List<GenreDto>> GetAllAsync();

        /// <summary>
        /// Retrieve a genere by its id
        /// </summary>
        /// <param name="genreId">GenreId for genre to be fetched</param>
        /// <returns>Returns genre if found else returns null</returns>
        Task<GenreDto?> GetByIdAsync(int genreId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        Task<GenreWithBooksDto?> GetByIdWithBooksAsync(int genreId);

        /// <summary>
        /// Creates a new genre
        /// </summary>
        /// <param name="genreDto">Genre to be created</param>
        /// <returns>Returns newly generated genre id</returns>
        Task<GenreDto> CreateAsync(CreateGenreDto genreDto);

        /// <summary>
        /// Updates genre by Id
        /// </summary>
        /// <param name="genreId">Genre Id to be updated</param>
        /// <param name="genreDto">Updated genre</param>
        /// <returns>Return number of genre gets updated.</returns>
        Task<int> UpdateAsync(int genreId, UpdateGenreDto genreDto);

        // <summary>
        /// Deletes a genre
        /// </summary>
        /// <param name="genreId">GenreId for the genre which is expected to get delete</param>
        /// <returns>Returns bool value indicating success status of deleteing genre</returns>
        Task<bool> DeleteAsync(int genreId);
    }
}
