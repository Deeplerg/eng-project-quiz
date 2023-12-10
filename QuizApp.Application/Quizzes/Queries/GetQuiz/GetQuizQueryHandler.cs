using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Quizzes.Queries.GetQuiz;

public class GetQuizQueryHandler(IApplicationDbContext _context)
    : IRequestHandler<GetQuizQuery, Quiz?>
{
    public async Task<Quiz?> Handle(GetQuizQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context
            .Quizzes
            .AsNoTracking()
            .Include(quiz => quiz.Questions)
            .ThenInclude(question => question.PossibleAnswers)
            .Include(quiz => quiz.PossibleResults)
            .FirstOrDefaultAsync(question => question.Id == request.Id, cancellationToken);

        return entity;
    }
}