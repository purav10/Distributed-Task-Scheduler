using MongoDB.Driver;
using System;

namespace SchedulerApi
{
    public class MongoTest
    {
        public static void TestConnection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TaskSchedulerDb");
            var collection = database.GetCollection<object>("TestCollection");
            collection.InsertOne(new { Test = "Connection successful" });
            Console.WriteLine("MongoDB connection successful!");
        }
    }
}