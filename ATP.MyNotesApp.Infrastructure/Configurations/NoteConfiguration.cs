using ATP.MyNotesApp.Core.Entitties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATP.MyNotesApp.Infrastructure.Configurations
{
    internal class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(n => n.Text)
                .IsRequired()
                .HasMaxLength(2048);

            builder.HasMany(n => n.Categories)
                .WithOne(nc => nc.Note)
                .HasForeignKey(nc => nc.NoteId);
        }
    }
}
