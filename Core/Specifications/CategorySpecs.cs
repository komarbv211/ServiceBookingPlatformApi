using Ardalis.Specification;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Specifications
{
    internal static class CategorySpecs
    {
        internal class ById : Specification<CategoryEntity>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Services);
            }
        }

        internal class All : Specification<CategoryEntity>
        {
            public All()
            {
                Query
                    .Include(x => x.Services);
            }
        }
    }
}
