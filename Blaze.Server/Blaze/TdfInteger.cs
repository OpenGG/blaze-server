// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

namespace Blaze.Server.Blaze
{
    internal sealed class TdfInteger : Tdf
    {
        public readonly ulong Value;

        public TdfInteger(string label, ulong value)
        {
            Label = label;
            Type = TdfBaseType.Integer;

            Value = value;
        }
    }
}