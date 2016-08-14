using GladLive.Payload.Common;
using GladLive.Payload.Lobby;
using GladNet.ASP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladNet.Payload;
using Microsoft.AspNetCore.Mvc;

namespace GladLive.Lobby.Server
{
	/// <summary>
	/// GladLive <see cref="HelloRequestPayload"/> RequestController.
	/// Services initial hellos and creates profiles for incoming hello-ing users.
	/// </summary>
	/// <typeparam name="TLobbyConnectionDetailsType"></typeparam>
	/// <typeparam name="TLobbyDetailsType"></typeparam>
	[PayloadRoute(typeof(HelloRequestPayload))]
	public class HelloRequestController<TLobbyConnectionDetailsType, TLobbyDetailsType> : AuthenticatedRequestController<HelloRequestPayload>
		where TLobbyConnectionDetailsType : class, ILobbyConnectionDetails
		where TLobbyDetailsType : class, ILobbyDetails
	{
		private ILobbyUserRepositoryAsync<TLobbyConnectionDetailsType, TLobbyDetailsType> lobbyUserRepositoryService { get; }

		public HelloRequestController(ILobbyUserRepositoryAsync<TLobbyConnectionDetailsType, TLobbyDetailsType> lobbyUserRepo)
		{
			lobbyUserRepositoryService = lobbyUserRepo;
		}

		[HttpGet]
		public string Get()
		{
			return "Hello, this is the lobby service. You don't speak our language.";
		}

		/// <summary>
		/// Hello request handler. Creates a new lobby user if they've never been seen before.
		/// </summary>
		/// <param name="payloadInstance"></param>
		/// <returns></returns>
		public override async Task<PacketPayload> HandlePost(HelloRequestPayload payloadInstance)
		{
			//This is an authenticated section
			HelloResponseCode responseCode = HelloResponseCode.Unknown;

			bool userAlreadyExists = await lobbyUserRepositoryService.ExistsAsync(GladLiveUserName);

			//If the user exists we're good to go but if not we'll need to create it otherwise they can't
			//do anything on this service.
			if (userAlreadyExists)
				responseCode = HelloResponseCode.HelloSuccess;
			else
			{
				bool resultOfCreation = await lobbyUserRepositoryService.CreateLobbyUserAsync(GladLiveUserName);

				responseCode = resultOfCreation ? HelloResponseCode.HelloSuccess : HelloResponseCode.ServiceUnavailable; 
			}

			return new HelloResponsePayload(responseCode);
		}
	}
}
