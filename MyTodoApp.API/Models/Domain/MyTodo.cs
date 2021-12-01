using MyTodoApp.API.Common;

namespace MyTodoApp.API.Models.Domain
{
    public class MyTodo
    {
        public string Name { get; set; }
        public Constants.TodoTypeEnum Type { get; set; }
    }
}