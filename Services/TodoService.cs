
using TodoApi.Model;
using TodoApi.Services.Interfaces;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<Todo> _Todos = new List<Todo>
        {
            new Todo
            {
                Id=Guid.Parse("1c9a3b5d-2d16-4dbe-9b2a-fd2c6d1a9f13"),
                Description="description 1",
                Title="Title 1",
                Status=TodoStatus.Incompleted
            },
            new Todo
            {
                Id=Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Description="description 2",
                Title="Title 2",
                Status=TodoStatus.Completed
            },
        };

        public IEnumerable<Todo> GetAllTodos() 
        {
            return _Todos;
        }

        public Todo GetTodoById(Guid id) 
        {
            return _Todos.FirstOrDefault(t => t.Id == id); 
        }

        public void CreateTodo(Todo model)
        {
            model.Id = Guid.NewGuid();
            _Todos.Add(model);
        }

        public void UpdateTodo(Todo model)
        {
            var existingItem = GetTodoById(model.Id);
            if (existingItem != null)
            {
                existingItem.Title = model.Title;
                existingItem.Description = model.Description;
                existingItem.Status = model.Status;
            }
        }

        public bool DeleteTodo(Guid id)
        {
            var item = GetTodoById(id);
            return item != null && _Todos.Remove(item);
        }
    }

}
