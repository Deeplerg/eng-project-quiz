using Ardalis.GuardClauses;
using MediatR;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizSubmissions.Commands.DeleteQuizSubmission;

public class DeleteQuizSubmissionCommandHandler(IApplicationDbContext _context) 
    : IRequestHandler<DeleteQuizSubmissionCommand>
{
    public async Task Handle(DeleteQuizSubmissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QuizSubmissions.FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _context.QuizSubmissions.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}