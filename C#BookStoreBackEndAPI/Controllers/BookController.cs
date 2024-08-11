using AutoMapper;
using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Dtos.Author;
using C_BookStoreBackEndAPI.Dtos.Book;
using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Services;
using C_BookStoreBackEndAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace C_BookStoreBackEndAPI.Controllers
{
    /// <summary>
    /// Book Controller
    /// </summary>
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
       
        /// <summary>
        /// Book Controller
        /// </summary>
        /// <param name="bookService"></param>
        public BookController(IBookService bookService) 
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Get all the books in BookStore DB
        /// </summary>
        /// <returns>List of all the Books.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var bookDto = await _bookService.GetAllAsync();

            return Ok(bookDto);
        }

        /// <summary>
        /// Get Book by book id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>Book</returns>
        [HttpGet("{bookId:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int bookId)
        {
            var bookDto = await _bookService.GetByIdAsync(bookId);

            return Ok(bookDto);
        }

        /// <summary>
        /// Create Book from the request body
        /// </summary>
        /// <param name="createBookDto">Create book request body</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookDto createBookDto)
        {
            var bookDto = await _bookService.CreateAsync(createBookDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { bookId = bookDto.Id }, bookDto);
        }

        /// <summary>
        /// Update book from the object in the request body 
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <param name="updateBookDto">Update book request body</param>
        /// <returns></returns>
        [HttpPut("{bookId:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int bookId, [FromBody] UpdateBookDto updateBookDto)
        {
            var book = await _bookService.GetByIdAsync(bookId);

            if (book == null)
            {
                return NotFound();
            }
            var bookUpdateStatus = await _bookService.UpdateAsync(bookId, updateBookDto);
            if (bookUpdateStatus == 0)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete Book for given genre id.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete("{bookId:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int bookId)
        {
            var book = await _bookService.GetByIdAsync(bookId);

            if (book == null)
            {
                return NotFound();
            }

            var isBookDeleteSuccess = await _bookService.DeleteAsync(bookId);

            return !isBookDeleteSuccess ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : NoContent();
        }
    }
}
