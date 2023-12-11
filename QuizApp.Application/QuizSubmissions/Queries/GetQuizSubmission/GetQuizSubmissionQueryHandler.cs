using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizSubmissions.Queries.GetQuizSubmission;

public class GetQuizSubmissionQueryHandler(IApplicationDbContext _context)
    : IRequestHandler<GetQuizSubmissionQuery, QuizSubmission?>
{
    public async Task<QuizSubmission?> Handle(GetQuizSubmissionQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context
            .QuizSubmissions
            .AsNoTracking()
            .Include(qs => qs.ParentQuiz)
            .Include(qs => qs.Answers)
            .FirstOrDefaultAsync(qs => qs.Id == request.Id, cancellationToken);

        return entity;
    }
}