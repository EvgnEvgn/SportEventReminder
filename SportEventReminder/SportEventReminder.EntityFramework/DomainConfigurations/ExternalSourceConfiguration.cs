using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportEventReminder.EntityFramework.DomainConfigurations
{
    public class ExternalSourceConfiguration : IEntityTypeConfiguration<ExternalSource>
    {
        public void Configure(EntityTypeBuilder<ExternalSource> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Url).HasMaxLength(100);
        }
    }
}
