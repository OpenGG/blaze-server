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
    internal sealed class TdfMap : Tdf
    {
        public readonly TdfBaseType KeyType;

        public readonly Dictionary<object, object> Map;
        public readonly TdfBaseType ValueType;

        public TdfMap(string label, TdfBaseType keyType, TdfBaseType valueType, Dictionary<object, object> map)
        {
            Label = label;
            Type = TdfBaseType.Map;

            KeyType = keyType;
            ValueType = valueType;

            Map = map;
        }
    }
}