using C_BookStoreBackEndAPI.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace C_BookStoreBackEndAPI.Dtos.Book
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Book title is required.")]
        [MinLength(1, ErrorMessage = "Book title must be atleast 1 characters long.")]
        [MaxLength(50, ErrorMessage = "Book title must not exceed 50 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Book price is required.")]
        [Range(1.0, 1000.0, ErrorMessage = "Book price must be between $1.0 and $1000.0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Publication date is required.")]
        [DateNotInFuture(ErrorMessage = "Publication date cannot be in the future.")]
        public DateOnly PublicationDate { get; set; }

        [Required(ErrorMessage = "Please select a genre for the book.")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Please select an author for the book.")]
        public int AuthorId { get; set; }
    }
}
