using AutoMapper;
using C_BookStoreBackEndAPI.Models;

namespace C_BookStoreBackEndAPI.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Models.Genre, Dtos.Genre.GenreDto>();
            CreateMap<Dtos.Genre.CreateGenreDto, Models.Genre>();
            CreateMap<Dtos.Genre.UpdateGenreDto, Models.Genre>();
        }
    }
}
