﻿using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Releases.Responce;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Releases.GetRequests;

public class ReleasePlannedGetRequest : GetRequest<EmptyRoute, EmptyQuery, ReleasesForTabsResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/planned";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Release}";

    public ReleasePlannedGetRequest()
        : base(null, null)
    {
    }


}
