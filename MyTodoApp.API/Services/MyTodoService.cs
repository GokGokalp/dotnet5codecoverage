using System;
using System.Threading.Tasks;
using MyTodoApp.API.Data;
using MyTodoApp.API.Models.Domain;
using MyTodoApp.API.Models.Requests;
using MyTodoApp.API.Models.Responses;

namespace MyTodoApp.API.Services
{
    public class MyTodoService : IMyTodoService
    {
        private readonly IMyTodoRepository _myTodoRepository;

        public MyTodoService(IMyTodoRepository myTodoRepository)
        {
            _myTodoRepository = myTodoRepository;
        }

        public async Task<CreateMyTodoResponse> CreateTodoAsync(CreateMyTodoRequest createMyTodoRequest)
        {
            if(string.IsNullOrEmpty(createMyTodoRequest.Name))
            {
                throw new ArgumentNullException($"{nameof(createMyTodoRequest.Name)} parameter should be provided.");
            }

            var myTodo = new MyTodo
            {
                Name = createMyTodoRequest.Name,
                Type = createMyTodoRequest.Type,
            };

            Guid createMyTodoResponse = await _myTodoRepository.CreateTodoAsync(myTodo);

            var response = new CreateMyTodoResponse
            {
                TodoId = createMyTodoResponse
            };

            return response;
        }
    }
}