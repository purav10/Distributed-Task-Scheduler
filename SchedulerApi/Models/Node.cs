using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SchedulerApi.Models
{
    public class Node
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Capacity")]
        public double Capacity { get; set; }

        [BsonElement("CurrentLoad")]
        public double CurrentLoad { get; set; }

        [BsonElement("TaskIds")]
        public List<string> TaskIds { get; set; } = new List<string>();

    }    
}