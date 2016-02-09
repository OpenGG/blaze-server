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
    internal static class PlayerRemovedNotification
    {
        public static void Notify(Client client, ulong playerID)
        {
            var data = new List<Tdf>
            {
                new TdfInteger("GID", client.GameID),
                new TdfInteger("PID", playerID),
                new TdfInteger("REAS", 1)
            };

            client.Notify(Component.GameManager, 0x28, 0, data);
        }
    }
}