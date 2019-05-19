using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEventReminder.Domain;

namespace SportEventReminder.EntityFramework.DomainConfigurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
