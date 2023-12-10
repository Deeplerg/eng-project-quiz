using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Answer> Answers => Set<Answer>();
    public DbSet<Quiz> Quizzes => Set<Quiz>();
    public DbSet<QuizResult> QuizResults => Set<QuizResult>();
    public DbSet<QuizSubmission> QuizSubmissions => Set<QuizSubmission>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<Question>()
               .UseTpcMappingStrategy()
               .ToTable("Questions");
        builder.Entity<Answer>()
               .UseTpcMappingStrategy()
               .ToTable("PossibleAnswers");
        builder.Entity<Quiz>()
            .UseTpcMappingStrategy()
            .ToTable("Quizzes");
        builder.Entity<QuizResult>()
            .UseTpcMappingStrategy()
            .ToTable("QuizResults");
        builder.Entity<QuizSubmission>()
            .UseTpcMappingStrategy()
            .ToTable("QuizSubmissions");
        
        base.OnModelCreating(builder);
    }
}