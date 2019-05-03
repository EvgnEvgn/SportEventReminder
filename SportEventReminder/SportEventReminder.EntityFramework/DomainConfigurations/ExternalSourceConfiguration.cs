using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEventReminder.Domain;

namespace SportEventReminder.EntityFramework.DomainConfigurations
{
    public class ExternalSourceConfiguration : IEntityTypeConfiguration<ExternalSourceIntegration>
    {
        public void Configure(EntityTypeBuilder<ExternalSourceIntegration> builder)
        {
            builder.Property(x => x.ExternalSource);
            builder.Property(x => x.ExternalObjectId);
            builder.Property(x => x.ObjectId);
            builder.Property(x => x.ObjectType);
        }
    }
}
