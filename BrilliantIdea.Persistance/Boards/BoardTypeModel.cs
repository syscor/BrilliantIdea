using System;
using System.Web.Script.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BrilliantIdea.Framework.Boards
{
    public class BoardTypeModel
    {
        [BsonId, JsonIgnore]
        public ObjectId Id { get; set; }
        public Guid BoardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
