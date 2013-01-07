using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrilliantIdea.WebApp.Models.DTOs
{
    public class SensorDTO
    {
        public Guid SensorId { get; set; }
        public int SensorType { get; set; }
        public string Name { get; set; }
        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }
        public decimal RazonConversion { get; set; }
        public DateTime LastModified { get; set; }
    }
}