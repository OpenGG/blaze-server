// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using Blaze.Server.Base;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server.Commands.RSPComponent
{
    internal static class GetConfigCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info($"Client {request.Client.ID} requested RSP configuration");

            foreach (var tdf in request.Data)
            {
                Log.Info(tdf.Key + "(" + tdf.Value.Type + ")");
            }

            request.Reply();
        }
    }
}