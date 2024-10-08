using Microsoft.EntityFrameworkCore;
using SpeedSolverDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeedSolverDatabase.Models.Configurations;

namespace SpeedSolverDatabase
{
    public sealed class SpeedContext: DbContext
    {

        public bool IsConnected { get; set; } = false;

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamObjective> TeamObjectives { get; set; }
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
            optionsBuilder.UseNpgsql("Server=localhost;Username=postgres;Password=123;Database=speedsolver");
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ObjectiveConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamObjectiveConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
