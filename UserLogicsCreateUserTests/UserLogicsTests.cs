using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using UserManagement.Application.Logics.Implementations;
using UserManagement.Application.Logics.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Shared.DOTs.RequestDTO;

namespace UserLogicsCreateUserTests
{
    public class UserLogicsTests
    {
        private readonly Mock<WriteAppDbContext> _mockWriteContext;
        private readonly Mock<ILogger<UserLogics>> _mockLogger;
        private readonly IUserLogics _userLogics;

        public UserLogicsTests()
        {
            var options = new DbContextOptionsBuilder<WriteAppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
            _userLogics = new UserLogics(_mockWriteContext.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateUser_ValidRequest_ReturnsSuccess()
        {
            // Arrange
            var request = new CreateUserRequest
            {
                Username = "testuser",
                FirstName = "Test",
                LastName = "User",
                Email = "testuser@example.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
                PhoneNumber = "1234567890"
            };


            // Act
            var result = await _userLogics.CreateUser(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.Code);
            Assert.Equal("User Created Successfully", result.Message);
            _mockWriteContext.Verify(x => x.Users.Add(It.IsAny<User>()), Times.Once);
            _mockWriteContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }
    }
}