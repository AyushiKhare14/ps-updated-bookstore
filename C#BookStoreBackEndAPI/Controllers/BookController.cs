using AutoMapper;
using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Dtos.Author;
using C_BookStoreBackEndAPI.Dtos.Book;
using C_BookStoreBackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace C_BookStoreBackEndAPI.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly BookStoreDBContext _context;
        public BookController(BookStoreDBContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList();

            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            _context.Books.Add(book);
            _context.SaveChanges();

            var bookDto = _mapper.Map<BookDto>(book);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, bookDto);

        }


        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateBookDto updateBookDto)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            _mapper.Map(updateBookDto, book);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();

        }
    }
}
