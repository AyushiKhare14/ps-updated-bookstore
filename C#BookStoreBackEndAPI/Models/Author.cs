using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C_BookStoreBackEndAPI.Models
{
    [Table("authors")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("AuthorName")]
        [Required(ErrorMessage ="Author Name is required.")]
        [MinLength(2, ErrorMessage ="Author Name must be atleast 2 characters long.")]
        [MaxLength(30, ErrorMessage ="Author Name must not exceed 30 characters.")]
        public string Name { get; set; }

        [Column("Biography")]
        [Required(ErrorMessage = "Author bio is required.")]
        [MinLength(5, ErrorMessage = "Author bio must be atleast 5 characters long.")]
        [MaxLength(256, ErrorMessage = "Author bio must not exceed 256 characters.")]
        public string Biography { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

        // Parameterless constructor required by EF Core
        public Author() { }

        // Your custom constructor
        public Author(string aname, string bio)
        {
            Name = aname.ToUpper();
            Biography = bio;
        }
    }
}

