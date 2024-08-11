using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace C_BookStoreBackEndAPI.Controllers
{
    /// <summary>
    /// Genre Controller
    /// </summary>
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        
        /// <summary>
        /// Genre Controller
        /// </summary>
        /// <param name="genreService"></param>
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        
        /// <summary>
        /// Get all the genres in BookStore DB
        /// </summary>
        /// <returns>List of all the Genres.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        { 
            var genresDto = await _genreService.GetAllAsync();

           return Ok(genresDto);
        }

        /// <summary>
        /// Get Genre by genre id.
        /// </summary>
        /// <param name="genreId">Genre Id</param>
        /// <returns>Genre</returns>
        [HttpGet("{genreId:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int genreId) 
        {
            var genreDto = await _genreService.GetByIdAsync(genreId);
            
            return Ok(genreDto);
        }

        /// <summary>
        /// Create Genre from the request body
        /// </summary>
        /// <param name="createGenreDto">Create genre request body</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGenreDto createGenreDto)
        {
            var genreDto = await _genreService.CreateAsync(createGenreDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { genreId = genreDto.Id }, genreDto);
        }

        /// <summary>
        /// Update genre from the object in the request body 
        /// </summary>
        /// <param name="genreId">Genre Id</param>
        /// <param name="updateGenreDto">Update genre request body</param>
        /// <returns></returns>
        [HttpPut("{genreId:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int genreId, [FromBody] UpdateGenreDto updateGenreDto)
        {
            var genre = await _genreService.GetByIdAsync(genreId);

            if (genre == null)
            {
                return NotFound();
            }
            var genreUpdateStatus = await _genreService.UpdateAsync(genreId, updateGenreDto);
            if (genreUpdateStatus == 0)
            { 
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete Genre for given genre id.
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [HttpDelete("{genreId:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int genreId) 
        {
            var genre = await _genreService.GetByIdAsync(genreId);

            if (genre == null)
            {
                return NotFound();
            }

            var isGenreDeleteSuccess = await _genreService.DeleteAsync(genreId);

            return !isGenreDeleteSuccess ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : NoContent();
        }
    }
}
