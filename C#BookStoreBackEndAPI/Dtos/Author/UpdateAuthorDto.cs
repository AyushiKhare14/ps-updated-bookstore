using System.ComponentModel.DataAnnotations;

namespace C_BookStoreBackEndAPI.Dtos.Author
{
    public class UpdateAuthorDto
    {
        [Required(ErrorMessage = "Author Name is required.")]
        [MinLength(2, ErrorMessage = "Author Name must be atleast 2 characters long.")]
        [MaxLength(30, ErrorMessage = "Author Name must not exceed 30 characters.")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "Author bio is required.")]
        [MinLength(5, ErrorMessage = "Author bio must be atleast 5 characters long.")]
        [MaxLength(256, ErrorMessage = "Author bio must not exceed 256 characters.")]
        public string Biography { get; set; } = String.Empty;
    }
}
