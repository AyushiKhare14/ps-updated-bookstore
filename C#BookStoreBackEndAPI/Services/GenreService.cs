﻿using AutoMapper;
using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Models;
using C_BookStoreBackEndAPI.Repositories.Interfaces;
using C_BookStoreBackEndAPI.Services.Interfaces;

namespace C_BookStoreBackEndAPI.Services
{
    /// <summary>
    /// Class implementing methods for performing CRUD operations using Genre Repository
    /// </summary>
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="genreRepository">Genre Repository object</param>
        /// <param name="mapper">Mapper object</param>
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<GenreDto> CreateAsync(CreateGenreDto createGenreDto)
        {
            var genre = _mapper.Map<Genre>(createGenreDto);
            var genreId = await _genreRepository.CreateAsync(genre);
            genre.Id = genreId;
            var genreDto = _mapper.Map<GenreDto>(genre);
            return genreDto;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int id)
        {
            var isGenreDeleteSuccess = await _genreRepository.DeleteAsync(id);
            return isGenreDeleteSuccess;
        }

        /// <inheritdoc/>
        public async Task<List<GenreDto>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            var genreDtoList = _mapper.Map<List<GenreDto>>(genres);
            return genreDtoList;
        }

        /// <inheritdoc/>
        public async Task<GenreDto?> GetByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            var genreDto = _mapper.Map<GenreDto>(genre);
            return genreDto;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateAsync(int id, UpdateGenreDto genreDto)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            var updatedGenre = _mapper.Map(genreDto, genre);
            var genreId = await _genreRepository.UpdateAsync(id, updatedGenre);
            return genreId;
        }
    }
}
