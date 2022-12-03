﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Mari.Contracts.Platforms.Responces;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IPlatformManager
{
    Task<IList<PlatformResponce>> GetAll(CancellationToken token = default);
}
