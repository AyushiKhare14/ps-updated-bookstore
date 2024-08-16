using C_BookStoreBackEndAPI.Dtos.Book;
using C_BookStoreBackEndAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace C_BookStoreBackEndAPI.Dtos.Genre
{
    public class GenreWithBooksDto
    {
        public int Id { get; set; }

        public string GenreName { get; set; } = String.Empty;

        //public int NumberOfPointsOfInterest
        //{
        //    get
        //    {
        //        return PointsOfInterest.Count;
        //    }
        //}

        public ICollection<BookDto> Books { get; set; }
            = new List<BookDto>();
    }
}
