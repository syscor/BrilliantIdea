using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BrilliantIdea.Framework.Boards
{
    [Serializable]
    public class BoardModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BoardTypeModel Type { get; set; }
    }
}
