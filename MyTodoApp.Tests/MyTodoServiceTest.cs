using System;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using MyTodoApp.API.Common;
using MyTodoApp.API.Data;
using MyTodoApp.API.Models.Domain;
using MyTodoApp.API.Models.Requests;
using MyTodoApp.API.Models.Responses;
using MyTodoApp.API.Services;
using Xunit;

namespace MyTodoApp.Tests
{
    public class MyTodoServiceTest
    {
        private Mock<IMyTodoRepository> _myTodoRepositoryMock;
        private Fixture _fixture;

        public MyTodoServiceTest()
        {
            _myTodoRepositoryMock = new Mock<IMyTodoRepository>();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task CreateTodo_WhenAUserWantsToCreateDailyTodo_CreateDailyTodoAndReturnItsId()
        {
            // Arrange
            var myTodoService = new MyTodoService(_myTodoRepositoryMock.Object);
            var todoTypeEnum = Constants.TodoTypeEnum.Daily;
            var todoId = _fixture.Create<Guid>();
            var createMyTodoRequest = new CreateMyTodoRequest
            {
                Name = _fixture.Create<string>(),
                Type = todoTypeEnum
            };
            var myTodo = new MyTodo
            {
                Name = createMyTodoRequest.Name,
                Type = createMyTodoRequest.Type
            };

            _myTodoRepositoryMock.Setup(m => m.CreateTodoAsync(It.IsAny<MyTodo>())).ReturnsAsync(todoId);

            // Act
            CreateMyTodoResponse createTodoResponse = await myTodoService.CreateTodoAsync(createMyTodoRequest);

            // Assert
            Assert.NotNull(createTodoResponse);
            Assert.Equal(createTodoResponse.TodoId, todoId);
            _myTodoRepositoryMock.Verify(m => m.CreateTodoAsync(It.Is<MyTodo>(mt => mt.Name == myTodo.Name && mt.Type == myTodo.Type)));
        }

        [Fact]
        public async Task CreateTodo_WhenAUserWantsToCreateDailyTodoWithoutProvidingName_ThrowArgumentNullException()
        {
            // Arrange
            var myTodoService = new MyTodoService(_myTodoRepositoryMock.Object);
            var todoTypeEnum = Constants.TodoTypeEnum.Daily;
            var createMyTodoRequest = new CreateMyTodoRequest
            {
                Name = string.Empty,
                Type = todoTypeEnum
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => myTodoService.CreateTodoAsync(createMyTodoRequest));
        }
    }
}