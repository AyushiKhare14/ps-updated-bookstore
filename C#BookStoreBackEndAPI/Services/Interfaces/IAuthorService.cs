using C_BookStoreBackEndAPI.Dtos.Author;


namespace C_BookStoreBackEndAPI.Services.Interfaces
{
    /// <summary>
    /// Interface declaring methods for performing CRUD operations using Author Repository
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Retrieve all authors
        /// </summary>
        /// <returns>Returns all authors</returns>
        Task<List<AuthorDto>> GetAllAsync();

        /// <summary>
        /// Retrieve an author by its id
        /// </summary>
        /// <param name="authorId">AuthorId for author to be fetched</param>
        /// <returns>Returns author if found else returns not found</returns>
        Task<AuthorDto?> GetByIdAsync(int authorId);

        /// <summary>
        /// Creates a new author
        /// </summary>
        /// <param name="authorDto">Author to be created</param>
        /// <returns>Returns newly generated author id</returns>
        Task<AuthorDto> CreateAsync(CreateAuthorDto authorDto);

        /// <summary>
        /// Updates author by Id
        /// </summary>
        /// <param name="authorId">Author Id to be updated</param>
        /// <param name="authorDto">Updated author</param>
        /// <returns>Return number of authors gets updated.</returns>
        Task<int> UpdateAsync(int authorId, UpdateAuthorDto authorDto);

        /// <summary>
        /// Deletes an author
        /// </summary>
        /// <param name="authorId">AuthorId for the author which is expected to get delete</param>
        /// <returns>Returns bool value indicating success status of deleteing author</returns>
        Task<bool> DeleteAsync(int authorId);
    }
}
