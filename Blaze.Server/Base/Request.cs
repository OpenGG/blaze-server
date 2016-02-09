// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Collections.Generic;
using Blaze.Server.Blaze;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

#endregion

namespace Blaze.Server.Base
{
    public sealed class Request
    {
        internal Request(Client client)
        {
            Client = client;
        }

        internal Client Client { get; }

        internal Component ComponentID { get; set; }

        internal int CommandID { get; set; }

        internal int ErrorCode { get; set; }

        internal MessageType MessageType { get; set; }

        internal int MessageID { get; set; }

        internal Dictionary<string, Tdf> Data { get; set; }

        internal void Reply(int errorCode = 0, List<Tdf> data = null) => Client.Reply(this, errorCode, data);
    }
}