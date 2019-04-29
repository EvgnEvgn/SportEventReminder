using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEventReminder.Domain;

namespace SportEventReminder.EntityFramework.DomainConfigurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.Property(p => p.CountryName).IsRequired().HasMaxLength(100);
        }
    }
}
