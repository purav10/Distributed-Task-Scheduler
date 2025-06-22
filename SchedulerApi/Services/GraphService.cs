using MongoDB.Driver;
using SchedulerApi.Data;
using SchedulerApi.Models;
using System.Collections.Generic;

namespace SchedulerApi.Services
{
    public class GraphsService
    {
        private readonly MongoDbContext _context;

        public GraphsService(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<Graph> AddGraphAsync(Graph graph)
        {
            await _context.Graphs.InsertOneAsync(graph);
            return graph;
        }

        public async Task<Graph> GetGraphByIdAsync(string id)
        {
            return await _context.Graphs.Find(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Graph>> GetGraphsAsync()
        {
            return await _context.Graphs.Find(_ => true).ToListAsync();
        }

        public async Task<Graph?> UpdateGraphAsync(Graph graph)
        {
            var filter = Builders<Graph>.Filter.Eq(g => g.Id, graph.Id);
            var result = await _context.Graphs.ReplaceOneAsync(filter, graph);
            return result.MatchedCount > 0 ? graph : null;
        }

        public async Task DeleteGraphAsync(string id)
        {
            var filter = Builders<Graph>.Filter.Eq(g => g.Id, id);
            await _context.Graphs.DeleteOneAsync(filter);
        }
    }
}