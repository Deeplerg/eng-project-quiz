using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizResults.Queries.GetQuizResult;

public class GetQuizResultQueryHandler(IApplicationDbContext _context)
    : IRequestHandler<GetQuizResultQuery, QuizResult?>
{
    public async Task<QuizResult?> Handle(GetQuizResultQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context
            .QuizResults
            .AsNoTracking()
            .Include(qr => qr.Quiz)
            .FirstOrDefaultAsync(qr => qr.Id == request.Id, cancellationToken);

        return entity;
    }
}