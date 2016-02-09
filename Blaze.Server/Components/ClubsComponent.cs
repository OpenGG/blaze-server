// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using Blaze.Server.Base;
using Blaze.Server.Commands.ClubsComponent;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server.Components
{
    internal static class ClubsComponent
    {
        public static void HandleRequest(Request request)
        {
            switch (request.CommandID)
            {
                case 0xA8C:
                    GetClubMembershipForUsersCommand.HandleRequest(request);
                    break;

                default:
                    Log.Warn($"Unhandled request: {request.ComponentID} {request.CommandID}");
                    break;
            }
        }
    }
}