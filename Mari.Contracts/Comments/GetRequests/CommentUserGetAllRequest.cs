// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Mari.Contracts.Comments.Responce;
using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Releases.GetRequests;
using Mari.Contracts.Releases.Responses;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Comments.GetRequests.CommentUserGetAllRequest;

namespace Mari.Contracts.Comments.GetRequests;

public class CommentUserGetAllRequest : GetRequest<Route, EmptyQuery, IEnumerable<CommentResponse>>
{

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}/user/{{{nameof(Route.id)}}}";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Comment}/user/{RouteParams!.id}";

    public CommentUserGetAllRequest(
        Route route)
        : base(route, new())
    {
    }


    public record Route(Guid id) : RequestRoute;
}
