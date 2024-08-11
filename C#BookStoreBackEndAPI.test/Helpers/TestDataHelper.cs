using C_BookStoreBackEndAPI.Data;
using C_BookStoreBackEndAPI.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace C_BookStoreBackEndAPI.test.Helpers
{
    public class TestDataHelper
    {
        public static DbContextOptions<BookStoreDBContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<BookStoreDBContext>()
            .UseInMemoryDatabase(databaseName: "TestInMemoryDb")
            .Options;
        }

        public static Mock<BookStoreDBContext> GetMockBookStoreDBContext()
        {
            var bookStoreContextMock = new Mock<BookStoreDBContext>(GetDbContextOptions());
            return bookStoreContextMock;
        }

        public static List<Genre> GetAllGenres()
        {
            return new List<Genre>()
            {
                new Genre() { Id = 1, GenreName = "Comedy" },
                new Genre() { Id = 1, GenreName = "Thriller" },
                new Genre() { Id = 1, GenreName = "Action" },
                new Genre() { Id = 1, GenreName = "Suspense" }
            };
        }
    }
}
