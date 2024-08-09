using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Models;

namespace C_BookStoreBackEndAPI.Services.Interfaces
{
    public interface IGenreService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<GenreDto> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GenreDto? GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genreDto"></param>
        /// <returns></returns>
        GenreDto Create(CreateGenreDto genreDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genreDto"></param>
        /// <returns></returns>
        int Update(int id, UpdateGenreDto genreDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
