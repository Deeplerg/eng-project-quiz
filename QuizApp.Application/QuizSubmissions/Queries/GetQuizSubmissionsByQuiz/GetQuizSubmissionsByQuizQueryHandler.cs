using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizSubmissions.Queries.GetQuizSubmissionsByQuiz;

public class GetQuizResultsQueryHandler(IApplicationDbContext _context) 
    : IRequestHandler<GetQuizSubmissionsByQuizQuery, IEnumerable<QuizSubmission>>
{
    public async Task<IEnumerable<QuizSubmission>> Handle(GetQuizSubmissionsByQuizQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context
            .QuizSubmissions
            .Include(qs => qs.ParentQuiz)
            .AsNoTracking()
            .Where(qs => qs.ParentQuiz.Id == request.QuizId)
            .ToListAsync(cancellationToken);

        return entities;
    }
}