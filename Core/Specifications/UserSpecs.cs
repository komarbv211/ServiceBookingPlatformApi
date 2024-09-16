using Ardalis.Specification;
using Data.Entities;

namespace Core.Specifications
{
    internal static class UserSpecs
    {
        internal class ById : Specification<UserEntity>
        {
            public ById(string id)
            {
                Query
                    .Where(x => x.Id == id);
            }
        }

        internal class ByRole : Specification<UserEntity>
        {
            public ByRole(string role)
            {
                Query
                    .Where(x => x.Role == role);
            }
        }

        // Специфікація для фільтрації користувачів за датою реєстрації
        internal class ByRegistrationDate : Specification<UserEntity>
        {
            public ByRegistrationDate(DateTime startDate, DateTime endDate)
            {
                Query
                    .Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate);
            }
        }
    }
}
