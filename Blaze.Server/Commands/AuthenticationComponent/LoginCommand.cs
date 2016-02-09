// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Collections;
using System.Collections.Generic;
using Blaze.Server.Base;
using Blaze.Server.Blaze;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server.Commands.AuthenticationComponent
{
    internal static class LoginCommand
    {
        public static void HandleRequest(Request request)
        {
            var email = (TdfString) request.Data["MAIL"];

            Log.Info($"Client {request.Client.ID} logging in with email {email.Value}");

            var user = Configuration.Users.Find(u => u.Email == email.Value);

            if (user == null)
            {
                Log.Warn("User not found");
                return;
            }

            request.Client.User = user;

            var data = new List<Tdf>
            {
                new TdfString("LDHT", ""),
                new TdfInteger("NTOS", 0),
                new TdfString("PCTK", ""),
                new TdfList("PLST", TdfBaseType.Struct, new ArrayList
                {
                    new List<Tdf>
                    {
                        new TdfString("DSNM", user.Name),
                        new TdfInteger("LAST", 0),
                        new TdfInteger("PID", user.ID),
                        new TdfInteger("STAS", 2),
                        new TdfInteger("XREF", 0),
                        new TdfInteger("XTYP", (ulong) ExternalRefType.Unknown)
                    }
                }),
                new TdfString("PRIV", ""),
                new TdfString("SKEY", ""),
                new TdfInteger("SPAM", 1),
                new TdfString("THST", ""),
                new TdfString("TSUI", ""),
                new TdfString("TURI", ""),
                new TdfInteger("UID", (ulong) request.Client.ID)
            };

            request.Reply(0, data);
        }
    }
}