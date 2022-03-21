// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using MongoDB.Bson;
// using MongoDB.Driver;
// using TodoManager.Entities;

// namespace TodoManager.Repositories
// {
//     public class MongoDbTodoRepository : ITodoRepository
//     {
//         private const string databaseName = "todomanager";
//         private const string collectionName = "todo";
//         private readonly IMongoCollection<Todo> todoCollection;
//         private readonly FilterDefinitionBuilder<Todo> filterBuilder = Builders<Todo>.Filter;

//         public MongoDbTodoRepository(IMongoClient mongoClient)
//         {
//             IMongoDatabase database = mongoClient.GetDatabase(databaseName);
//             todoCollection = database.GetCollection<Todo>(collectionName);
//         }

//         public async Task CreateTodoAsync(Todo todo)
//         {
//             await todoCollection.InsertOneAsync(todo);
//         }

//         public async Task DeleteTodoAsync(Guid id)
//         {
//             var filter = filterBuilder.Eq(todo => todo.Id, id);
//             await todoCollection.DeleteOneAsync(filter);
//         }

//         public async Task<Todo> GetTodoAsync(Guid id)
//         {
//             var filter = filterBuilder.Eq(todo => todo.Id, id);
//             return await todoCollection.Find(filter).SingleOrDefaultAsync();
//         }

//         public async Task<IEnumerable<Todo>> GetTodosAsync()
//         {
//             return await todoCollection.Find(new BsonDocument()).ToListAsync();
//         }

//         public async Task UpdateTodoAsync(Todo todo)
//         {
//             var filter = filterBuilder.Eq(t => t.Id, todo.Id);
//             await todoCollection.ReplaceOneAsync(filter, todo);
//         }
//     }
// }