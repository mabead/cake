// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Diagnostics;

namespace Cake.Frosting.Example
{
    public class Program
    {
        public static void SetupCake(ICakeEngine engine)
        {
            var hello = engine.RegisterTask("Hello")
                .Does((context) =>
                {
                    context.Log.Information("Hello!");
                });

            var world = engine.RegisterTask("World")
                .IsDependentOn(hello)
                .Does(async (context) =>
                {
                    context.Log.Information("About to do something expensive");
                    await Task.Delay(1500);
                    context.Log.Information("Done");
                });

            var magic = engine.RegisterTask("Magic")
                .WithCriteria((context) => context.Environment.Platform.Family != PlatformFamily.OSX)
                .IsDependentOn(world)
                .Does((context) =>
                {
                    context.Log.Information("Value is: {0}", context.Arguments.HasArgument("magic"));
                });

            engine.RegisterTask("Default")
                .IsDependentOn(magic);
        }

        public static int Main(string[] args)
        {
            // Create the host.
            var host = new CakeHostBuilder()
                .WithArguments(args)
                .Build();

            // Run the host.
            return host.Run(SetupCake);
        }
    }
}