using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Models.Configurations;

namespace SpeedSolverDatabase
{
    public sealed class SpeedContext: DbContext
    {

        public bool IsConnected { get; set; } = false;
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        
        public SpeedContext()
        {
            try
            {
                this.IsConnected = Database.CanConnect();
            }
            catch
            {
                this.IsConnected = false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Username=postgres;Password=123;Database=speedsolver")
                .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectModeratorConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ObjectiveConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
