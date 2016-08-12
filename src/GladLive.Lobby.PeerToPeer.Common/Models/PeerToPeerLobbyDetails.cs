using GladLive.Payload.Lobby;
using GladNet.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GladLive.Lobby.PeerToPeer
{
	[GladNetSerializationContract]
	public class PeerToPeerLobbyDetails : ILobbyDetails
	{
		/// <summary>
		/// Represents the name of the lobby.
		/// </summary>
		[GladNetMember(GladNetDataIndex.Index1)]
		public string LobbyName { get; private set; }

		/// <summary>
		/// Indicates the maximum capacity of the lobby.
		/// </summary>
		[GladNetMember(GladNetDataIndex.Index2)]
		public int MaximumCapacity { get; private set; }

		/// <summary>
		/// Indicates the current used capacity of the lobby.
		/// </summary>
		[GladNetMember(GladNetDataIndex.Index3)]
		public int UsedCapacity { get; private set; }

		/// <summary>
		/// Indicates the language type of the lobby.
		/// </summary>
		[GladNetMember(GladNetDataIndex.Index4)]
		public LobbyLanguage Language { get; private set; }

		//More can be added later

		/// <summary>
		/// Creates a new <see cref="ILobbyDetails"/> object.
		/// </summary>
		/// <param name="lobbyName">The name of the lobby.</param>
		/// <param name="maximumCapacity">The maximum capacity of the lobby.</param>
		/// <param name="usedCapacity">The current used capacity of the lobby.</param>
		/// <param name="language">The set language of the lobby.</param>
		public PeerToPeerLobbyDetails(string lobbyName, int maximumCapacity, int usedCapacity, LobbyLanguage language)
		{
			LobbyName = lobbyName;
			MaximumCapacity = maximumCapacity;
			UsedCapacity = usedCapacity;
			Language = language;
		}

		/// <summary>
		/// Protected serializer ctor.
		/// </summary>
		protected PeerToPeerLobbyDetails()
		{

		}
	}
}
