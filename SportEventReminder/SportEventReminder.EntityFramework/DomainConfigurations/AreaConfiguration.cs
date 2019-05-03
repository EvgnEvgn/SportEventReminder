using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEventReminder.Domain;

namespace SportEventReminder.EntityFramework.DomainConfigurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasAlternateKey(p => p.Name);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ParentArea).HasMaxLength(100);
        }
    }
}
