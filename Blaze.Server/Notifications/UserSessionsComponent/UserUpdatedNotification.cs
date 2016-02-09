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

namespace Blaze.Server.Notifications.UserSessionsComponent
{
    internal static class UserUpdatedNotification
    {
        public static void Notify(Client client, ulong userID)
        {
            var data = new List<Tdf>
            {
                new TdfInteger("FLGS", 3),
                new TdfInteger("ID", userID)
            };

            client.Notify(Component.UserSessions, 5, 0, data);
        }
    }
}