using Microsoft.EntityFrameworkCore;
using SpeedSolverDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabase
{
    public class SpeedContext: DbContext
    {

        public bool _isConnected { get; set; } = false;

        public DbSet<User> Users { get; set; }
        public DbSet<UnderObjective> UnderObjective { get; set; }
        public DbSet<TeamTask> TeamTasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamLog> TeamLog { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Invitation> Invations { get; set; }

        public SpeedContext()
        {
            try
            {
                this._isConnected = Database.CanConnect();
            }
            catch
            {
                this._isConnected = false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;User=postgres;Password=123;Database=speedsolver");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
