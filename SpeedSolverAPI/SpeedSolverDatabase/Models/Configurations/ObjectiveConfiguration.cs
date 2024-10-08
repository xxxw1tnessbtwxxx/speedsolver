using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class ObjectiveConfiguration : IEntityTypeConfiguration<Objective>
{
    public void Configure(EntityTypeBuilder<Objective> builder)
    {
        builder.ToTable("objectives");

        builder.HasKey(t => t.ObjectiveId);
        
        builder.HasOne(o => o.Creator)
            .WithMany(c => c.Objectives)
            .HasForeignKey(o => o.CreatorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}