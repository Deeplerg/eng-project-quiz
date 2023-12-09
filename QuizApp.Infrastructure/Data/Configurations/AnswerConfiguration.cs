using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Infrastructure.Data.Models;

namespace QuizApp.Infrastructure.Data.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<AnswerDTO>
{
    public void Configure(EntityTypeBuilder<AnswerDTO> builder)
    {
        builder
            .HasKey(m => m.Id);
    }
}