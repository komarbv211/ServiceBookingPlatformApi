using Ardalis.Specification;
using Data.Entities;

namespace Core.Specifications
{
    internal static class ServiceSpecs
    {
        internal class ById : Specification<ServiceEntity>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Category);
            }
        }

        internal class ByCategoryId : Specification<ServiceEntity>
        {
            public ByCategoryId(int categoryId)
            {
                Query
                    .Where(x => x.CategoryId == categoryId)
                    .Include(x => x.Category);
            }
        }

        internal class All : Specification<ServiceEntity>
        {
            public All()
            {
                Query
                    .Include(x => x.Category);
            }
        }

        // Специфікація для фільтрації послуг за рейтингом
        internal class ByRating : Specification<ServiceEntity>
        {
            public ByRating(int rating)
            {
                Query
                    .Where(x => x.Rating == rating)
                    .Include(x => x.Category);
            }
        }

        // Специфікація для фільтрації послуг за ціною
        internal class ByPriceRange : Specification<ServiceEntity>
        {
            public ByPriceRange(decimal minPrice, decimal maxPrice)
            {
                Query
                    .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                    .Include(x => x.Category);
            }
        }
    }
}
