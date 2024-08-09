using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace C_BookStoreBackEndAPI.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        /// <summary>
        /// Get all the genres in BookStore DB
        /// </summary>
        /// <returns>List of all the Genres.</returns>
        [HttpGet]
        public IActionResult GetAll()
        { 
            var genresDto = _genreService.GetAll();

           return Ok(genresDto);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            var genreDto = _genreService.GetById(id);
            
            return Ok(genreDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateGenreDto createGenreDto)
        {
            var genreDto = _genreService.Create(createGenreDto);
            return CreatedAtAction(nameof(GetById), new { id = genreDto.Id }, genreDto);
        }


        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateGenreDto updateGenreDto)
        {
            var genre = _genreService.GetById(id);

            if (genre == null)
            {
                return NotFound();
            }
            var genreId = _genreService.Update(id, updateGenreDto);
            if (genreId == 0)
            { 
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id) 
        {
            var genre = _genreService.GetById(id);

            if (genre == null)
            {
                return NotFound();
            }

            var isGenreDeleteSuccess = _genreService.Delete(id);

            return !isGenreDeleteSuccess ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : NoContent();
        }
    }

}
