using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class TeamObjectiveConfiguration: IEntityTypeConfiguration<TeamObjective>
{
    public void Configure(EntityTypeBuilder<TeamObjective> builder)
    {
        builder.ToTable("teamsobjectives");
        
        builder.HasKey(to => to.TeamTaskId);
        
        builder.HasOne(t => t.Team)
            .WithMany(t => t.Objectives)
            .HasForeignKey(t => t.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}