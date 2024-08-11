using C_BookStoreBackEndAPI.Dtos.Book;

namespace C_BookStoreBackEndAPI.Services.Interfaces
{
    /// <summary>
    /// Interface declaring methods for performing CRUD operations using Book Repository
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Retrieve all books
        /// </summary>
        /// <returns>Returns all books</returns>
        Task<List<BookDto>> GetAllAsync();

        /// <summary>
        /// Retrieve a book by its id
        /// </summary>
        /// <param name="bookId">BookId for book to be fetched</param>
        /// <returns>Returns book if found else returns not found</returns>
        Task<BookDto?> GetByIdAsync(int bookId);

        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="bookDto">Book to be created</param>
        /// <returns>Returns newly generated book id</returns>
        Task<BookDto> CreateAsync(CreateBookDto bookDto);

        /// <summary>
        /// Updates book by Id
        /// </summary>
        /// <param name="bookId">Book Id to be updated</param>
        /// <param name="bookDto">Updated book</param>
        /// <returns>Return number of genre gets updated.</returns>
        Task<int> UpdateAsync(int bookId, UpdateBookDto bookDto);

        // <summary>
        /// Deletes a book
        /// </summary>
        /// <param name="bookId">BookId for the book which is expected to get delete</param>
        /// <returns>Returns bool value indicating success status of deleteing book</returns>
        Task<bool> DeleteAsync(int bookId);
    }
}
