// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

namespace Blaze.Server.Blaze
{
    internal sealed class TdfVector2 : Tdf
    {
        public readonly ulong Value1;
        public readonly ulong Value2;

        public TdfVector2(string label, ulong value1, ulong value2)
        {
            Label = label;
            Type = TdfBaseType.TDF_TYPE_BLAZE_OBJECT_TYPE;

            Value1 = value1;
            Value2 = value2;
        }
    }
}