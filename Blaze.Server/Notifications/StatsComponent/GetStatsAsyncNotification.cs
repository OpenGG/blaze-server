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

namespace Blaze.Server.Notifications.StatsComponent
{
    internal static class GetStatsAsyncNotification
    {
        public static void Notify(Client client)
        {
            var data = new List<Tdf>();

            client.Notify(Component.Stats, 0x32, 0, data);
        }
    }
}