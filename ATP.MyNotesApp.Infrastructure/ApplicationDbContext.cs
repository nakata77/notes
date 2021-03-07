using ATP.MyNotesApp.Core.Entitties;
using ATP.MyNotesApp.Core.Interfaces;
using ATP.MyNotesApp.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ATP.MyNotesApp.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<NoteCategory> NoteCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new NoteConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new NoteCategoryConfiguration());
        }
    }
}
