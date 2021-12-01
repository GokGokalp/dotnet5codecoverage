using System;
using System.Threading.Tasks;
using MyTodoApp.API.Models.Domain;

namespace MyTodoApp.API.Data
{
    public class MyTodoRepository : IMyTodoRepository
    {
        public Task<Guid> CreateTodoAsync(MyTodo myTodo)
        {
            throw new NotImplementedException();
        }
    }
}