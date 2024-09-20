using Core.Dto.DtoCategories;

namespace Core.Dto.DtoServices
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Provider { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public string ImageUrl { get; set; }

        public int? CategoryId { get; set; }
    }
}
