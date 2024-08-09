//using AutoMapper;
//using C_BookStoreBackEndAPI.Models;
//using C_BookStoreBackEndAPI.Repositories;
//using C_BookStoreBackEndAPI.Repositories.Interfaces;
//using C_BookStoreBackEndAPI.Services;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace C_BookStoreBackEndAPI.test.Services
//{
//    public class GenreServiceTests
//    {
//        private Mock<IGenreRepository> _genreRepositoryMock;
//        //private readonly GenreRepository _genreRepository;
//        private readonly GenreService _genreService;
//        public GenreServiceTests()
//        {
//            _genreRepositoryMock = new Mock<IGenreRepository>();
//            _genreService = new GenreService(_genreRepositoryMock.Object, new Mock<IMapper>().Object);
//        }

//        [Fact]
//        public void GetAll_ShouldReturn_AllGenres()
//        {
//            List<Genre> genres = new List<Genre>() 
//            {
//                new Genre() { Id = 1, GenreName = "Fiction" },
//                new Genre() { Id = 2, GenreName = "Comedy" }
//            };
//            _genreRepositoryMock.Setup(s => s.GetAll()).Returns(genres);

//            var result = _genreService.GetAll();

//            Assert.Equal(genres.Count, result.ToList().Count);
//        }
//    }
//}


using Xunit;
using Moq;
using C_BookStoreBackEndAPI.Services;
using C_BookStoreBackEndAPI.Repositories.Interfaces;
using C_BookStoreBackEndAPI.Dtos.Genre;
using C_BookStoreBackEndAPI.Models;
using AutoMapper;
using System.Collections.Generic;

namespace C_BookStoreBackEndAPI.test.Services
{
    public class GenreServiceTests
    {
        private readonly Mock<IGenreRepository> _genreRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GenreService _genreService;

        public GenreServiceTests()
        {
            _genreRepositoryMock = new Mock<IGenreRepository>();
            _mapperMock = new Mock<IMapper>();
            _genreService = new GenreService(_genreRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void Create_Genre_ShouldReturn_GenreDto()
        {
            // Arrange
            var createGenreDto = new CreateGenreDto { GenreName = "Fiction" };
            var genre = new Genre { GenreName = "Fiction", Id = 1 };
            var genreDto = new GenreDto { Id = 1, GenreName = "Fiction" };

            _mapperMock.Setup(m => m.Map<Genre>(It.IsAny<CreateGenreDto>())).Returns(genre);
            _genreRepositoryMock.Setup(r => r.Create(It.IsAny<Genre>())).Returns(1);
            _mapperMock.Setup(m => m.Map<GenreDto>(It.IsAny<Genre>())).Returns(genreDto);

            // Act
            var result = _genreService.Create(createGenreDto);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal("Fiction", result.GenreName);
        }

        [Fact]
        public void Delete_Genre_ShouldReturn_True_WhenSuccessful()
        {
            // Arrange
            _genreRepositoryMock.Setup(r => r.Delete(It.IsAny<int>())).Returns(true);

            // Act
            var result = _genreService.Delete(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_Genre_ShouldReturn_False_WhenUnsuccessful()
        {
            // Arrange
            _genreRepositoryMock.Setup(r => r.Delete(It.IsAny<int>())).Returns(false);

            // Act
            var result = _genreService.Delete(999);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAll_Genres_ShouldReturn_ListOfGenreDtos()
        {
            // Arrange
            var genres = new List<Genre>
            {
                new Genre { GenreName = "Fiction", Id = 1 },
                new Genre { GenreName = "Non-Fiction", Id = 2 }
            };
            var genreDtos = new List<GenreDto>
            {
                new GenreDto { GenreName = "Fiction", Id = 1 },
                new GenreDto { GenreName = "Non-Fiction", Id = 2 }
            };

            _genreRepositoryMock.Setup(r => r.GetAll()).Returns(genres);
            _mapperMock.Setup(m => m.Map<IEnumerable<GenreDto>>(It.IsAny<IEnumerable<Genre>>())).Returns(genreDtos);

            // Act
            var result = _genreService.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetById_Genre_ShouldReturn_GenreDto()
        {
            // Arrange
            var genre = new Genre { GenreName = "Fiction", Id = 1 };
            var genreDto = new GenreDto { GenreName = "Fiction", Id = 1 };

            _genreRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(genre);
            _mapperMock.Setup(m => m.Map<GenreDto>(It.IsAny<Genre>())).Returns(genreDto);

            // Act
            var result = _genreService.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Fiction", result.GenreName);
        }

        [Fact]
        public void GetById_Genre_ShouldReturn_Null_IfNotFound()
        {
            // Arrange
            _genreRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((Genre)null);

            // Act
            var result = _genreService.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Update_Genre_ShouldReturn_GenreId()
        {
            // Arrange
            var genre = new Genre { GenreName = "Fiction", Id = 1 };
            var updateGenreDto = new UpdateGenreDto { GenreName = "Updated Fiction" };

            _genreRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(genre);
            _mapperMock.Setup(m => m.Map(updateGenreDto, genre)).Returns(genre);
            _genreRepositoryMock.Setup(r => r.Update(It.IsAny<int>(), It.IsAny<Genre>())).Returns(1);

            // Act
            var result = _genreService.Update(1, updateGenreDto);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Update_Genre_ShouldReturn_Zero_IfNotFound()
        {
            // Arrange
            _genreRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((Genre)null);

            // Act
            var result = _genreService.Update(999, new UpdateGenreDto { GenreName = "Non-existent Genre" });

            // Assert
            Assert.Equal(0, result);
        }
    }
}

