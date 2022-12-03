using Mari.Http.Models;
using Microsoft.AspNetCore.Http;
using Throw;

namespace Mari.Client.Common.Http.ProblemsHandling;

public class ProblemHandler
{
    public event Action<ProblemDetails> DefaultProblemEvent;
    public event Action<ProblemDetails> ValidationProblemEvent;
    public event Action<ProblemDetails> UnauthorizedProblemEvent;
    public event Action<ProblemDetails> NotFoundProblemEvent;
    public event Action<ProblemDetails> ErrorProblemEvent;

    public ProblemHandler(ProblemHandlerOptions options)
    {
        DefaultProblemEvent = options.DefaultProblemEvent ?? (_ => { });
        ValidationProblemEvent = options.ValidationProblemEvent ?? (_ => { });
        UnauthorizedProblemEvent = options.UnauthorizedProblemEvent ?? (_ => { });
        NotFoundProblemEvent = options.NotFoundProblemEvent ?? (_ => { });
        ErrorProblemEvent = options.ErrorProblemEvent ?? (_ => { });
    }

    public void HandleProblem(ProblemDetails problem)
    {
        problem.ThrowIfNull();
        ErrorProblemEvent(problem);
        switch (problem.Status)
        {
            case StatusCodes.Status400BadRequest
            when problem.Errors is not null && problem.Errors.Count > 0:
                ValidationProblemEvent(problem);
                break;
            case StatusCodes.Status401Unauthorized:
                UnauthorizedProblemEvent(problem);
                break;
            case StatusCodes.Status404NotFound:
                NotFoundProblemEvent(problem);
                break;
            default:
                DefaultProblemEvent(problem);
                break;
        }
    }
}
