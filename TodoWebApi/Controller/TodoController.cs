using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebApi.Model;

namespace TodoWebApi.Controller
{
    [Route("/todoitems")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private TodoDb db;
        
        public TodoController(TodoDb db)
        {
            this.db = db;
        }
        
        [HttpGet]
        public async Task<IResult> GetAllTodo()
        {
            return TypedResults.Ok(await db.Todos.Select(x => new TodoItemDTO(x)).ToArrayAsync());
        }
        
        [HttpGet("complete")]
        public async Task<IResult> GetCompleteTodo() {
            return TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).Select(x => new TodoItemDTO(x)).ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<IResult> GetTodo(int id)
        {
            return await db.Todos.FindAsync(id)
                is Todo todo
                    ? TypedResults.Ok(new TodoItemDTO(todo))
                    : TypedResults.NotFound();
        }
        
        [HttpPost]
        public async Task<IResult> CreateTodo(TodoItemDTO todoItemDTO)
        {
            var todoItem = new Todo
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };
        
            db.Todos.Add(todoItem);
            await db.SaveChangesAsync();
        
            todoItemDTO = new TodoItemDTO(todoItem);
        
            return TypedResults.Created($"/todoitems/{todoItem.Id}", todoItemDTO);
        }
        
        [HttpPut("{id}")]
        public async Task<IResult> UpdateTodo(int id, TodoItemDTO todoItemDTO)
        {
            var todo = await db.Todos.FindAsync(id);
        
            if (todo is null) return TypedResults.NotFound();
        
            todo.Name = todoItemDTO.Name;
            todo.IsComplete = todoItemDTO.IsComplete;
        
            await db.SaveChangesAsync();
        
            return TypedResults.NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteTodo(int id)
        {
            if (await db.Todos.FindAsync(id) is Todo todo)
            {
                db.Todos.Remove(todo);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }
        
            return TypedResults.NotFound();
        }
    }
}