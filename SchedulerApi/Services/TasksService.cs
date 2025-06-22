using MongoDB.Driver;
using SchedulerApi.Data;
using SchedulerApi.Models;

namespace SchedulerApi.Services
{
    public class TasksService
    {
        private readonly MongoDbContext _context;

        public TasksService(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<Tasks> AddTaskAsync(Tasks tasks)
        {
            await _context.Tasks.InsertOneAsync(tasks);
            return tasks;
        }

        public async Task<Tasks> GetTaskByIdAsync(string id)
        {
            return await _context.Tasks.Find(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Tasks?> UpdateTaskAsync(Tasks tasks)
        {
            var filter = Builders<Tasks>.Filter.Eq(t => t.Id, tasks.Id);
            var result = await _context.Tasks.ReplaceOneAsync(filter, tasks);
            return result.MatchedCount > 0 ? tasks : null;
        }

        public async Task DeleteTaskAsync(String id)
        {
            var filter = Builders<Tasks>.Filter.Eq(t => t.Id, id);
            await _context.Tasks.DeleteOneAsync(filter);
        }
    }
}