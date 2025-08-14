using DevHabit.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevHabit.Api.Database.Configurations;

public sealed class HabitTagConfiguration : IEntityTypeConfiguration<HabitTag>
{
    public void Configure(EntityTypeBuilder<HabitTag> builder)
    {
        builder.HasKey(h => new { h.HabitId, h.TagId });

        builder.HasOne<Tag>()
            .WithMany()
            .HasForeignKey(h => h.TagId);

        builder.HasOne<Habit>()
            .WithMany(h => h.HabitTags)
            .HasForeignKey(h => h.HabitId);
    }
}
