// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using Blaze.Server.Base;
using Blaze.Server.Blaze;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server.Commands.GameManagerComponent
{
    internal static class FinalizeGameCreationCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger) request.Data["GID"];

            Log.Info($"Client {request.Client.ID} updating game {gameID.Value} session");

            request.Reply();
        }
    }
}