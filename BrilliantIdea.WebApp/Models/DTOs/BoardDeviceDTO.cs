using System;
using System.Collections.Generic;

namespace BrilliantIdea.WebApp.Models.DTOs
{
    public class BoardDeviceDTO
    {
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BoardTypeModelDTO Type { get; set; }
        public string Url { get; set; }
        public List<PortDTO> PortsConfiguration { get; set; }
        public bool IsEnable { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public class PortDTO
    {
        public int PortNumber { get; set; }
        public SensorDTO AttachedSensor { get; set; }
        public int InputType { get; set; }
        public bool Enable { get; set; }
    }
}