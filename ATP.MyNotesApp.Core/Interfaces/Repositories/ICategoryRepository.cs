using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATP.MyNotesApp.Core.Entitties;

namespace ATP.MyNotesApp.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        new Task<IEnumerable<Category>> GetAllAsync();

        new Task<Category> GetAsync(Guid id);
    }
}
