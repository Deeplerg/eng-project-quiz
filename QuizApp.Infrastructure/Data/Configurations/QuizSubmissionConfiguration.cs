using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;

namespace QuizApp.Infrastructure.Data.Configurations;

public class QuizSubmissionConfiguration : IEntityTypeConfiguration<QuizSubmission>
{
    public void Configure(EntityTypeBuilder<QuizSubmission> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.SubmissionDate)
            .IsRequired();

        builder
            .HasMany(m => m.Answers)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "QuizSubmissionAnswers",
                j => j
                    .HasOne<Answer>()
                    .WithMany()
                    .HasForeignKey("PossibleAnswerId")
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne<QuizSubmission>()
                    .WithMany()
                    .HasForeignKey("QuizId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}