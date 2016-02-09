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

namespace Blaze.Server.Commands.GameReportingComponent
{
    internal static class SubmitTrustedEndGameReportCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info($"Client {request.Client.ID} submitting trusted end-game report");

            request.Reply();
        }
    }
}