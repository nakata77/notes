using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATP.MyNotesApp.Core.Entitties;
using ATP.MyNotesApp.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ATP.MyNotesApp.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async new Task<IEnumerable<Category>> GetAllAsync()
            => await ApplicationContext.Categories
                .Include(c => c.Notes)
                    .ThenInclude(nc => nc.Note)
                .ToListAsync();

        public async new Task<Category> GetAsync(Guid id)
            => await ApplicationContext.Categories
                .Include(c => c.Notes)
                    .ThenInclude(nc => nc.Note)
                .SingleOrDefaultAsync(c => c.Id == id);
    }
}
