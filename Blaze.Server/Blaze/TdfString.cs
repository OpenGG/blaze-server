// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

namespace Blaze.Server.Blaze
{
    internal sealed class TdfString : Tdf
    {
        public readonly string Value;

        public TdfString(string label, string value)
        {
            Label = label;
            Type = TdfBaseType.String;

            Value = value;
        }
    }
}