using C_BookStoreBackEndAPI.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C_BookStoreBackEndAPI.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Book title is required.")]
        [MinLength(1, ErrorMessage = "Book title must be atleast 1 characters long.")]
        [MaxLength(50, ErrorMessage = "Book title must not exceed 50 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Book price is required.")]
        [Range(1.0, 1000.0, ErrorMessage = "Book price must be between $1.0 and $1000.0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Publication date is required.")]
        [DateNotInFuture(ErrorMessage = "Publication date cannot be in the future.")]
        public DateOnly PublicationDate { get; set; }

        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }

        [Required(ErrorMessage = "Please select a genre for the book.")]
        public int GenreId { get; set; }

        [ForeignKey("AuthorId")]

        public Author? Author { get; set; }

        [Required(ErrorMessage = "Please select an author for the book.")]
        public int AuthorId { get; set; }

        public Book() {}

        public Book(string bname, decimal pri, DateOnly pubDate)
        {
            Title = bname.ToUpper();
            Price = pri;
            PublicationDate = pubDate;
        }
    }
}
