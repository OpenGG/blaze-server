// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Collections.Generic;
using System.Threading;

#endregion

namespace Blaze.Server.GameManager
{
    internal static class GameManager
    {
        public static readonly Dictionary<ulong, Game> Games;

        private static int _gameID;

        static GameManager()
        {
            Games = new Dictionary<ulong, Game>();

            _gameID = 0;
        }

        public static void Add(Game game)
        {
            game.ID = (ulong) Interlocked.Increment(ref _gameID);
            Games.Add(game.ID, game);
        }
    }
}