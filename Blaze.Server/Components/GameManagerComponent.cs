// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using Blaze.Server.Base;
using Blaze.Server.Commands.GameManagerComponent;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server.Components
{
    internal static class GameManagerComponent
    {
        public static void HandleRequest(Request request)
        {
            switch (request.CommandID)
            {
                case 1:
                    CreateGameCommand.HandleRequest(request);
                    break;

                case 2:
                    Log.Warn("DESTROY GAME");
                    break;

                case 3:
                    AdvanceGameStateCommand.HandleRequest(request);
                    break;

                case 4:
                    SetGameSettingsCommand.HandleRequest(request);
                    break;

                case 5:
                    Log.Info("SET PLAYER CAPACITY");
                    //SetPlayerCapacityCommand.HandleRequest(request);
                    break;

                case 7:
                    Log.Info("SET GAME ATTRIBUTES");
                    //SetGameAttributesCommand.HandleRequest(request);
                    break;

                case 9:
                    JoinGameCommand.HandleRequest(request);
                    break;

                case 0xB:
                    Log.Warn("*GameManager->HandleRemovePlayerCommand*");
                    //HandleRemovePlayerCommand(clientId, request, stream);
                    break;

                case 0xF:
                    FinalizeGameCreationCommand.HandleRequest(request);
                    break;

                case 0x1D:
                    UpdateMeshConnectionCommand.HandleRequest(request);
                    break;

                default:
                    Log.Warn($"Unhandled request: {request.ComponentID} {request.CommandID}");
                    break;
            }
        }
    }
}