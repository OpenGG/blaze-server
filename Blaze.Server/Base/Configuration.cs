// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

#endregion

// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Blaze.Server.Base
{
    internal static class Configuration
    {
        public static List<User> Users { get; private set; }

        public static void Load(string filename)
        {
            var buffer = File.ReadAllText("data//" + filename);

            var deserializer = new Deserializer(ignoreUnmatched: true);
            var config = deserializer.Deserialize<Config>(new StringReader(buffer));

            Users = config.Users;
        }

        private struct Config
        {
            public List<User> Users { get; set; }
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    internal class User
    {
        public ulong ID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}