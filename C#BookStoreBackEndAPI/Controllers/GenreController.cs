using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger _logger;
        
        /// <summary>
        /// Genre Controller
        /// </summary>
        /// <param name="genreService"></param>
        public GenreController(IGenreService genreService, ILogger<GenreController> logger)
        {
            _genreService = genreService;
            _logger = logger;
        }
        
        /// <summary>
        /// Get all the genres in BookStore DB
        /// </summary>
        /// <returns>List of all the Genres.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        { 
            try
            {
                var genresDto = await _genreService.GetAllAsync();
                return Ok(genresDto);
            }
            catch (Exception ex) 
            {
                _logger.LogError("Getting all cities encountered exception", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// Get Genre by genre id.
        /// </summary>
        /// <param name="genreId">Genre Id</param>
        /// <returns>Genre</returns>
        [HttpGet("{genreId:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int genreId) 
        {
            try
            {
                var genreDto = await _genreService.GetByIdAsync(genreId);

                if (genreDto == null)
                {

                    return NotFound();
                }

                return Ok(genreDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Getting city encountered exception", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        

        /// <summary>
        /// Create Genre from the request body
        /// </summary>
        /// <param name="createGenreDto">Create genre request body</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGenreDto createGenreDto)
        {
            try
            {
                var genreDto = await _genreService.CreateAsync(createGenreDto);
                return Ok(genreDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Created new city encountered exception", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
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
            try
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
            catch (Exception ex)
            {
                _logger.LogError("Created new city encountered exception", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Delete Genre for given genre id.
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [HttpDelete("{genreId:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int genreId) 
        {
            try
            {
                var genre = await _genreService.GetByIdAsync(genreId);

                if (genre == null)
                {
                    return NotFound();
                }

                var isGenreDeleteSuccess = await _genreService.DeleteAsync(genreId);

                return !isGenreDeleteSuccess ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Created new city encountered exception", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
