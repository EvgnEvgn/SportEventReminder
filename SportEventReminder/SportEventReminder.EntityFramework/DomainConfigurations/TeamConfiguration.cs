using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportEventReminder.EntityFramework.DomainConfigurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.ShortName).HasMaxLength(50);
            builder.Property(p => p.TeamTag).HasMaxLength(15);
        }
    }
}
