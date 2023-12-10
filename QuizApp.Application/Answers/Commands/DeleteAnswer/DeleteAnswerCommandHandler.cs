using Ardalis.GuardClauses;
using MediatR;
using QuizApp.Application.Common;

namespace QuizApp.Application.Answers.Commands.DeleteAnswer;

public class DeleteAnswerCommandHandler(IApplicationDbContext _context) 
    : IRequestHandler<DeleteAnswerCommand>
{
    public async Task Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Answers.FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _context.Answers.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}