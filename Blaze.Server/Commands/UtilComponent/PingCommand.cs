// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Collections.Generic;
using Blaze.Server.Base;
using Blaze.Server.Blaze;

#endregion

namespace Blaze.Server.Commands.UtilComponent
{
    internal static class PingCommand
    {
        public static void HandleRequest(Request request)
        {
            var data = new List<Tdf>
            {
                new TdfInteger("STIM", Utils.GetUnixTime())
            };

            request.Reply(0, data);
        }
    }
}