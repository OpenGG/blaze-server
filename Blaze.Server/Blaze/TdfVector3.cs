// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

namespace Blaze.Server.Blaze
{
    internal sealed class TdfVector3 : Tdf
    {
        public readonly ulong Value1;
        public readonly ulong Value2;
        public readonly ulong Value3;

        public TdfVector3(string label, ulong value1, ulong value2, ulong value3)
        {
            Label = label;
            Type = TdfBaseType.TDF_TYPE_BLAZE_OBJECT_ID;

            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }
    }
}