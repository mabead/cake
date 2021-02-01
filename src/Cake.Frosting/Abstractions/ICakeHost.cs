// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
// ReSharper disable once CheckNamespace
using Cake.Core;

namespace Cake.Frosting
{
    /// <summary>
    /// Represents a configured Cake host.
    /// </summary>
    public interface ICakeHost
    {
        /// <summary>
        /// Runs the configured Cake host.
        /// </summary>
        /// <returns>An exit code indicating success or failure.</returns>
        int Run(Action<ICakeEngine> setupEngine = null);
    }
}