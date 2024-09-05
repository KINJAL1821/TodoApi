using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Model;
using TodoApi.Services.Interfaces;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetAll()
        {
            return Ok(_todoService.GetAllTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetById(Guid id)
        {
            var todo = _todoService.GetTodoById(id);
            if (todo == null)
            {
                return BadRequest();
            }
            return Ok(todo);
        }

        [HttpPost]
        public ActionResult Create(Todo newItem)
        {
            _todoService.CreateTodo(newItem);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Todo updatedItem)
        {
            if (id != updatedItem.Id)
            {
                return BadRequest();
            }

            var existingTodo = _todoService.GetTodoById(id);
            if (existingTodo == null)
            {
                return BadRequest();
            }

            _todoService.UpdateTodo(updatedItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var success = _todoService.DeleteTodo(id);
            if (!success)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
