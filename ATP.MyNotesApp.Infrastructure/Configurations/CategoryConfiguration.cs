using ATP.MyNotesApp.Core.Entitties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATP.MyNotesApp.Infrastructure.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasMany(n => n.Notes)
                .WithOne(nc => nc.Category)
                .HasForeignKey(nc => nc.CategoryId);
        }
    }
}
