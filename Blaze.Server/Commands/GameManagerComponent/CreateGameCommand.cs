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
using Blaze.Server.GameManager;
using Blaze.Server.Logging;
using Blaze.Server.Notifications.GameManagerComponent;

#endregion

// ReSharper disable UnusedVariable

namespace Blaze.Server.Commands.GameManagerComponent
{
    internal static class CreateGameCommand
    {
        public static void HandleRequest(Request request)
        {
            var attr = (TdfMap) request.Data["ATTR"];
            var gameName = (TdfString) request.Data["GNAM"];
            var gameSettings = (TdfInteger) request.Data["GSET"];
            var playerCapacity = (TdfList) request.Data["PCAP"];
            var igno = (TdfInteger) request.Data["IGNO"];
            var pmax = (TdfInteger) request.Data["PMAX"];
            var nres = (TdfInteger) request.Data["NRES"];

            var notResetable = (TdfInteger) request.Data["NTOP"];
            var voip = (TdfInteger) request.Data["VOIP"];

            var presence = (TdfInteger) request.Data["PRES"];
            var qcap = (TdfInteger) request.Data["QCAP"];

            var game = new Game
            {
                ClientID = request.Client.ID,
                Name = gameName.Value,
                Attributes = attr.Map,
                Capacity = playerCapacity.List,
                Level = attr.Map["level"].ToString(),
                GameType = attr.Map["levellocation"].ToString(),
                MaxPlayers = (ushort) pmax.Value,
                NotResetable = (byte) nres.Value,
                QueueCapacity = (ushort) qcap.Value,
                PresenceMode = (PresenceMode) presence.Value,
                State = GameState.Initializing,
                NetworkTopology = (GameNetworkTopology) notResetable.Value,
                VoipTopology = (VoipTopology) voip.Value,
                Settings = gameSettings.Value,
                InternalIP = request.Client.InternalIP,
                InternalPort = request.Client.InternalPort,
                ExternalIP = request.Client.ExternalIP,
                ExternalPort = request.Client.ExternalPort
            };

            GameManager.GameManager.Add(game);

            request.Client.GameID = game.ID;

            Log.Info($"Client {request.Client.ID} creating game {game.ID} ({game.Name})");

            var data = new List<Tdf>
            {
                new TdfInteger("GID", game.ID)
            };

            request.Reply(0, data);

            GameStateChangeNotification.Notify(request.Client);
            GameSetupNotification.Notify(request.Client);
        }
    }
}