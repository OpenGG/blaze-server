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
// ReSharper disable SwitchStatementMissingSomeCases

#endregion

namespace Blaze.Server.Commands.GameManagerComponent
{
    internal static class UpdateMeshConnectionCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info($"Client {request.Client.ID} updating mesh connection");

            var gameID = (TdfInteger) request.Data["GID"];

            var targ = (TdfList) request.Data["TARG"];
            var targData = (List<Tdf>) targ.List[0];
            var playerID = (TdfInteger) targData[1];
            var stat = (TdfInteger) targData[2];

            request.Reply();

            switch (stat.Value)
            {
                case 2:
                    switch (request.Client.Type)
                    {
                        case ClientType.GameplayUser:
                            GamePlayerStateChangeNotification.Notify(request.Client, gameID.Value, request.Client.User.ID);
                            PlayerJoinCompletedNotification.Notify(request.Client, gameID.Value, request.Client.User.ID);
                            break;
                        case ClientType.DedicatedServer:
                            GamePlayerStateChangeNotification.Notify(request.Client, gameID.Value, playerID.Value);
                            PlayerJoinCompletedNotification.Notify(request.Client, gameID.Value, playerID.Value);
                            break;
                    }
                    break;
                case 0:
                    switch (request.Client.Type)
                    {
                        case ClientType.GameplayUser:
                        {
                            var game = GameManager.GameManager.Games[gameID.Value];
                            game.Slots.Remove(playerID.Value);

                            PlayerRemovedNotification.Notify(request.Client, playerID.Value);
                        }
                            break;
                        case ClientType.DedicatedServer:
                        {
                            var game = GameManager.GameManager.Games[gameID.Value];
                            game.Slots.Remove(playerID.Value);

                            PlayerRemovedNotification.Notify(request.Client, playerID.Value);
                        }
                            break;
                    }
                    break;
            }
        }
    }
}