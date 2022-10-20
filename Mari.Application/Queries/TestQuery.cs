using ErrorOr;
using MediatR;

namespace Mari.Application.Queries;

public record TestQuery(string SomeText) : IRequest<ErrorOr<string>>;