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
using Blaze.Server.Notifications.GameManagerComponent;

#endregion

namespace Blaze.Server.Commands.GameManagerComponent
{
    internal static class SetGameSettingsCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger) request.Data["GID"];
            var gameSettings = (TdfInteger) request.Data["GSET"];

            Log.Info($"Client {gameID.Value} setting game settings to {gameSettings.Value}");

            GameManager.GameManager.Games[gameID.Value].Settings = gameSettings.Value;

            request.Reply();

            GameSettingsChangeNotification.Notify(request.Client);
        }
    }
}