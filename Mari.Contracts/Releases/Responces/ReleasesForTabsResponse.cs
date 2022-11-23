// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Mari.Contracts.Releases.Responce;

public class ReleasesForTabsResponse
{
    public ReleasesForTabsResponse(IEnumerable<ReleaseResponse> releases)
    {
        Releases = releases.ToArray();
    }
    
    public ReleaseResponse[] Releases { get; set; }
}
