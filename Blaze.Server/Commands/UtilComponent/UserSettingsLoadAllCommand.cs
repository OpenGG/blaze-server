// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Collections.Generic;
using System.IO;
using Blaze.Server.Base;
using Blaze.Server.Blaze;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server.Commands.UtilComponent
{
    internal static class UserSettingsLoadAllCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info($"Client {request.Client.ID} loading all user settings for user {request.Client.User.ID}");

            if (File.Exists($".\\data\\{request.Client.User.ID}\\user_settings"))
            {
                var userSettings = File.ReadAllBytes($".\\data\\{request.Client.User.ID}\\user_settings");

                var data = new List<Tdf>
                {
                    new TdfMap("SMAP", TdfBaseType.String, TdfBaseType.String, new Dictionary<object, object>
                    {
                        {"cust", userSettings.ToString()}
                    })
                };

                request.Reply(0, data);
            }
            else
            {
                request.Reply();
            }
        }
    }
}