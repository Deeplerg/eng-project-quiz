using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;

namespace QuizApp.Infrastructure.Data.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Description)
            .IsRequired();
        
        builder
            .HasMany<Answer>(m => m.PossibleAnswers)
            .WithOne(m => m.Question)
            .OnDelete(DeleteBehavior.Cascade);
    }
}