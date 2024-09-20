using AutoMapper;
using Core.Dto.DtoCategories;
using Core.Interfaces;
using Core.Specifications;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByID(id);
            return _mapper.Map<CategoryDto>(category);
        }
        public async Task<CategoryDto> GetCategorySpecsByIdAsync(int id)
        {
            var category = await _categoryRepository.GetItemBySpec(new CategorySpecs.ById(id));
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<CategoryEntity>(createCategoryDto);
            await _categoryRepository.Insert(category);
            await _categoryRepository.Save();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<CategoryEntity>(updateCategoryDto);
            await _categoryRepository.Update(category);
            await _categoryRepository.Save();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByID(id);
            if (category != null)
            {
                await _categoryRepository.Delete(category);
                await _categoryRepository.Save();
            }
        }
    }
}
