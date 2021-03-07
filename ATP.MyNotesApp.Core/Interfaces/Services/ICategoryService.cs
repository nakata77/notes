using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATP.MyNotesApp.Core.DTOs.Category;

namespace ATP.MyNotesApp.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAsync();

        Task<CategoryDto> GetAsync(Guid id);

        Task<CategoryDto> CreateAsync(ManageCategoryDto request);

        Task<CategoryDto> UpdateAsync(Guid id, ManageCategoryDto request);

        Task<bool> DeleteAsync(Guid id);
    }
}
