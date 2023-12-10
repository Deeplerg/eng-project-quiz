using Ardalis.GuardClauses;
using MediatR;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Quizzes.Commands.DeleteQuiz;

public class DeleteQuizCommandHandler(IApplicationDbContext _context) 
    : IRequestHandler<DeleteQuizCommand>
{
    public async Task Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Quizzes.FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _context.Quizzes.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}