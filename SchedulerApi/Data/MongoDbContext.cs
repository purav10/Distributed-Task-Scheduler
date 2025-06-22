using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using SchedulerApi.Models;

namespace SchedulerApi.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            _database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
        }

        public IMongoCollection<Tasks> Tasks => _database.GetCollection<Tasks>("Tasks");
        public IMongoCollection<Node> Nodes => _database.GetCollection<Node>("Nodes");
        public IMongoCollection<Graph> Graphs => _database.GetCollection<Graph>("Graphs");
    }
}