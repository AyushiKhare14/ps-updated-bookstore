using AutoMapper;

namespace C_BookStoreBackEndAPI.Profiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<Models.Author, Dtos.Author.AuthorDto>();
            CreateMap<Models.Author, Dtos.Author.UpdateAuthorDto>();
            CreateMap<Dtos.Author.CreateAuthorDto, Models.Author>();
            CreateMap<Dtos.Author.UpdateAuthorDto, Models.Author>();
        }
    }
}
