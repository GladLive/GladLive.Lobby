using GladLive.Payload.Lobby;
using GladNet.ASP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladNet.Payload;

namespace GladLive.Lobby.Server
{
	/// <summary>
	/// Controller responsible for handling incoming lobby registration requests.
	/// </summary>
	/// <typeparam name="TLobbyConnectionDetailsType"></typeparam>
	/// <typeparam name="TLobbyDetailsType"></typeparam>
	[PayloadRoute(typeof(RegisterNewLobbyRequestPayload<ILobbyConnectionDetails, ILobbyDetails>))] //this will use the non-generic for routing
	public class RegisterLobbyRequestController<TLobbyConnectionDetailsType, TLobbyDetailsType> : AuthenticatedRequestController<RegisterNewLobbyRequestPayload<TLobbyConnectionDetailsType, TLobbyDetailsType>>
		where TLobbyConnectionDetailsType : class, ILobbyConnectionDetails
		where TLobbyDetailsType : class, ILobbyDetails
	{
		private ILobbyUserRepositoryAsync<ILobbyConnectionDetails, ILobbyDetails> lobbyUserRepositoryService { get; }

		public RegisterLobbyRequestController(ILobbyUserRepositoryAsync<ILobbyConnectionDetails, ILobbyDetails> lobbyUserRepo)
		{
			
		}

		public override async Task<PacketPayload> HandlePost(RegisterNewLobbyRequestPayload<TLobbyConnectionDetailsType, TLobbyDetailsType> payloadInstance)
		{
			throw new NotImplementedException();
		}
	}
}
