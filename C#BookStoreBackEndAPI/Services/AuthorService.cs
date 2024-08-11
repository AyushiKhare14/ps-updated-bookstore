using AutoMapper;
using C_BookStoreBackEndAPI.Dtos.Author;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Repositories.Interfaces;
using C_BookStoreBackEndAPI.Services.Interfaces;

namespace C_BookStoreBackEndAPI.Services
{
    /// <summary>
    /// Class implementing methods for performing CRUD operations using Author Repository
    /// </summary>
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authorRepository">Author Repository object</param>
        /// <param name="mapper">Mapper object</param>
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            var authorId = await _authorRepository.CreateAsync(author);
            author.Id = authorId;
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int id)
        {
            var isAuthorDeleteSuccess = await _authorRepository.DeleteAsync(id);
            return isAuthorDeleteSuccess;
        }

        /// <inheritdoc/>
        public async Task<List<AuthorDto>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorDtoList = _mapper.Map<List<AuthorDto>>(authors);
            return authorDtoList;
        }

        /// <inheritdoc/>
        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var genre = await _authorRepository.GetByIdAsync(id);
            var genreDto = _mapper.Map<AuthorDto>(genre);
            return genreDto;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateAsync(int id, UpdateAuthorDto authorDto)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            var updatedAuthor = _mapper.Map(authorDto, author);
            var authorId = await _authorRepository.UpdateAsync(id, updatedAuthor);
            return authorId;
        }
    }
}
