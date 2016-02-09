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
// ReSharper disable UnusedVariable
// ReSharper disable UnusedMember.Global

#endregion

namespace Blaze.Server.Commands.GameManagerComponent
{
    internal class DestroyGameCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger) request.Data["GID"];

            /* if (!GameManager.Games.ContainsKey(gameID.Value))
            {
                request.Reply(0x12D0004, null);
                return;
            } */

            //request.Reply();
        }
    }
}