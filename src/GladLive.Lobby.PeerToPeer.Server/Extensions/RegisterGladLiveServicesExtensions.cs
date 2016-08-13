using GladLive.Lobby.Server;
using GladNet.Serializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladLive.Lobby.PeerToPeer.Server
{
	public static class RegisterGladLiveServicesExtensions
	{
		/// <summary>
		/// Registers the GladLive Peer-to-Peer lobby services.
		/// </summary>
		/// <param name="mvcBuilder"></param>
		/// <returns></returns>
		public static TMvcBuilderType RegisterGladLiveLobbyP2P<TMvcBuilderType>(this TMvcBuilderType mvcBuilder, ISerializerRegistry registry, Action<DbContextOptionsBuilder> options = null)
			where TMvcBuilderType: IMvcBuilder
		{
			//Register the p2p payloads
			registry.RegisterGladLiveLobbyP2PPayload();

			//Hook into the MVC pipeline to add custom controller register
			mvcBuilder.ConfigureApplicationPartManager(p => p.FeatureProviders.Add(new GenericLobbyControllerFeatureProvider<PeerToPeerLobbyConnectionDetails, PeerToPeerLobbyDetails>()));

			//Register the DbContext but let the caller of this extension dictate the options.
			mvcBuilder.Services.AddDbContext<LobbyDbContext<PeerToPeerLobbyConnectionDetails, PeerToPeerLobbyDetails>>(options);

			return mvcBuilder;
		}
	}
}
