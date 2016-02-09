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
    internal static class AdvanceGameStateCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger) request.Data["GID"];
            var gameState = (TdfInteger) request.Data["GSTA"];

            Log.Info($"Client {request.Client.ID} changing game {gameID.Value} state to {(GameState) gameState.Value}");

            var game = GameManager.GameManager.Games[gameID.Value];
            game.State = (GameState) gameState.Value;

            request.Reply();

            GameStateChangeNotification.Notify(request.Client);
        }
    }
}