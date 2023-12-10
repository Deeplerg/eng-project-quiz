using MediatR;
using Microsoft.Extensions.Logging;

namespace QuizApp.Application.Behaviors;

public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next.Invoke();
        }
        catch (Exception ex)
        {
            string requestName = typeof(TRequest).Name;
            
            _logger.LogError("Request: Unhandled Exception for Request {RequestName} {@Request}", 
                             requestName, request);

            throw;
        }
    }
}