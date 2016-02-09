// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

// ReSharper disable UnusedMember.Global
namespace Blaze.Server.Blaze
{
    public enum TdfBaseType
    {
        Min,
        Integer = 0,
        String,
        Binary,
        Struct,
        List,
        Map,
        Union,
        Variable,
        TDF_TYPE_BLAZE_OBJECT_TYPE,
        TDF_TYPE_BLAZE_OBJECT_ID,
        Float = 0xA,
        TimeValue = 0xB,
        Max = 0xC
    }

    public class Tdf
    {
        internal string Label;
        internal TdfBaseType Type;
    }
}