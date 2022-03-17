using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using TodoManager.Entities;

namespace TodoManager.Repositories
{
    public class MongoDbTodoRepository : ITodoRepository
    {
        private const string databaseName = "todomanager";
        private const string collectionName = "todo";
        private readonly IMongoCollection<Todo> todoCollection;
        private readonly FilterDefinitionBuilder<Todo> filterBuilder = Builders<Todo>.Filter;

        public MongoDbTodoRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            todoCollection = database.GetCollection<Todo>(collectionName);
        }

        public void CreateTodo(Todo todo)
        {
            todoCollection.InsertOne(todo);
        }

        public void DeleteTodo(Guid id)
        {
            var filter = filterBuilder.Eq(todo => todo.Id, id);
            todoCollection.DeleteOne(filter);
        }

        public Todo GetTodo(Guid id)
        {
            var filter = filterBuilder.Eq(todo => todo.Id, id);
            return todoCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Todo> GetTodos()
        {
            return todoCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateTodo(Todo todo)
        {
            var filter = filterBuilder.Eq(t => t.Id, todo.Id);
            todoCollection.ReplaceOne(filter, todo);
        }
    }
}