using Core.Entities;
using Core.Interfaces;

namespace Data.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ServiceEntity> Services { get; set; }

        public string? IconUrl { get; set; } 
        public int? ParentCategoryId { get; set; } 
        public CategoryEntity ParentCategory { get; set; }
    }
}
