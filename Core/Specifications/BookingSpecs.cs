using Data.Entities;
using Ardalis.Specification;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Specifications
{
    internal static class BookingSpecs
    {
        internal class ByUserId : Specification<BookingEntity>
        {
            public ByUserId(string userId)
            {
                Query
                    .Where(x => x.UserId == userId)
                    .Include(x => x.BookingDetails);
            }
        }

        internal class ById : Specification<BookingEntity>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.BookingDetails)
                    .Include(x => x.User);
            }
        }

        internal class ActiveBookings : Specification<BookingEntity>
        {
            public ActiveBookings()
            {
                Query
                    .Where(x => x.Status == "Active")
                    .Include(x => x.BookingDetails)
                    .Include(x => x.User);
            }
        }
    }
}
