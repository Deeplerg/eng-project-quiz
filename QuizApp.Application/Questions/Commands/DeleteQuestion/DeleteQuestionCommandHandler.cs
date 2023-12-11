using Ardalis.GuardClauses;
using MediatR;
using QuizApp.Application.Common;

namespace QuizApp.Application.Questions.Commands.DeleteQuestion;

public class DeleteQuestionCommandHandler(IApplicationDbContext _context) 
    : IRequestHandler<DeleteQuestionCommand>
{
    public async Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Questions.FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _context.Questions.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}