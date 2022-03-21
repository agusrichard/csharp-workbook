// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using TodoManager.Entities;

// namespace TodoManager.Repositories
// {
//     public class InMemTodoRepository : ITodoRepository
//     {
//         private List<Todo> _todos = new()
//         {
//             new Todo
//             {
//                 Id = Guid.NewGuid(),
//                 Name = "Sekardayu Hana Pradiani",
//                 Description = "Learn administration",
//                 CreatedAt = DateTimeOffset.UtcNow
//             },
//             new Todo
//             {
//                 Id = Guid.NewGuid(),
//                 Name = "Saskia Nurul Azhima",
//                 Description = "Learn economy",
//                 CreatedAt = DateTimeOffset.UtcNow
//             },
//             new Todo
//             {
//                 Id = Guid.NewGuid(),
//                 Name = "Sintya Lestari",
//                 Description = "Learn communication",
//                 CreatedAt = DateTimeOffset.UtcNow
//             }
//         };

//         public async Task<IEnumerable<Todo>> GetTodosAsync()
//         {
//             return await Task.FromResult(_todos);
//         }

//         public async Task<Todo> GetTodoAsync(Guid id)
//         {
//             var result = _todos.Find(t => t.Id == id);
//             return await Task.FromResult(result);
//         }

//         public async Task CreateTodoAsync(Todo todo)
//         {
//             _todos.Add(todo);
//             await Task.CompletedTask;
//         }

//         public async Task UpdateTodoAsync(Todo todo)
//         {
//             var existingTodoIndex = _todos.FindIndex(t => t.Id == todo.Id);
//             _todos[existingTodoIndex] = todo;
//             await Task.CompletedTask;
//         }

//         public async Task DeleteTodoAsync(Guid id)
//         {
//             _todos = _todos.Where(t => t.Id != id).ToList();
//             await Task.CompletedTask;
//         }
//     }
// }