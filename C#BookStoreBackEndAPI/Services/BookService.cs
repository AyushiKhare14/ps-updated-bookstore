using AutoMapper;
using C_BookStoreBackEndAPI.Dtos.Book;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Repositories.Interfaces;
using C_BookStoreBackEndAPI.Services.Interfaces;

namespace C_BookStoreBackEndAPI.Services
{
    /// <summary>
    /// Class implementing methods for performing CRUD operations using Book Repository
    /// </summary>
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookRepository">Genre Repository object</param>
        /// <param name="mapper">Mapper object</param>
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<BookDto> CreateAsync(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            var bookId = await _bookRepository.CreateAsync(book);
            book.Id = bookId;
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int id)
        {
            var isBookDeleteSuccess = await _bookRepository.DeleteAsync(id);
            return isBookDeleteSuccess;
        }

        /// <inheritdoc/>
        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            var bookDtoList = _mapper.Map<List<BookDto>>(books);
            return bookDtoList;
        }

        /// <inheritdoc/>
        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateAsync(int id, UpdateBookDto bookDto)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            var updatedBook = _mapper.Map(bookDto, book);
            var bookId = await _bookRepository.UpdateAsync(id, updatedBook);
            return bookId;
        }

    }
}
