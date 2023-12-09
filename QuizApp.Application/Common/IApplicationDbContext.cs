using Microsoft.EntityFrameworkCore;
using QuizApp.Infrastructure.Data.Models;

namespace QuizApp.Application.Common;

public interface IApplicationDbContext
{
    DbSet<QuestionDTO> Questions { get; }
    DbSet<AnswerDTO> Answers { get; }

    Task SaveChangesAsync();
}