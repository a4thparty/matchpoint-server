using MatchPoint.Core.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchPoint.Infrastructure
{
    public class MatchPointContext : DbContext
    {
        public MatchPointContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchTemplate> MatchTemplates { get; set; }
        public DbSet<MatchRoleOption> MatchRoleOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MatchTemplate>().HasKey(m => m.TemplateId);

            modelBuilder.Entity<MatchRoleOption>().HasKey(m => m.Id);
            modelBuilder.Entity<MatchRoleOption>().HasOne(m => m.Template);

            modelBuilder.Entity<Match>().HasKey(m => m.Id);
            modelBuilder.Entity<Match>().HasOne(m => m.Template);
            modelBuilder.Entity<Match>().Property(m => m.Participants).HasConversion(
                participants => JsonConvert.SerializeObject(participants),
                providers => JsonConvert.DeserializeObject<MatchParticipant[]>(providers)
                );

            modelBuilder.Entity<Player>().HasKey(p => p.Id);

            modelBuilder.Entity<MatchTemplate>().HasData(new[] {
               MatchTemplate.Badminton,
               MatchTemplate.Warcraft,
            });

            modelBuilder.Entity<MatchRoleOption>().HasData(new[]
            {
                new {
                    Id = Guid.NewGuid(),
                    TemplateId = MatchTemplate.Badminton.TemplateId,
                    Value = 0,
                    Description = "Male",
                },
                new {
                    Id = Guid.NewGuid(),
                    TemplateId = MatchTemplate.Badminton.TemplateId,
                    Value = 1,
                    Description = "Female",
                },
                new {
                    Id = Guid.NewGuid(),
                    TemplateId = MatchTemplate.Warcraft.TemplateId,
                    Value = 0,
                    Description = "Human",
                },
                new {
                    Id = Guid.NewGuid(),
                    TemplateId = MatchTemplate.Warcraft.TemplateId,
                    Value = 1,
                    Description = "Orc",
                },
                new {
                    Id = Guid.NewGuid(),
                    TemplateId = MatchTemplate.Warcraft.TemplateId,
                    Value = 2,
                    Description = "Undead",
                },
                new {
                    Id = Guid.NewGuid(),
                    TemplateId = MatchTemplate.Warcraft.TemplateId,
                    Value = 3,
                    Description = "Night Elf",
                },
                new {
                    Id = Guid.NewGuid(),
                    TemplateId = MatchTemplate.Warcraft.TemplateId,
                    Value = 4,
                    Description = "Random",
                },
            });

        }
    }
}
