using Core.Entities;
using Core.Interfaces;
using System.Text.Json.Serialization;

namespace Data.Entities
{
    public class ServiceEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Provider { get; set; }
        public int? CategoryId { get; set; }
        [JsonIgnore]
        public CategoryEntity Category { get; set; }
        public double Rating { get; set; } 
        public int ReviewCount { get; set; } 
        public string? ImageUrl { get; set; } 
    }
}
