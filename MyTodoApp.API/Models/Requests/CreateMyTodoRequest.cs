using MyTodoApp.API.Common;

namespace MyTodoApp.API.Models.Requests
{
        public class CreateMyTodoRequest
    {
        public string Name { get; set; }
        public Constants.TodoTypeEnum Type { get; set; }
    }
}