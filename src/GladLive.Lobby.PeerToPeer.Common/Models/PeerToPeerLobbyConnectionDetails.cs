using GladLive.Payload.Lobby;
using GladNet.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GladLive.Lobby.PeerToPeer
{
	/// <summary>
	/// Peer-to-Peer connection details implementatio.
	/// </summary>
	[GladNetSerializationContract]
	public class PeerToPeerLobbyConnectionDetails : ILobbyConnectionDetails
	{
		/// <summary>
		/// Serializable byte array representing the <see cref="IPAddress"/> to be used to connect
		/// to the lobby.
		/// </summary>
		[GladNetMember(GladNetDataIndex.Index1, IsRequired = true)]
		private byte[] lobbyIPBytes;

		private IPAddress _LobbyIP;
		/// <summary>
		/// Represents the IP address that can be connected to
		/// to connect to the lobby.
		/// </summary>
		public IPAddress LobbyIP { get { return _LobbyIP == null ? _LobbyIP = new IPAddress(lobbyIPBytes) : _LobbyIP; } }

		/// <summary>
		/// Represents the port that connection can be established to the lobby.
		/// </summary>
		[GladNetMember(GladNetDataIndex.Index2)]
		public int LobbyPort { get; private set; }

		public PeerToPeerLobbyConnectionDetails(IPAddress lobbyAddress, int lobbyPort)
		{
			if (lobbyAddress == null)
				throw new ArgumentNullException(nameof(lobbyAddress), $"The provided {nameof(IPAddress)} cannot be null.");

			if (lobbyPort < 1)
				throw new ArgumentException("Provided loby port cannot be less than 1.", nameof(lobbyPort));

			lobbyIPBytes = lobbyAddress.GetAddressBytes();
			LobbyPort = lobbyPort;
		}

		/// <summary>
		/// Protected serializer ctor.
		/// </summary>
		protected PeerToPeerLobbyConnectionDetails()
		{

		}
	}
}
