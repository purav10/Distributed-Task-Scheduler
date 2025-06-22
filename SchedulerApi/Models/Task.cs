using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SchedulerApi.Models
{
    public class Task
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Priority")]
        public int Priority { get; set; } = 0;

        [BsonElement("ResourceNeeds")]
        public double ResourceNeeds { get; set; }

        [BsonElement("Duration")]
        public int Duration { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; } = "Pending";

        [BsonElement("AssignedNodeId")]
        public string? AssignedNodeId { get; set; }
    }
}