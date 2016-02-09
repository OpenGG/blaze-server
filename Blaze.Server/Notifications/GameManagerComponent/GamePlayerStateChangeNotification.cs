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

namespace Blaze.Server.Notifications.GameManagerComponent
{
    internal static class GamePlayerStateChangeNotification
    {
        public static void Notify(Client client, ulong gameID, ulong personaID)
        {
            //var game = GameManager.Games[client.GameID];
            //var gameClient = BlazeServer.Clients[game.ClientID];

            var data = new List<Tdf>
            {
                //new TdfInteger("GID", client.GameID),
                //new TdfInteger("PID", (client.Type == ClientType.GameplayUser) ? gameClient.User.ID : client.User.ID),
                new TdfInteger("GID", gameID),
                new TdfInteger("PID", personaID),
                new TdfInteger("STAT", 4)
            };

            client.Notify(Component.GameManager, 0x74, 0, data);
        }
    }
}