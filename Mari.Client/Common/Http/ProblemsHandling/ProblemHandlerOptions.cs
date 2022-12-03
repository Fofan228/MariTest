using Mari.Http.Models;

namespace Mari.Client.Common.Http.ProblemsHandling;

public class ProblemHandlerOptions
{
    public ProblemHandlerOptions(
        Action<ProblemDetails>? defaultProblemEvent = null,
        Action<ProblemDetails>? validationProblemEvent = null,
        Action<ProblemDetails>? unauthorizedProblemEvent = null,
        Action<ProblemDetails>? notFoundProblemEvent = null,
        Action<ProblemDetails>? errorProblemEvent = null)
    {
        DefaultProblemEvent = defaultProblemEvent;
        ValidationProblemEvent = validationProblemEvent;
        UnauthorizedProblemEvent = unauthorizedProblemEvent;
        NotFoundProblemEvent = notFoundProblemEvent;
        ErrorProblemEvent = errorProblemEvent;
    }

    public Action<ProblemDetails>? DefaultProblemEvent { get; set; }
    public Action<ProblemDetails>? ValidationProblemEvent { get; set; }
    public Action<ProblemDetails>? UnauthorizedProblemEvent { get; set; }
    public Action<ProblemDetails>? NotFoundProblemEvent { get; set; }
    public Action<ProblemDetails>? ErrorProblemEvent { get; set; }
}
