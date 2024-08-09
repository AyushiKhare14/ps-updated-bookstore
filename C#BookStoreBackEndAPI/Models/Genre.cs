using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C_BookStoreBackEndAPI.Models
{
    [Table ("genres")]
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Genre Name is required.")]
        [MinLength(2, ErrorMessage = "Genre Name must be atleast 2 characters long.")]
        [MaxLength(20, ErrorMessage = "Genre Name must not exceed 20 characters.")]
        public string GenreName { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book> ();

        public Genre() { }
        public Genre(string gname)
        {
            GenreName = gname.ToUpper();
        }

    }
}
