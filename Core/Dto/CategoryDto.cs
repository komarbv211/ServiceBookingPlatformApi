using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; } 
        public int? ParentCategoryId { get; set; }
        public CategoryDto ParentCategory { get; set; }
        public ICollection<ServiceDto> Services { get; set; }
    }
}
