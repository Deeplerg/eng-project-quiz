using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Quizzes.Queries.GetAllQuizzes;

public class GetAllQuizzesQueryHandler(IApplicationDbContext _context) 
    : IRequestHandler<GetAllQuizzesQuery, IEnumerable<Quiz>>
{
    public async Task<IEnumerable<Quiz>> Handle(GetAllQuizzesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context
            .Quizzes
            .Include(quiz => quiz.Questions)
            .ThenInclude(question => question.PossibleAnswers)
            .Include(quiz => quiz.PossibleResults)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return entities;
    }
}