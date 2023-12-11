using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Infrastructure.Data;
using QuizApp.Middleware;

namespace QuizApp.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        string corsPolicyName)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
        
        services.AddCors(options =>
        {
            options.AddPolicy(name: corsPolicyName,
                policy  =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        
        return services;
    }
}