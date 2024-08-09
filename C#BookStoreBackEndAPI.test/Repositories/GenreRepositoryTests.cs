
//using Xunit;
//using Moq;
//using C_BookStoreBackEndAPI.Repositories;
//using C_BookStoreBackEndAPI.Data;
//using C_BookStoreBackEndAPI.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Extensions.DependencyInjection;
//using System;

//namespace C_BookStoreBackEndAPI.test.Repositories
//{
//    public class GenreRepositoryTests
//    {
//        private readonly GenreRepository _genreRepository;
//        private readonly BookStoreDBContext _dataContext;
//        private readonly Mock<DbSet<Genre>> _dbSetMock;
//        private ServiceProvider _serviceProvider;


//        public GenreRepositoryTests()
//        {
//            var services = new ServiceCollection();

//            services.AddDbContext<BookStoreDBContext>(options =>

//                options.UseInMemoryDatabase("TestDb")
//            );
//            _serviceProvider = services.BuildServiceProvider();
//            // Set up a mock DbSet<Genre>
//            //_dbSetMock = new Mock<DbSet<Genre>>();

//            //// Set up a mock BookStoreDBContext
//            //var _dataContext = new DbContextOptions<BookStoreDBContext>(options => options.Use);
//            //_dataContext
//            //_genreRepository = new GenreRepository(_contextMock.Object);
//        }

//        [Fact]
//        public void Create_Genre_ShouldReturn_GenreId()
//        {
//            using(var scope = _serviceProvider.CreateScope())
//            {
//                //Arrange
//                var scoppedServices = scope.ServiceProvider;
//                var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
//                var genreRepository = new GenreRepository(dbContext);
//                var genre = new Genre { GenreName = "Fiction" };

//                //Act
//                var result = genreRepository.Create(genre);

//                //Assert
//                Assert.Equal(1, genre.Id);
//            }
//        }

//        [Fact]
//        public void Delete_Genre_ShouldReturn_True_WhenSuccessful()
//        {
//            // Arrange
//            var genre = new Genre { GenreName = "Fiction", Id = 1 };
//            _dbSetMock.Setup(m => m.Find(It.IsAny<int>())).Returns(genre);
//            _dbSetMock.Setup(m => m.Remove(It.IsAny<Genre>()));

//            // Act
//            var result = _genreRepository.Delete(genre.Id);

//            // Assert
//            Assert.True(result);
//        }

//        [Fact]
//        public void Delete_Genre_ShouldReturn_False_WhenUnsuccessful()
//        {
//            // Arrange
//            _dbSetMock.Setup(m => m.Find(It.IsAny<int>())).Returns((Genre)null);

//            // Act
//            var result = _genreRepository.Delete(999); // Non-existent ID

//            // Assert
//            Assert.False(result);
//        }

//        [Fact]
//        public void GetAll_Genres_ShouldReturn_ListOfGenres()
//        {
//            // Arrange
//            var genres = new List<Genre>
//            {
//                new Genre { GenreName = "Fiction" },
//                new Genre { GenreName = "Non-Fiction" }
//            }.AsQueryable();

//            _dbSetMock.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(genres.Provider);
//            _dbSetMock.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(genres.Expression);
//            _dbSetMock.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(genres.ElementType);
//            _dbSetMock.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(genres.GetEnumerator());

//            // Act
//            var result = _genreRepository.GetAll();

//            // Assert
//            Assert.Equal(2, result.Count);
//        }

//        [Fact]
//        public void GetById_Genre_ShouldReturn_Genre()
//        {
//            // Arrange
//            var genre = new Genre { GenreName = "Fiction", Id = 1 };
//            _dbSetMock.Setup(m => m.Find(It.IsAny<int>())).Returns(genre);

//            // Act
//            var result = _genreRepository.GetById(genre.Id);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal("Fiction", result.GenreName);
//        }

//        [Fact]
//        public void GetById_Genre_ShouldReturn_Null_IfNotFound()
//        {
//            // Arrange
//            _dbSetMock.Setup(m => m.Find(It.IsAny<int>())).Returns((Genre)null);

//            // Act
//            var result = _genreRepository.GetById(999); // Non-existent ID

//            // Assert
//            Assert.Null(result);
//        }

//        [Fact]
//        public void Update_Genre_ShouldReturn_SuccessfulStatus()
//        {
//            // Arrange
//            var genre = new Genre { GenreName = "Fiction", Id = 1 };
//            _dbSetMock.Setup(m => m.Find(It.IsAny<int>())).Returns(genre);

//            // Act
//            var result = _genreRepository.Update(genre.Id, genre);

//            // Assert
//            Assert.NotEqual(0, result);
//        }

//        [Fact]
//        public void Update_Genre_ShouldReturn_Zero_IfNotFound()
//        {
//            // Arrange
//            _dbSetMock.Setup(m => m.Find(It.IsAny<int>())).Returns((Genre)null);

//            // Act
//            var result = _genreRepository.Update(999, new Genre { GenreName = "Non-existent Genre" }); // Non-existent ID

//            // Assert
//            Assert.Equal(0, result);
//        }
//    }
//}


