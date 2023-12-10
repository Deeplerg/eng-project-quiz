using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Answers.Queries.GetAnswer;

public class GetAnswerQueryHandler(IApplicationDbContext _context)
    : IRequestHandler<GetAnswerQuery, Answer>
{
    public async Task<Answer> Handle(GetAnswerQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context
            .Answers
            .AsNoTracking()
            .Include(answer => answer.Question)
            .Include(quiz => quiz.Question.Quiz)
            .FirstOrDefaultAsync(question => question.Id == request.Id, cancellationToken);

        return entity;
    }
}