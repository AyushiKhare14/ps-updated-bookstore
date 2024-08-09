using AutoMapper;
using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Repositories.Interfaces;
using C_BookStoreBackEndAPI.Services.Interfaces;

namespace C_BookStoreBackEndAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public GenreDto Create(CreateGenreDto createGenreDto)
        {
            var genre = _mapper.Map<Genre>(createGenreDto);
            var genreId = _genreRepository.Create(genre);
            genre.Id = genreId;
            var genreDto = _mapper.Map<GenreDto>(genre);
            return genreDto;
        }

        public bool Delete(int id)
        {
            var isGenreDeleteSuccess = _genreRepository.Delete(id);
            return isGenreDeleteSuccess;
        }

        public IEnumerable<GenreDto> GetAll()
        {
            var genres = _genreRepository.GetAll();
            var genreDtoList = _mapper.Map<IEnumerable<GenreDto>>(genres);
            return genreDtoList;
        }

        public GenreDto? GetById(int id)
        {
            var genre = _genreRepository.GetById(id);
            var genreDto = _mapper.Map<GenreDto>(genre);
            return genreDto;
        }

        public int Update(int id, UpdateGenreDto genreDto)
        {
            var genre = _genreRepository.GetById(id);
            var updatedGenre = _mapper.Map(genreDto, genre);
            var genreId = _genreRepository.Update(id, updatedGenre);
            return genreId;
        }
    }
}
