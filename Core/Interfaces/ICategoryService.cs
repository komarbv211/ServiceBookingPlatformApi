using Core.Dto.DtoCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto); 
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto); 
        Task DeleteCategoryAsync(int id);
    }
}
