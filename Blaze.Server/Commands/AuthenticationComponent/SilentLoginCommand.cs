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
using Blaze.Server.Notifications.UserSessionsComponent;

#endregion

namespace Blaze.Server.Commands.AuthenticationComponent
{
    internal static class SilentLoginCommand
    {
        public static void HandleRequest(Request request)
        {
            var personaID = (TdfInteger) request.Data["PID"];

            var user = Configuration.Users.Find(u => u.ID == personaID.Value);
            request.Client.User = user;

            var data = new List<Tdf>
            {
                new TdfInteger("AGUP", 0),
                new TdfString("LDHT", ""),
                new TdfInteger("NTOS", 0),
                new TdfString("PCTK", ""),
                new TdfString("PRIV", ""),
                new TdfStruct("SESS", new List<Tdf>
                {
                    new TdfInteger("BUID", request.Client.User.ID),
                    new TdfInteger("FRST", 0),
                    new TdfString("KEY", ""),
                    new TdfInteger("LLOG", 0),
                    new TdfString("MAIL", request.Client.User.Email),
                    new TdfStruct("PDTL", new List<Tdf>
                    {
                        new TdfString("DSNM", request.Client.User.Name),
                        new TdfInteger("LAST", 0),
                        new TdfInteger("PID", request.Client.User.ID),
                        new TdfInteger("STAS", 0),
                        new TdfInteger("XREF", 0),
                        new TdfInteger("XTYP", (ulong) ExternalRefType.Unknown)
                    }),
                    new TdfInteger("UID", (ulong) request.Client.ID)
                }),
                new TdfInteger("SPAM", 0),
                new TdfString("THST", ""),
                new TdfString("TSUI", ""),
                new TdfString("TURI", "")
            };

            request.Reply(0, data);

            UserAddedNotification.Notify(request.Client, request.Client.User.ID, request.Client.User.Name);
            UserUpdatedNotification.Notify(request.Client, request.Client.User.ID);
        }
    }
}