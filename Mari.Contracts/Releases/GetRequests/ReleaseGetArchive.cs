// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Releases.Responce;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Releases.GetRequests;

public class ReleaseGetArchive : GetRequest<EmptyRoute, EmptyQuery, IEnumerable<ReleaseResponse>>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/archive";
    public override string RouteTemplate => ConstRouteTemplate;

    public ReleaseGetArchive()
        : base(new(), new())
    {
    }
}
