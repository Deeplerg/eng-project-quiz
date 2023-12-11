using Ardalis.GuardClauses;
using MediatR;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizResults.Commands.DeleteQuizResult;

public class DeleteQuizResultCommandHandler(IApplicationDbContext _context) 
    : IRequestHandler<DeleteQuizResultCommand>
{
    public async Task Handle(DeleteQuizResultCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QuizResults.FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _context.QuizResults.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}