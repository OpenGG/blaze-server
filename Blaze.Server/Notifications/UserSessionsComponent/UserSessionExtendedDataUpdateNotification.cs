// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.Collections;
using System.Collections.Generic;
using Blaze.Server.Base;
using Blaze.Server.Blaze;
// ReSharper disable UnusedMember.Global

#endregion

namespace Blaze.Server.Notifications.UserSessionsComponent
{
    internal class UserSessionExtendedDataUpdateNotification
    {
        public static void Notify(Client client, bool ulst = false, bool joining = false)
        {
            var pslm = new TdfList("PSLM", TdfBaseType.Integer, new ArrayList());
            pslm.List.AddRange(new ulong[] {268374015, 268374015, 268374015, 268374015, 268374015});

            var data = new List<Tdf>
            {
                new TdfStruct("DATA", new List<Tdf>
                {
                    new TdfUnion("ADDR", NetworkAddressMember.IPPAirAddress, new List<Tdf>
                    {
                        new TdfStruct("VALU", new List<Tdf>
                        {
                            new TdfStruct("EXIP", new List<Tdf>
                            {
                                new TdfInteger("IP", client.ExternalIP),
                                new TdfInteger("PORT", client.ExternalPort)
                            }),
                            new TdfStruct("INIP", new List<Tdf>
                            {
                                new TdfInteger("IP", client.InternalIP),
                                new TdfInteger("PORT", client.InternalPort)
                            })
                        })
                    }),
                    new TdfString("BPS", "ams"),
                    new TdfString("CTY", ""),
                    new TdfInteger("HWFG", 0),
                    pslm,
                    new TdfInteger("UATT", 0)
                }),
                new TdfInteger("USID", client.User.ID)
            };

            if (ulst)
            {
                ((TdfStruct) data[0]).Data.Add(new TdfList("ULST", TdfBaseType.TDF_TYPE_BLAZE_OBJECT_ID, new ArrayList
                {
                    new TdfVector3("0", 4, 1, client.GameID)
                }));
            }

            if (joining)
            {
                var game = GameManager.GameManager.Games[client.GameID];
                var gameClient = BlazeServer.Clients[game.ClientID];

                gameClient.Notify(Component.UserSessions, 1, 0, data);
            }
            else
            {
                client.Notify(Component.UserSessions, 1, 0, data);
            }
        }
    }
}