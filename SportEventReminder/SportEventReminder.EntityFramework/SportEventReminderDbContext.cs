using Microsoft.EntityFrameworkCore;
using SportEventReminder.Domain;
using SportEventReminder.EntityFramework.DomainConfigurations;

namespace SportEventReminder.EntityFramework
{
    public class SportEventReminderDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<ExternalSourceIntegration> ExternalSourceIntegrations { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public SportEventReminderDbContext(DbContextOptions<SportEventReminderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new ExternalSourceConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new SeasonConfiguration());
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
        }
    }
}