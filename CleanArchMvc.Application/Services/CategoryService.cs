using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
        }

        public async Task<CategoryDto> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task Add(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task Update(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = await  _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.RemoveAsync(categoryEntity);
        }
    }
}
