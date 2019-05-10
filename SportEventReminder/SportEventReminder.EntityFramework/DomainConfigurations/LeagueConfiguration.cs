using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEventReminder.Domain;

namespace SportEventReminder.EntityFramework.DomainConfigurations
{
    public class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasIndex(p => p.Name);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.HasMany(p => p.Seasons).WithOne(p => p.League);
        }
    }
}
