

using System.ComponentModel.DataAnnotations;

namespace C_BookStoreBackEndAPI.Dtos.Genre
{
    public class GenreDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Genre Name is required.")]
        [MinLength(2, ErrorMessage = "Genre Name must be atleast 2 characters long.")]
        [MaxLength(20, ErrorMessage = "Genre Name must not exceed 20 characters.")]
        public string GenreName { get; set; } = String.Empty;
    }
}
