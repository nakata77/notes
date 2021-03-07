using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATP.MyNotesApp.Core.DTOs.Category;
using ATP.MyNotesApp.Core.Entitties;
using ATP.MyNotesApp.Core.Interfaces.Repositories;
using ATP.MyNotesApp.Core.Interfaces.Services;
using AutoMapper;

namespace ATP.MyNotesApp.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(c => _mapper.Map<CategoryDto>(c));
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category is null)
                return null;

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateAsync(ManageCategoryDto request)
        {
            if (request is null)
                throw new ArgumentException("Request cannot be null!");

            var categoryToAdd = new Category
            {
                Title = request.Title,
                Notes = request.Notes.Select(nc => new NoteCategory
                {
                    NoteId = nc
                }).ToList()
            };

            _categoryRepository.Add(categoryToAdd);
            await _categoryRepository.SaveChangesAsync();

            return await GetAsync(categoryToAdd.Id);
        }

        public async Task<CategoryDto> UpdateAsync(Guid id, ManageCategoryDto request)
        {
            if (request is null)
                throw new ArgumentException("Request cannot be null!");

            var category = await _categoryRepository.GetAsync(id);

            if (category is null)
                return null;

            category.Title = request.Title;
            category.Notes = request.Notes.Select(nc => new NoteCategory
            {
                NoteId = nc
            }).ToList();

            await _categoryRepository.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category is null)
                return false;

            _categoryRepository.Remove(category);
            await _categoryRepository.SaveChangesAsync();

            return true;
        }
    }
}
