namespace Mari.Http.Models;

public class ProblemOr<TResponse>
{
    public ProblemOr(
        HttpResponseMessage httpResponse,
        TResponse? response = default,
        ProblemDetails? problem = null)
    {
        HttpResponse = httpResponse;
        Response = response;
        Problem = problem;

        if (Problem is null && Response is null)
            throw new ArgumentException("Either response or problem must be non-null.");
    }

    public bool IsSuccess => Problem is null && Response is not null;
    public TResponse? Response { get; }
    public ProblemDetails? Problem { get; }
    public HttpResponseMessage HttpResponse { get; }
}
