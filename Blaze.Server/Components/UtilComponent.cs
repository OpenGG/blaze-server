// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using Blaze.Server.Base;
using Blaze.Server.Commands.UtilComponent;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server.Components
{
    internal static class UtilComponent
    {
        public static void HandleRequest(Request request)
        {
            switch (request.CommandID)
            {
                case 1:
                    FetchClientConfigCommand.HandleRequest(request);
                    break;

                case 2:
                    PingCommand.HandleRequest(request);
                    break;

                case 5:
                    GetTelemetryServerCommand.HandleRequest(request);
                    break;

                case 7:
                    PreAuthCommand.HandleRequest(request);
                    break;

                case 8:
                    PostAuthCommand.HandleRequest(request);
                    break;

                case 0xB:
                    UserSettingsSaveCommand.HandleRequest(request);
                    break;

                case 0xC:
                    UserSettingsLoadAllCommand.HandleRequest(request);
                    break;

                case 0x16:
                    SetClientMetricsCommand.HandleRequest(request);
                    break;

                default:
                    Log.Warn($"Unhandled request: {request.ComponentID} {request.CommandID}");
                    break;
            }
        }
    }
}