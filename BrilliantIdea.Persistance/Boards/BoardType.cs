using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BrilliantIdea.Framework.Boards
{
    public class BoardType
    {
        [BsonId, JsonIgnore]
        public ObjectId Id { get; set; }
        public Guid BoardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PinFeature> PinFeatures { get; set; }
    }

    public class PinFeature
    {
        public string Pins { get; set; }
        public string PinDescription { get; set; }
    }
}
