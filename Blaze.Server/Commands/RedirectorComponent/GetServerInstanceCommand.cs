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

#endregion

namespace Blaze.Server.Commands.RedirectorComponent
{
    internal static class GetServerInstanceCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info($"Client {request.Client.ID} requesting ServerInstanceInfo");

            request.Reply(0, new List<Tdf>
            {
                new TdfUnion("ADDR", NetworkAddressMember.XboxClientAddress, new List<Tdf>
                {
                    new TdfStruct("VALU", new List<Tdf>
                    {
                        new TdfString("HOST", "373244-gosprapp357.ea.com"),
                        new TdfInteger("IP", 0),
                        new TdfInteger("PORT", 10041)
                    })
                }),
                new TdfInteger("SECU", 1),
                new TdfInteger("XDNS", 0)
            });
        }
    }
}