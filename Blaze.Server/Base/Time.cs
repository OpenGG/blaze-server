// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Diagnostics;

#endregion

namespace Blaze.Server.Base
{
    internal static class Time
    {
        private static long _initialCount;

        public static long CurrentTime => (Stopwatch.GetTimestamp() - _initialCount)/(Stopwatch.Frequency/1000);

        public static void Initialize()
        {
            _initialCount = Stopwatch.GetTimestamp();
        }
    }
}