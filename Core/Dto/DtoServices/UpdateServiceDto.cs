using Core.Dto.DtoCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.DtoServices
{
    public class UpdateServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Provider { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public string? ImageUrl { get; set; }

        public int? CategoryId { get; set; }
    }
}
