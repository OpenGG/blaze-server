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
using Blaze.Server.Logging;
using Blaze.Server.Notifications.GameManagerComponent;
using Blaze.Server.Notifications.UserSessionsComponent;

#endregion

namespace Blaze.Server.Commands.GameManagerComponent
{
    internal static class JoinGameCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger) request.Data["GID"];

            if (!GameManager.GameManager.Games.ContainsKey(gameID.Value))
            {
                request.Reply(0x12D0004);
                return;
            }

            request.Client.GameID = gameID.Value;

            var data = new List<Tdf>
            {
                new TdfInteger("GID", gameID.Value),
                new TdfInteger("JGS", 0)
            };

            request.Reply(0, data);

            var game = GameManager.GameManager.Games[gameID.Value];
            var gameClient = BlazeServer.Clients[game.ClientID];

            game.Slots.Add(request.Client.User.ID);
            var slotID = game.Slots.FindIndex(slot => slot == request.Client.User.ID);

            Log.Info($"Client {request.Client.ID} reserving slot {slotID} in game {gameID.Value}");

            UserAddedNotification.Notify(request.Client, gameClient.User.ID, gameClient.User.Name);
            UserUpdatedNotification.Notify(request.Client, gameClient.User.ID);

            PlayerJoiningNotification.Notify(request.Client);

            JoiningPlayerInitiateConnectionsNotification.Notify(request.Client);
            PlayerClaimingReservationNotification.Notify(request.Client);
        }
    }
}