using Xunit;
using C_BookStoreBackEndAPI.Repositories;
using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace C_BookStoreBackEndAPI.test.Repositories
{
    public class GenreRepositoryTests
    {
        private ServiceProvider _serviceProvider;

        public GenreRepositoryTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<BookStoreDBContext>(options =>
                options.UseInMemoryDatabase("TestDb")
            );
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void Create_Genre_ShouldReturn_GenreId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var scoppedServices = scope.ServiceProvider;
                var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
                var genreRepository = new GenreRepository(dbContext);
                var genre = new Genre { GenreName = "Fiction" };

                // Act
                var result = genreRepository.Create(genre);

                // Assert
                Assert.Equal(genre.Id, result);
            }
        }

        [Fact]
        public void Delete_Genre_ShouldReturn_True_WhenSuccessful()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var scoppedServices = scope.ServiceProvider;
                var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
                var genreRepository = new GenreRepository(dbContext);
                var genre = new Genre { GenreName = "Fiction" };
                dbContext.Genres.Add(genre);
                dbContext.SaveChanges();

                // Act
                var result = genreRepository.Delete(genre.Id);

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        //public void Delete_Genre_ShouldReturn_False_WhenUnsuccessful()
        //{
        //    //using (var scope = _serviceProvider.CreateScope())
        //    //{
        //    //    // Arrange
        //    //    var scoppedServices = scope.ServiceProvider;
        //    //    var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
        //    //    var genreRepository = new GenreRepository(dbContext);
        //    //    var mockSet = new Mock<DbSet<Genre>>();
        //    //    mockSet.Setup(s => s.Find(It.IsAny<int>())).Returns(new Genre() { Id = 1, GenreName = "Fiction" });
        //    //    // Act
        //    //    var result = genreRepository.Delete(999); // Non-existent ID

        //    //    // Assert
        //    //    Assert.False(result);
        //    //}
        //    var mockSet = new Mock<DbSet<Genre>>();
        //    mockSet.Setup(s => s.Find(It.IsAny<int>())).Returns(new Genre() { Id = 1, GenreName = "Fiction" });

        //    var mockContext = new Mock<BookStoreDBContext>(MockBehavior.Strict);
        //    //mockContext.Setup(m => m.Genres).Returns(mockSet.Object);
        //    var genreRepository = new GenreRepository(mockContext.Object);
        //    var result = genreRepository.Delete(999); // Non-existent ID

        //    // Assert
        //    Assert.False(result);
        //}
        public void Delete_Genre_ShouldReturn_False_WhenUnsuccessful()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var scoppedServices = scope.ServiceProvider;
                var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
                var genreRepository = new GenreRepository(dbContext);

                // Act
                var result = genreRepository.Delete(999); // Non-existent ID

                // Assert
                Assert.False(result);
            }
        }

        [Fact]
        public void GetAll_Genres_ShouldReturn_ListOfGenres()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var scoppedServices = scope.ServiceProvider;
                var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
                var genreRepository = new GenreRepository(dbContext);
                dbContext.Genres.AddRange(
                    new Genre { GenreName = "Fiction" },
                    new Genre { GenreName = "Non-Fiction" }
                );
                dbContext.SaveChanges();

                // Act
                var result = genreRepository.GetAll();

                // Assert
                Assert.Equal(2, result.Count);
            }
        }

        [Fact]
        public void GetById_Genre_ShouldReturn_Genre()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var scoppedServices = scope.ServiceProvider;
                var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
                var genreRepository = new GenreRepository(dbContext);
                var genre = new Genre { GenreName = "Fiction" };
                dbContext.Genres.Add(genre);
                dbContext.SaveChanges();

                // Act
                var result = genreRepository.GetById(genre.Id);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Fiction", result.GenreName);
            }
        }

        [Fact]
        public void GetById_Genre_ShouldReturn_Null_IfNotFound()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var scoppedServices = scope.ServiceProvider;
                var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
                var genreRepository = new GenreRepository(dbContext);

                // Act
                var result = genreRepository.GetById(999); // Non-existent ID

                // Assert
                Assert.Null(result);
            }
        }

        [Fact]
        public void Update_Genre_ShouldReturn_SuccessfulStatus()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var scoppedServices = scope.ServiceProvider;
                var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
                var genreRepository = new GenreRepository(dbContext);
                var genre = new Genre { GenreName = "Fiction" };
                dbContext.Genres.Add(genre);
                dbContext.SaveChanges();

                genre.GenreName = "Updated Fiction";

                // Act
                var result = genreRepository.Update(genre.Id, genre);

                // Assert
                Assert.NotEqual(0, result);
            }
        }

        [Fact]
        public void Update_Genre_ShouldReturn_Zero_IfNotFound()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var scoppedServices = scope.ServiceProvider;
                var dbContext = scoppedServices.GetRequiredService<BookStoreDBContext>();
                var genreRepository = new GenreRepository(dbContext);

                // Act
                var result = genreRepository.Update(999, new Genre { GenreName = "Non-existent Genre" }); // Non-existent ID

                // Assert
                Assert.Equal(0, result);
            }
        }
    }
}

