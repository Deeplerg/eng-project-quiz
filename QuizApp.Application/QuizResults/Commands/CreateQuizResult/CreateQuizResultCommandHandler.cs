using Ardalis.GuardClauses;
using MediatR;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizResults.Commands.CreateQuiz;

public class CreateQuizResultCommandHandler(IApplicationDbContext _context)
    : IRequestHandler<CreateQuizResultCommand, QuizResult>
{
    public async Task<QuizResult> Handle(CreateQuizResultCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _context.Quizzes.FindAsync(request.QuizId, cancellationToken);

        Guard.Against.NotFound(request.QuizId, quiz);
        
        var entity = new QuizResult()
        {
            Description = request.Description,
            FromScore = request.FromScore,
            Quiz = quiz
        };
        
        _context.QuizResults.Add(entity);
        
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}