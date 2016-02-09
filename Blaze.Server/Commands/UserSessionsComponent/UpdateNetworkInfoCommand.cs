// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using Blaze.Server.Base;
using Blaze.Server.Blaze;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server.Commands.UserSessionsComponent
{
    internal static class UpdateNetworkInfoCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info($"Client {request.Client.ID} updating network info");

            var addr = (TdfUnion) request.Data["ADDR"];
            var valu = (TdfStruct) addr.Data.Find(tdf => tdf.Label == "VALU");

            var inip = (TdfStruct) valu.Data.Find(tdf => tdf.Label == "INIP");
            var ip = (TdfInteger) inip.Data.Find(tdf => tdf.Label == "IP");
            var port = (TdfInteger) inip.Data.Find(tdf => tdf.Label == "PORT");

            request.Client.InternalIP = ip.Value;
            request.Client.InternalPort = (ushort) port.Value;

            request.Client.ExternalIP = ip.Value;
            request.Client.ExternalPort = (ushort) port.Value;

            request.Reply();
        }
    }
}