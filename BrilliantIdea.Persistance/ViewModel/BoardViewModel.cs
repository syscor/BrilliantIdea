using System;
using BrilliantIdea.Framework.Boards;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BrilliantIdea.Framework.ViewModel
{
    [Serializable]
    public class BoardViewModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BoardType Type { get; set; }
    }
}
