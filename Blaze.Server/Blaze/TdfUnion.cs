// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Collections.Generic;

#endregion

namespace Blaze.Server.Blaze
{
    internal sealed class TdfUnion : Tdf
    {
        public readonly NetworkAddressMember activeMember;
        public readonly List<Tdf> Data;

        public TdfUnion(string label, NetworkAddressMember value, List<Tdf> data)
        {
            Label = label;
            Type = TdfBaseType.Union;

            activeMember = value;
            Data = data;
        }
    }
}