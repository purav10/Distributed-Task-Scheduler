using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SchedulerApi.Models
{
    public class Graph
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [BsonElement("Edges")]
        public List<Edge> Edges { get; set; } = new List<Edge>();
    }

    public class Edge
    {
        [BsonElement("FromNodeId")]
        public string FromNodeId { get; set; } = string.Empty;

        [BsonElement("ToNodeId")]
        public string ToNodeId { get; set; } = string.Empty;

        [BsonElement("Weight")]
        public double Weight { get; set; }
    }
}