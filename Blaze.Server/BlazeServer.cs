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
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading;
using Blaze.Server.Base;
using Blaze.Server.Blaze;
using Blaze.Server.Logging;

#endregion

namespace Blaze.Server
{
    internal static class BlazeServer
    {
        private static readonly Socket _socket;

        private static long _clientID;

        public static readonly Dictionary<long, Client> Clients;

        static BlazeServer()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clientID = 0;

            Clients = new Dictionary<long, Client>();
        }

        public static void Start()
        {
            Log.Info("Starting BlazeServer");

            _socket.Bind(new IPEndPoint(IPAddress.Any, 10041));
            _socket.Listen(1);

            _socket.BeginAccept(AcceptCallback, _socket);
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            var socket = (Socket) ar.AsyncState;

            try
            {
                var clientSocket = socket.EndAccept(ar);

                Log.Info($"Client connected from {clientSocket.RemoteEndPoint}");

                var client = new Client
                {
                    ID = Interlocked.Increment(ref _clientID),
                    Socket = clientSocket,
                    Stream = new SslStream(new NetworkStream(clientSocket)),
                    EndPoint = (IPEndPoint) clientSocket.RemoteEndPoint
                };


                Clients.Add(client.ID, client);

                client.Stream.BeginAuthenticateAsServer(Certificate.BlazeServer, AuthenticateAsServerCallback, client.ID);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }

            socket.BeginAccept(AcceptCallback, socket);
        }

        private static void AuthenticateAsServerCallback(IAsyncResult ar)
        {
            try
            {
                var clientID = (long) ar.AsyncState;
                var client = Clients[clientID];

                client.Stream.EndAuthenticateAsServer(ar);

                client.Stream.BeginRead(client.ReceiveBuffer, 0, client.ReceiveBuffer.Length, ReadCallback, clientID);
            }
            catch
            {
                CloseSocket(ar);
            }
        }

        private static void ReadCallback(IAsyncResult ar)
        {
            try
            {
                var clientID = (long) ar.AsyncState;
                var client = Clients[clientID];

                var length = client.Stream.EndRead(ar);

                if (length == 0)
                {
                    CloseSocket(ar);
                    return;
                }

                client.HandleRequest(client.ReceiveBuffer, length);

                client.Stream.BeginRead(client.ReceiveBuffer, 0, client.ReceiveBuffer.Length, ReadCallback, clientID);
            }
            catch
            {
                CloseSocket(ar);
            }
        }

        private static void CloseSocket(IAsyncResult ar)
        {
            try
            {
                var clientID = (long) ar.AsyncState;
                var client = Clients[clientID];

                if (client.Type == ClientType.DedicatedServer)
                {
                    lock (GameManager.GameManager.Games)
                    {
                        if (GameManager.GameManager.Games.ContainsKey(client.GameID))
                        {
                            Log.Info($"Removing game {client.GameID}");

                            GameManager.GameManager.Games.Remove(client.GameID);
                        }
                    }
                }

                lock (Clients)
                {
                    if (Clients.ContainsKey(client.ID))
                    {
                        Clients.Remove(client.ID);
                    }
                }

                try
                {
                    client.Socket.Shutdown(SocketShutdown.Both);
                }
                catch
                {
                    // Ignored
                }

                client.Socket.Close();

                Log.Info($"Client {clientID} disconnected");
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }
    }
}