using MongoDB.Driver;
using SchedulerApi.Data;
using SchedulerApi.Models;
using System.Collections.Generic;

namespace SchedulerApi.Services
{
    public class NodeService
    {
        private readonly MongoDbContext _context;

        public NodeService(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<Node> AddNodeAsync(Node node)
        {
            await _context.Nodes.InsertOneAsync(node);
            return node;
        }

        public async Task<Node> GetNodeByIdAsync(string id)
        {
            return await _context.Nodes.Find(n => n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Node>> GetNodesAsync()
        {
            return await _context.Nodes.Find(_ => true).ToListAsync();
        }

        public async Task<Node?> UpdateNodeByIdAsync(Node node)
        {
            var filter = Builders<Node>.Filter.Eq(n => n.Id, node.Id);
            var result = await _context.Nodes.ReplaceOneAsync(filter, node);
            return result.MatchedCount > 0 ? node : null;
        }

        public async Task DeleteNodeByIdAsync(string id)
        {
            var filter = Builders<Node>.Filter.Eq(n => n.Id, id);
            await _context.Nodes.DeleteOneAsync(filter);
        }
    }
}