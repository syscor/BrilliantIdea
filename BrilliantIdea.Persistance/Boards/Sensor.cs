﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BrilliantIdea.Framework.Boards
{
    public class Sensor
    {
        [BsonId, JsonIgnore]
        public ObjectId Id { get; set; }

        public Guid SensorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SensorType SensorType { get; set; }
    }
}
