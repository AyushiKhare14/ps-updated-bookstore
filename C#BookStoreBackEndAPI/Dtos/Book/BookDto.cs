using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C_BookStoreBackEndAPI.Dtos.Book
{
    public class BookDto
    {

        public int Id { get; set; }
       
        public string Title { get; set; } = string.Empty;
      
        public decimal Price { get; set; }

        public DateOnly PublicationDate { get; set; } 

        public int GenreId { get; set; }

        public int AuthorId { get; set; }
    }
}
