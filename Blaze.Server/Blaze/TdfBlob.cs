// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

namespace Blaze.Server.Blaze
{
    internal sealed class TdfBlob : Tdf
    {
        public readonly byte[] Data;

        public TdfBlob(string label, byte[] data)
        {
            Label = label;
            Type = TdfBaseType.Binary;

            Data = data;
        }
    }
}