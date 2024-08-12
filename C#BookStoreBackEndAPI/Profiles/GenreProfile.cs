using AutoMapper;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Dtos.Genre;

namespace C_BookStoreBackEndAPI.Profiles
{
    /// <summary>
    /// Genre Mappings
    /// </summary>
    public class GenreProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>();
        }
    }
}
