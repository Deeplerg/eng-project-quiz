using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Common;

public interface IApplicationDbContext
{
    DbSet<Question> Questions { get; }
    DbSet<Answer> Answers { get; }
    DbSet<Quiz> Quizzes { get; }
    DbSet<QuizResult> QuizResults { get; }
    DbSet<QuizSubmission> QuizSubmissions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}