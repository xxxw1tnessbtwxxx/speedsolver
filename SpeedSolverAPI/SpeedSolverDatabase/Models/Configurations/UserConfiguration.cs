using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            
            builder.HasKey(u => u.UserId);
            
            // - CFG: Teams
            builder.HasMany(u => u.OwnTeams)
                .WithOne(t => t.Creator)
                .HasForeignKey(u => u.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // - CFG: Objectives
            builder.HasMany(u => u.Objectives)
                .WithOne(t => t.Creator)
                .HasForeignKey(u => u.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
