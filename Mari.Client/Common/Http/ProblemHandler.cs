using Mari.Http.Models;

namespace Mari.Client.Common.Http;

public class ProblemHandler
{
    public event Action<ProblemDetails> DefaultProblemEvent;
    public event Action<Dictionary<string, string>> ValidationProblemEvent;

    public ProblemHandler()
    {
        DefaultProblemEvent = _ => { };
        ValidationProblemEvent = _ => { };
    }

    public void HandleProblem(ProblemDetails problem)
    {
        DefaultProblemEvent(problem);
        switch (problem.Status)
        {
            case 400:
                break;
        }
    }
}
