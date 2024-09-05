

using TodoApi.Model;

namespace TodoApi.Services.Interfaces
{
 
    public interface ITodoService
    {
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodoById(Guid id);
        void CreateTodo(Todo model);
        void UpdateTodo(Todo model);
        bool DeleteTodo(Guid id);
    }
}
