using C_BookStoreBackEndAPI.Models;

namespace C_BookStoreBackEndAPI.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGenreRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Genre> GetAll();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Genre? GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        int Create(Genre genre);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genre"></param>
        /// <returns></returns>
        int Update(int id, Genre genre);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
