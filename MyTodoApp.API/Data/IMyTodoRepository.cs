using System;
using System.Threading.Tasks;
using MyTodoApp.API.Models.Domain;

namespace MyTodoApp.API.Data
{
    public interface IMyTodoRepository
    {
        Task<Guid> CreateTodoAsync(MyTodo myTodo);
    }
}