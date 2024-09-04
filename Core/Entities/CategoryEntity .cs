using Core.Interfaces;

namespace Data.Entities
{
    public class CategoryEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ServiceEntity> Services { get; set; }
    }
}
