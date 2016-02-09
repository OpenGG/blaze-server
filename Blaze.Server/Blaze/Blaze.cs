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
    public enum Component
    {
        Authentication = 1,
        GameManager = 4,
        Redirector,
        Stats = 7,
        Util = 9,
        Clubs = 11,
        GameReporting = 0x1C,
        RSP = 0x801,
        UserSessions = 0x7802
    }

    internal enum MessageType
    {
        Message,
        Reply,
        Notification,
        ErrorReply
    }

    internal enum NetworkAddressMember
    {
        XboxClientAddress,
        XboxServerAddress,
        IPPAirAddress,
        IPAddress,
        HostnameAddress,
        Unset = 0x7F
    }

    internal enum UpnpStatus
    {
        Unknown,
        Found,
        Enabled
    }

    internal enum TelemetryOpt
    {
        OptOut,
        OptIn
    }

    internal enum GameState
    {
        NewState,
        Initializing,
        Virtual,
        PreGame = 0x82,
        InGame = 0x83,
        PostGame = 4,
        Migrating,
        Destructing,
        Resetable,
        ReplaySetup
    }

    internal enum PlayerState
    {
        Disconnected,
        Connected = 2
    }

    internal enum PresenceMode
    {
        None,
        Standard,
        Private
    }

    internal enum VoipTopology
    {
        Disabled,
        DedicatedServer,
        PeerToPeer
    }

    internal enum GameNetworkTopology
    {
        ClientServerPeerHosted,
        ClientServerDedicated,
        PeerToPeerFullMesh = 0x82,
        PeerToPeerPartialMesh,
        PeerToPeerDirtyCastFailover
    }

    internal enum PlayerRemovedReason
    {
        PlayerJoinTimeout,
        PlayerConnLost,
        BlazeServerConnLost,
        MigrationFailed,
        GameDestroyed,
        GameEnded,
        PlayerLeft,
        GroupLeft,
        PlayerKicked,
        PlayerKickedWithBan,
        PlayerJoinFromQueueFailed,
        PlayerReservationTimeout,
        HostEjected
    }

    internal enum ClientType
    {
        GameplayUser,
        HttpUser,
        DedicatedServer,
        Tools,
        Invalid
    }

    internal enum ExternalRefType : ushort
    {
        Unknown,
        Xbox,
        PS3,
        Wii,
        Mobile,
        LegacyProfileID,
        Twitter,
        Facebook
    }

    internal enum NatType
    {
        Open,
        Moderate,
        Sequential,
        Strict,
        Unknown
    }
}