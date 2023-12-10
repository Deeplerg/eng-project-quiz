using FluentValidation;

namespace QuizApp.Application.Quizzes.Commands.CreateQuiz;

public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
{
    public CreateQuizCommandValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty();
    }
}