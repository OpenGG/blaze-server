// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

namespace Blaze.Server.Blaze
{
    internal abstract class TdfMin : Tdf
    {
        public readonly ushort Value;

        protected TdfMin(string label, ushort value)
        {
            Label = label;
            Type = TdfBaseType.Min;

            Value = value;
        }
    }
}