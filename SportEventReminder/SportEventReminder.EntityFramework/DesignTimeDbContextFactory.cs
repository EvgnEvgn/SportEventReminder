using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SportEventReminder.EntityFramework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SportEventReminderDbContext>
    {
        public SportEventReminderDbContext CreateDbContext(string[] args)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
    
            var builder = new DbContextOptionsBuilder<SportEventReminderDbContext>();
            builder.UseSqlServer(connectionString);
    
            return new SportEventReminderDbContext(builder.Options);
        }
    }
}
