using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BrilliantIdea.Framework.Boards
{
    public class BoardDevice
    {
        [BsonId, JsonIgnore]
        public ObjectId Id { get; set; }
        [Required]
        public Guid DeviceId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public BoardType Type { get; set; }
        public string Url { get; set; }
        public List<Port> PortsConfiguration { get; set; }
    }

    public class Port
    {
        public int PortNumber { get; set; }
        public Sensor AttachedSensor { get; set; }
        public int InputType { get; set; }
        public bool Enable { get; set; }
    }
}
