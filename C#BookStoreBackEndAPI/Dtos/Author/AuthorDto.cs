using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C_BookStoreBackEndAPI.Dtos.Author
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Biography { get; set; } = String.Empty;
    }
}
