using AutoMapper;

using C_BookStoreBackEndAPI.Dtos.Author;

using C_BookStoreBackEndAPI.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace C_BookStoreBackEndAPI.Controllers
{
    /// <summary>
    /// Author Controller
    /// </summary>
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        
        /// <summary>
        /// Author Controller
        /// </summary>
        /// <param name="authorService"></param>
        
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        /// <summary>
        /// Get all the authors in Bookstore DB
        /// </summary>
        /// <returns>List of all authors</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var authorDto = await _authorService.GetAllAsync();

            return Ok(authorDto);
        }

        /// <summary>
        /// Get Author by author id
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns>Author</returns>
        [HttpGet("{authorId:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int authorId)
        {
            var authorDto = await _authorService.GetByIdAsync(authorId);

            return Ok(authorDto);
        }

        /// <summary>
        /// Create Author from the request body
        /// </summary>
        /// <param name="createAuthorDto">Create author request body</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAuthorDto createAuthorDto)
        {
            var authorDto = await _authorService.CreateAsync(createAuthorDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { authorId = authorDto.Id }, authorDto);
        }

        /// <summary>
        /// Update author from the object in the request body
        /// </summary>
        /// <param name="authorId">Author Id</param>
        /// <param name="updateAuthorDto">Update author request body</param>
        /// <returns></returns>
        [HttpPut("{authorId:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int authorId, [FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var author = await _authorService.GetByIdAsync(authorId);

            if (author == null)
            {
                return NotFound();
            }
            var authorUpdateStatus = await _authorService.UpdateAsync(authorId, updateAuthorDto);
            if (authorUpdateStatus == 0)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        //[HttpPatch("{id:int}")]
        //public IActionResult PartialUpdate([FromRoute] int id, JsonPatchDocument<UpdateAuthorDto> updateAuthorDto)
        //{

        //}   
        //[HttpPatch("{id:int}")]
        //public IActionResult PartialUpdate([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateAuthorDto> patchDoc)
        //{
        //    if (patchDoc == null)
        //    {
        //        return BadRequest();
        //    }

        //    var author = _context.Authors.Find(id);

        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    var authorToPatch = _mapper.Map<UpdateAuthorDto>(author); // Map the existing author to the DTO

        //    patchDoc.ApplyTo(authorToPatch, ModelState); // Apply the patch to the DTO

        //    if (!TryValidateModel(authorToPatch)) // Validate the patched DTO
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    _mapper.Map(authorToPatch, author); // Map the patched DTO back to the author entity

        //    _context.SaveChanges(); // Save changes to the database

        //    return NoContent();
        //}


        [HttpDelete("{authorId:int}")]

        public async Task<IActionResult> DeleteAsync([FromRoute] int authorId)
        {
            var author = await _authorService.GetByIdAsync(authorId);

            if (author == null)
            {
                return NotFound();
            }

            var isAuthorDeleteSuccess = await _authorService.DeleteAsync(authorId);

            return !isAuthorDeleteSuccess ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : NoContent();
        }
    }
}