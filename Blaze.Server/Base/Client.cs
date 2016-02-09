// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using Blaze.Server.Blaze;
using Blaze.Server.Components;
using Blaze.Server.Logging;
// ReSharper disable UnusedAutoPropertyAccessor.Local

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedVariable
// ReSharper disable UnusedParameter.Global

#endregion

namespace Blaze.Server.Base
{
    public sealed class Client
    {
        internal Client()
        {
            ReceiveBuffer = new byte[2048];
        }

        internal long ID { get; set; }

        internal ulong GameID { get; set; }

        internal User User { get; set; }

        internal Socket Socket { get; set; }

        internal SslStream Stream { get; set; }

        internal IPEndPoint EndPoint { get; set; }

        internal byte[] ReceiveBuffer { get; }

        private long LastSeen { get; set; }

        internal ClientType Type { get; set; }

        internal ulong Localization { get; set; }

        internal string Service { get; set; }

        internal ulong InternalIP { get; set; }

        internal ushort InternalPort { get; set; }

        internal ulong ExternalIP { get; set; }

        internal ulong ExternalPort { get; set; }

        private void Touch()
        {
            LastSeen = Time.CurrentTime;
        }

        internal void HandleRequest(byte[] buffer, int length)
        {
            Touch();

            var headerSize = ((buffer[9] >> 3) & 4) + ((buffer[9] >> 3) & 2) + 12;

            var componentID = (Component) (buffer[3] | (buffer[2] << 8));
            var commandID = buffer[5] | (buffer[4] << 8);
            var errorCode = buffer[7] | (buffer[6] << 8);
            var messageType = (MessageType) ((buffer[8] >> 4) << 16);
            var messageID = buffer[11] | ((buffer[10] | ((buffer[9] & 0xF) << 8)) << 8);

            var payloadSize = buffer[1] | (buffer[0] << 8);

            if (Convert.ToBoolean(buffer[9] & 0x10))
            {
                payloadSize |= buffer[13] | (buffer[12] << 8) >> 16;
            }

            var payload = buffer.Skip(headerSize).Take(payloadSize).ToArray();

            var decoder = new TdfDecoder(payload);
            var requestData = decoder.Decode();

            var request = new Request(this)
            {
                ComponentID = componentID,
                CommandID = (ushort) commandID,
                ErrorCode = errorCode,
                MessageID = messageID,
                Data = requestData
            };


            HandleRequest(request);
        }

        private static void HandleRequest(Request request)
        {
            switch (request.ComponentID)
            {
                case Component.Authentication:
                    AuthenticationComponent.HandleRequest(request);
                    break;

                case Component.GameManager:
                    GameManagerComponent.HandleRequest(request);
                    break;

                case Component.Redirector:
                    RedirectorComponent.HandleRequest(request);
                    break;

                case Component.Stats:
                    StatsComponent.HandleRequest(request);
                    break;

                case Component.Util:
                    UtilComponent.HandleRequest(request);
                    break;

                case Component.Clubs:
                    ClubsComponent.HandleRequest(request);
                    break;

                case Component.GameReporting:
                    GameReportingComponent.HandleRequest(request);
                    break;

                case Component.RSP:
                    RSPComponent.HandleRequest(request);
                    break;

                case Component.UserSessions:
                    UserSessionsComponent.HandleRequest(request);
                    break;

                default:
                    Log.Info($"Unhandled request: {request.ComponentID} {request.CommandID}");
                    break;
            }
        }

        private void Send(Component componentID, int commandID, int errorCode, MessageType messageType, int messageID,
            List<Tdf> data)
        {
            var payload = new TdfEncoder(data).Encode();
            var stream = new MemoryStream();

            // encode payload size
            stream.WriteByte((byte) ((payload.Length & 0xFFFF) >> 8));
            stream.WriteByte((byte) ((byte) payload.Length & 0xFF));

            // encode header
            stream.WriteByte((byte) (((ushort) componentID >> 8) & 0xFF));
            stream.WriteByte((byte) ((ushort) componentID & 0xFF));

            stream.WriteByte((byte) (((ushort) commandID >> 8) & 0xFF));
            stream.WriteByte((byte) ((ushort) commandID & 0xFF));

            stream.WriteByte((byte) (((byte) errorCode >> 8) & 0xFF));
            stream.WriteByte((byte) ((byte) errorCode & 0xFF));

            stream.WriteByte((byte) ((byte) messageType*16));
            stream.WriteByte((byte) (((byte) messageID >> 16) & 0xF));

            stream.WriteByte((byte) ((byte) messageID >> 8));
            stream.WriteByte((byte) ((byte) messageID & 0xFF));

            if (payload.Length > 0)
            {
                stream.Write(payload, 0, payload.Length);
            }

            var buffer = stream.GetBuffer();
            var position = (int) stream.Position;

            var outData = buffer.Take(position).ToArray();

            Stream.Write(outData, 0, outData.Length);
            Stream.Flush();
        }

        internal void Notify(Component componentID, int commandID, int errorCode, List<Tdf> data)
            => Send(componentID, commandID, errorCode, MessageType.Notification, 0, data);

        internal void Reply(Request request, int errorCode, List<Tdf> data)
        {
            var messageType = errorCode > 0 ? MessageType.ErrorReply : MessageType.Reply;

            Send(request.ComponentID, request.CommandID, errorCode, messageType, request.MessageID, data);
        }
    }
}