using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;

namespace QuizApp.Infrastructure.Data.Configurations;

public class QuizResultConfiguration : IEntityTypeConfiguration<QuizResult>
{
    public void Configure(EntityTypeBuilder<QuizResult> builder)
    {
        builder
            .HasKey(m => m.Id);
        
        builder
            .Property(m => m.Description)
            .IsRequired();

        builder
            .Property(m => m.FromScore)
            .IsRequired();
    }
}