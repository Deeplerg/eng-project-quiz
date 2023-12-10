using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Questions.Queries.GetQuestion;

public class GetQuestionQueryHandler(IApplicationDbContext _context)
    : IRequestHandler<GetQuestionQuery, Question?>
{
    public async Task<Question?> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
    {
        var question = await _context
            .Questions
            .Include(question => question.PossibleAnswers)
            .Include(question => question.Quiz)
            .AsNoTracking()
            .FirstOrDefaultAsync(question => question.Id == request.Id, cancellationToken);

        return question;
    }
}