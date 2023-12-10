using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;

namespace QuizApp.Infrastructure.Data.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Name)
            .IsRequired();
        
        builder
            .HasMany(m => m.Questions)
            .WithOne(m => m.Quiz)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(m => m.PossibleResults)
            .WithOne(m => m.Quiz)
            .OnDelete(DeleteBehavior.Cascade);
    }
}