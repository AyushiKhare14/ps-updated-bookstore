using AutoMapper;
using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Dtos.Author;
using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_BookStoreBackEndAPI.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = _context.Authors.ToList();

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authors));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AuthorDto>(author));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAuthorDto createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            _context.Authors.Add(author);
            _context.SaveChanges();

            var authorDto = _mapper.Map<AuthorDto>(author);

            return CreatedAtAction(nameof(GetById), new { id = author.Id }, authorDto);

        }


        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            _mapper.Map(updateAuthorDto, author);

            _context.SaveChanges();

            return NoContent();
        }

        //[HttpPatch("{id:int}")]
        //public IActionResult PartialUpdate([FromRoute] int id, JsonPatchDocument<UpdateAuthorDto> updateAuthorDto)
        //{

        //}   
        [HttpPatch("{id:int}")]
        public IActionResult PartialUpdate([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateAuthorDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            var authorToPatch = _mapper.Map<UpdateAuthorDto>(author); // Map the existing author to the DTO

            patchDoc.ApplyTo(authorToPatch, ModelState); // Apply the patch to the DTO

            if (!TryValidateModel(authorToPatch)) // Validate the patched DTO
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(authorToPatch, author); // Map the patched DTO back to the author entity

            _context.SaveChanges(); // Save changes to the database

            return NoContent();
        }


        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return NoContent();

        }
    }
}