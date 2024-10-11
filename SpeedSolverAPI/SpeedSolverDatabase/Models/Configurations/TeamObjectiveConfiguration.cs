using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class TeamObjectiveConfiguration: IEntityTypeConfiguration<TeamObjective>
{
    public void Configure(EntityTypeBuilder<TeamObjective> builder)
    {
        builder.ToTable("teamobjectives").HasKey(t => t.TeamObjectiveId);
        
        builder.Property(t => t.TeamId).IsRequired();
        builder.Property(t => t.ObjectiveId).IsRequired();

        builder.HasMany(t => t.Objectives)
            .WithOne()
            .HasForeignKey(t => t.ObjectiveId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Team)
            .WithMany(t => t.Objectives)
            .HasForeignKey(t => t.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}