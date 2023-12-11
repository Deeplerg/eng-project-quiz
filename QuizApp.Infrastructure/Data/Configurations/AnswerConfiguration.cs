using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;

namespace QuizApp.Infrastructure.Data.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Description)
            .IsRequired();

        builder
            .Property(m => m.Score)
            .IsRequired();
    }
}