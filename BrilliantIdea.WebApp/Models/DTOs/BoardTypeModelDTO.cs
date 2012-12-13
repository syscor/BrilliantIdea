using System;

namespace BrilliantIdea.WebApp.Models.DTOs
{
    public class BoardTypeModelDTO
    {
        public Guid BoardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}