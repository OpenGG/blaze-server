// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System;
using System.IO;
using System.Threading;
using Blaze.Server.Base;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Title = "Blaze.Server";

            Log.Initialize("Blaze.Server.log");
            Log.Info("Starting Blaze.Server...");

            Time.Initialize();

            try
            {
                Configuration.Load("Blaze.Server.yml");

                if (Configuration.Users == null)
                {
                    Log.Error("Users configuration was not found.");
                    return;
                }
            }
            catch (IOException)
            {
                Log.Error($"Could not open the configuration file {"Blaze.Server.yml"}.");
                return;
            }

            BlazeHubServer.Start();
            BlazeServer.Start();

            while (true)
            {
                try
                {
                    Log.WriteAway();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }

                Thread.Sleep(1000);
            }
        }
    }
}