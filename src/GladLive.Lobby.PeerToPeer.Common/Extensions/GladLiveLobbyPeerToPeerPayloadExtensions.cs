using GladLive.Lobby.PeerToPeer;
using GladLive.Payload.Lobby;
using GladNet.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;

public static class GladLiveLobbyPeerToPeerPayloadExtensions
{
	/// <summary>
	/// Register the Lobby Peer-To-Peer payloads with the <see cref="ISerializerRegistry"/>.
	/// </summary>
	/// <typeparam name="TSerializerRegistryType"></typeparam>
	/// <param name="registry"></param>
	/// <returns></returns>
	public static TSerializerRegistryType RegisterGladLiveLobbyP2PPayload<TSerializerRegistryType>(this TSerializerRegistryType registry)
		where TSerializerRegistryType : ISerializerRegistry
	{
		//Register the generic types; these are generic to allow for a common library that doesn't depend directly on an implementation.
		//Some may P2P but others could be central server bassed.
		registry.Register(typeof(RegisterNewLobbyRequestPayload<PeerToPeerLobbyConnectionDetails, PeerToPeerLobbyDetails>));
		registry.Register(typeof(UpdateLobbyStatusRequestPayload<PeerToPeerLobbyDetails>));

		registry.Register(typeof(UpdateLobbyStatusResponsePayload));
		registry.Register(typeof(RegisterNewLobbyResponsePayload));

		return registry;
	}
}

