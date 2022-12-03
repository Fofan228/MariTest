// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Comments.PostRequests.CommentDeleteRequest;

namespace Mari.Contracts.Comments.PostRequests;

public class CommentDeleteRequest : PostRequest<Route, EmptyQuery, EmptyBody, VoidResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}/delete/{{{nameof(Route.id)}}}";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Comment}/delete/{RouteParams!.id}";

    public CommentDeleteRequest(Route route) : base(route, new(), new())
    {
    }

    public record Route(
            Guid id)
        : RequestRoute;
}
