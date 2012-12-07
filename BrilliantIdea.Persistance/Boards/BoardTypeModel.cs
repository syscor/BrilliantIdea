using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BrilliantIdea.Framework.Boards
{
    public class BoardTypeModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
