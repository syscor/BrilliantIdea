using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        [DataMember(IsRequired = true)]
        public Guid DeviceId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public BoardType Type { get; set; }
        [Required]
        public string Url { get; set; }
        public List<Port> PortsConfiguration { get; set; }
        public bool Enable { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public class Port
    {
        public int PortNumber { get; set; }
        public Sensor AttachedSensor { get; set; }
        public int InputType { get; set; }
        public bool Enable { get; set; }
    }
}
