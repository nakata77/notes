using ATP.MyNotesApp.Core.Entitties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATP.MyNotesApp.Infrastructure.Configurations
{
    internal class NoteCategoryConfiguration : IEntityTypeConfiguration<NoteCategory>
    {
        public void Configure(EntityTypeBuilder<NoteCategory> builder)
        {
            builder.HasKey(nc => new { nc.CategoryId, nc.NoteId });

            builder.HasOne(nc => nc.Note)
                .WithMany(n => n.Categories)
                .HasForeignKey(nc => nc.NoteId);

            builder.HasOne(nc => nc.Category)
                .WithMany(n => n.Notes)
                .HasForeignKey(nc => nc.CategoryId);
        }
    }
}
