using System.Threading.Tasks;
using MyTodoApp.API.Models.Requests;
using MyTodoApp.API.Models.Responses;

namespace MyTodoApp.API.Services
{
    public interface IMyTodoService
    {
        Task<CreateMyTodoResponse> CreateTodoAsync(CreateMyTodoRequest createMyTodoRequest);
    }
}