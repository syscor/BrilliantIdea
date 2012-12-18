using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BrilliantIdea.Framework.Boards
{
    public class SensorType
    {
        [BsonId, JsonIgnore]
        public ObjectId Id { get; set; }

        public Guid SensorTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
