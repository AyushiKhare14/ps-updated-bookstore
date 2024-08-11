using C_BookStoreBackEndAPI.Models;

namespace C_BookStoreBackEndAPI.Repositories.Interfaces
{
    /// <summary>
    /// Interface declaring methods for performing CRUD operations on Book Table
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Retrieve all books
        /// </summary>
        /// <returns>Returns all books</returns>
        Task<List<Book>> GetAllAsync();

        /// <summary>
        /// Retrieve a book by its id
        /// </summary>
        /// <param name="bookId">BookId for book to be fetched</param>
        /// <returns>Returns book if found else returns not found</returns>
        Task<Book?> GetByIdAsync(int bookId);

        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="book">Book to be created</param>
        /// <returns>Returns newly generated book id</returns>
        Task<int> CreateAsync(Book book);

        /// <summary>
        /// Updates book by Id
        /// </summary>
        /// <param name="bookId">Book Id to be updated</param>
        /// <param name="book">Updated book</param>
        /// <returns>Return number of books gets updated.</returns>
        Task<int> UpdateAsync(int bookId, Book book);

        /// <summary>
        /// Deletes a book
        /// </summary>
        /// <param name="bookId">BookId for the book which is expected to get delete</param>
        /// <returns>Returns bool value indicating success status of deleteing book</returns>
        Task<bool> DeleteAsync(int bookId);
    }
}
