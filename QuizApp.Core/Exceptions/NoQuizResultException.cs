namespace QuizApp.Core.Exceptions;

public class NoQuizResultException : Exception
{
    public NoQuizResultException() : base("Couldn't find a matching quiz result.")
    {
    }

    public NoQuizResultException(string quizName, int totalScore)
        : base($"Couldn't find a matching quiz result for quiz {quizName} and score {totalScore}")
    {
    }
    
    public NoQuizResultException(string message) : base(message)
    {
    }

    public NoQuizResultException(string message, Exception inner) : base(message, inner)
    {
    }
}