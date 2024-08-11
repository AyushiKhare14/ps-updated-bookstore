using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Repositories;
using C_BookStoreBackEndAPI.test.Helpers;
using Moq;
using Moq.EntityFrameworkCore;

namespace C_BookStoreBackEndAPI.test.Repositories
{
    public class GenreRepositoryTests
    {
        private readonly Mock<BookStoreDBContext> _bookStoreDBContext;
        public GenreRepositoryTests()
        {
            _bookStoreDBContext = TestDataHelper.GetMockBookStoreDBContext();
        }

        [Fact]
        public async Task GetAll_WhenCalled_ReturnsGenreListAsync()
        {
            // Arrange
            var mockGenres = TestDataHelper.GetAllGenres();
            _bookStoreDBContext.Setup(x => x.Genres).ReturnsDbSet(mockGenres);
            var genreRepository = new GenreRepository(_bookStoreDBContext.Object);
            
            // Act
            var actualGenres = await genreRepository.GetAllAsync();

            // Assert
            Assert.NotNull(actualGenres);
            Assert.Equal(mockGenres.Count, actualGenres.Count);
        }

        [Fact]
        public async Task GetGenreByIdAsync_WhenCalled_ReturnsGenreAsync()
        {
            // Arrange
            var mockGenres = TestDataHelper.GetAllGenres();
            int genreId = 1;
            _bookStoreDBContext.Setup(x => x.Genres.FindAsync(genreId).Result).Returns(mockGenres.Find(g => g.Id == genreId) ?? null);

            var genreRepository = new GenreRepository(_bookStoreDBContext.Object);

            // Act
            var actualGenre = await genreRepository.GetByIdAsync(genreId);

            // Assert
            Assert.NotNull(actualGenre);
            Assert.Equal(genreId, actualGenre.Id);
        }

        [Fact]
        public async Task GetGenreByIdAsync_WhenCalled_ReturnsNullWhenGenreIdNotFound()
        {
            // Arrange
            var mockGenres = TestDataHelper.GetAllGenres();
            int genreId = 100;
            _bookStoreDBContext.Setup(x => x.Genres.FindAsync(genreId).Result).Returns(mockGenres.Find(g => g.Id == genreId) ?? null);

            var genreRepository = new GenreRepository(_bookStoreDBContext.Object);

            // Act
            var actualGenre = await genreRepository.GetByIdAsync(genreId);

            // Assert
            Assert.Null(actualGenre);
        }
    }
}