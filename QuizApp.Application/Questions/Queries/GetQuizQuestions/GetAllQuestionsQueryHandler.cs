using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Application.Questions.Queries.GetQuizQuestions;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Questions.Queries.GetQuestions;

public class GetAllQuestionsQueryHandler(IApplicationDbContext _context) 
    : IRequestHandler<GetQuizQuestionsQuery, IEnumerable<Question>>
{
    public async Task<IEnumerable<Question>> Handle(GetQuizQuestionsQuery request, CancellationToken cancellationToken)
    {
        var quiz = await _context.Quizzes.FindAsync(request.QuizId, cancellationToken);
        
        Guard.Against.NotFound(request.QuizId, quiz);
        
        var questions = await _context
            .Questions
            .Include(question => question.PossibleAnswers)
            .Include(question => question.Quiz)
            .AsNoTracking()
            .Where(question => question.Quiz.Id == request.QuizId)
            .ToListAsync(cancellationToken);

        return questions;
    }
}