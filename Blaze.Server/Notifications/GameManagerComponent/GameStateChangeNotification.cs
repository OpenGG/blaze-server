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
    internal static class GameStateChangeNotification
    {
        public static void Notify(Client client)
        {
            var game = GameManager.GameManager.Games[client.GameID];

            var data = new List<Tdf>
            {
                new TdfInteger("GID", client.GameID),
                new TdfInteger("GSTA", (ulong) game.State)
            };

            client.Notify(Component.GameManager, 0x64, 0, data);
        }
    }
}