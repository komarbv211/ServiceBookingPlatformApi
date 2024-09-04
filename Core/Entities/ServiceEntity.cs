using Core.Interfaces;

namespace Data.Entities
{
    public class ServiceEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Provider { get; set; }
        public int? CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
