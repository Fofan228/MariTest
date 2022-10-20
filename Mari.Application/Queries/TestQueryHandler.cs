using ErrorOr;
using MediatR;
using Mari.Domain.Common;

namespace Mari.Application.Queries;

public class TestQueryHandler : IRequestHandler<TestQuery, ErrorOr<string>>
{
    public Task<ErrorOr<string>> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult((ErrorOr<string>)Errors.Test.TestError);
    }
}