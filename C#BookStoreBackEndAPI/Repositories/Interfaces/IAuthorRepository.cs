using C_BookStoreBackEndAPI.Models;

namespace C_BookStoreBackEndAPI.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        /// <summary>
        /// Retrieve all authors
        /// </summary>
        /// <returns>Returns all authors</returns>
        Task<List<Author>> GetAllAsync();

        /// <summary>
        /// Retrieve an author by its id
        /// </summary>
        /// <param name="authorId">authorId for author to be fetched</param>
        /// <returns>Returns author if found else returns not found</returns>
        Task<Author?> GetByIdAsync(int authorId);

        /// <summary>
        /// Creates a new author
        /// </summary>
        /// <param name="author">Author to be created</param>
        /// <returns>Returns newly generated author id</returns>
        Task<int> CreateAsync(Author author);

        /// <summary>
        /// Updates author by Id
        /// </summary>
        /// <param name="authorId">Author Id to be updated</param>
        /// <param name="author">Updated author</param>
        /// <returns>Return number of authors which gets updated.</returns>
        Task<int> UpdateAsync(int authorId, Author author);

        /// <summary>
        /// Deletes a author
        /// </summary>
        /// <param name="authorId">AuthorId for the author which is expected to delete</param>
        /// <returns>Returns bool value indicating success status of deleteing author</returns>
        Task<bool> DeleteAsync(int authorId);
    }
}
