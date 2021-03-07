using ATP.MyNotesApp.Core.Entitties;
using Microsoft.EntityFrameworkCore;

namespace ATP.MyNotesApp.Core.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Note> Notes { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<NoteCategory> NoteCategories { get; set; }
    }
}
