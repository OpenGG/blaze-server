// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using Blaze.Server.Base;
using Blaze.Server.Logging;
using Blaze.Server.Notifications.StatsComponent;

#endregion

namespace Blaze.Server.Commands.StatsComponent
{
    internal static class GetStatsByGroupAsyncCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info($"Client {request.Client.ID} requested stats by group");

            GetStatsAsyncNotification.Notify(request.Client);
        }
    }
}