using AutoMapper;

namespace C_BookStoreBackEndAPI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Models.Book, Dtos.Book.BookDto>();
            CreateMap<Dtos.Book.CreateBookDto, Models.Book>();
            CreateMap<Dtos.Book.UpdateBookDto, Models.Book>();
        }
    }
}
