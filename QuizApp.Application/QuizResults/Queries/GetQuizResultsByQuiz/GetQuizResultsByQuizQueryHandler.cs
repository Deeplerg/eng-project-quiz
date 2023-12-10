using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizResults.Queries.GetQuizResultsByQuiz;

public class GetQuizResultsQueryHandler(IApplicationDbContext _context) 
    : IRequestHandler<GetQuizResultsByQuizQuery, IEnumerable<QuizResult>>
{
    public async Task<IEnumerable<QuizResult>> Handle(GetQuizResultsByQuizQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context
            .QuizResults
            .Include(qr => qr.Quiz)
            .AsNoTracking()
            .Where(qr => qr.Quiz.Id == request.QuizId)
            .ToListAsync(cancellationToken);

        return entities;
    }
}