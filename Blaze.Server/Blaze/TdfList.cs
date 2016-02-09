// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Collections;

#endregion

namespace Blaze.Server.Blaze
{
    internal sealed class TdfList : Tdf
    {
        public readonly ArrayList List;
        public readonly TdfBaseType ListType;

        public readonly bool Stub;

        public TdfList(string label, TdfBaseType listType, ArrayList list, bool stub = false)
        {
            Label = label;
            Type = TdfBaseType.List;

            ListType = listType;
            List = list;

            Stub = stub;
        }
    }
}