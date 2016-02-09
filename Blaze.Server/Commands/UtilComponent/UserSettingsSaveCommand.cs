// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.IO;
using System.Text;
using Blaze.Server.Base;
using Blaze.Server.Blaze;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server.Commands.UtilComponent
{
    internal static class UserSettingsSaveCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info($"Client {request.Client.ID} saving user settings for user {request.Client.User.ID}");

            var data = (TdfString) request.Data["DATA"];

            Directory.CreateDirectory($".\\data\\{request.Client.User.ID}");

            if (File.Exists($".\\data\\{request.Client.User.ID}\\user_settings"))
            {
                File.Delete($".\\data\\{request.Client.User.ID}\\user_settings");
            }

            File.WriteAllBytes($".\\data\\{request.Client.User.ID}\\user_settings", Encoding.ASCII.GetBytes(data.Value));

            request.Reply();
        }
    }
}