using GladNet.Serializer;
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
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterGladLiveLobbyP2P(this IServiceCollection services, ISerializerRegistry registry)
		{
			//Register the p2p payloads
			registry.RegisterGladLiveLobbyP2PPayload();

			return services;
		}
	}
}
