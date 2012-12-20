using System;
using System.Collections.Generic;

namespace BrilliantIdea.WebApp.Models.DTOs
{
    public class BoardTypeModelDTO
    {
        public Guid BoardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PinFeature> PinFeatures { get; set; }
    }

    public class PinFeature
    {
        public int Pin { get; set; }
        public string PinDescription { get; set; }
    }
}