// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Mari.Contracts.Comments.Responce;
using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Releases.GetRequests;
using Mari.Contracts.Releases.Responce;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Comments.GetRequests.CommentGetAllRequest;

namespace Mari.Contracts.Comments.GetRequests;

public class CommentGetAllRequest : GetRequest<Route, EmptyQuery, IEnumerable<CommentResponse>>
{

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}/{{{nameof(Route.id)}}}";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Comment}/{RouteParams!.id}";
    
    public CommentGetAllRequest(
        Route route)
        : base(route, null)
    {
    }
    

    public record Route(Guid id) : RequestRoute;
}
