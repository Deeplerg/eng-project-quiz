using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Infrastructure.Data.Models;

namespace QuizApp.Infrastructure.Data.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<QuestionDTO>
{
    public void Configure(EntityTypeBuilder<QuestionDTO> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .HasMany<AnswerDTO>(m => m.Answers)
            .WithOne("Question")
            .OnDelete(DeleteBehavior.Cascade);
    }
}