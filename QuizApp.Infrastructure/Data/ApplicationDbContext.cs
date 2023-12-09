using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QuizApp.Infrastructure.Data.Models;

namespace QuizApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<QuestionDTO> Questions => Set<QuestionDTO>();
    public DbSet<AnswerDTO> Answers => Set<AnswerDTO>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<QuestionDTO>().ToTable("Questions");
        builder.Entity<AnswerDTO>().ToTable("Answers");
        
        base.OnModelCreating(builder);
    }
}