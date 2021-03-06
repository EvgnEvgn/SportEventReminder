﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportEventReminder.EntityFramework;

namespace SportEventReminder.EntityFramework.Migrations
{
    [DbContext(typeof(SportEventReminderDbContext))]
    partial class SportEventReminderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportEventReminder.Domain.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ParentArea")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("SportEventReminder.Domain.ExternalSourceIntegration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExternalObjectId");

                    b.Property<int>("ExternalSource");

                    b.Property<int>("ObjectId");

                    b.Property<int>("ObjectType");

                    b.HasKey("Id");

                    b.ToTable("ExternalSourceIntegrations");
                });

            modelBuilder.Entity("SportEventReminder.Domain.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaId");

                    b.Property<int>("LeagueLevel");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("Name");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("SportEventReminder.Domain.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AwayTeamId");

                    b.Property<int?>("HomeTeamId");

                    b.Property<int?>("LeagueId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("SportEventReminder.Domain.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<int?>("LeagueId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("WinnerId");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("SportEventReminder.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ShortName")
                        .HasMaxLength(50);

                    b.Property<string>("TeamTag")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SportEventReminder.Domain.League", b =>
                {
                    b.HasOne("SportEventReminder.Domain.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");
                });

            modelBuilder.Entity("SportEventReminder.Domain.Match", b =>
                {
                    b.HasOne("SportEventReminder.Domain.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId");

                    b.HasOne("SportEventReminder.Domain.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId");

                    b.HasOne("SportEventReminder.Domain.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId");
                });

            modelBuilder.Entity("SportEventReminder.Domain.Season", b =>
                {
                    b.HasOne("SportEventReminder.Domain.League", "League")
                        .WithMany("Seasons")
                        .HasForeignKey("LeagueId");

                    b.HasOne("SportEventReminder.Domain.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");
                });

            modelBuilder.Entity("SportEventReminder.Domain.Team", b =>
                {
                    b.HasOne("SportEventReminder.Domain.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");
                });
#pragma warning restore 612, 618
        }
    }
}
