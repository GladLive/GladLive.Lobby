using GladLive.Module.System.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GladLive.Lobby.Server;

namespace GladLive.Lobby.PeerToPeer.Module
{
	/// <summary>
	/// Registers the Peer-To-Peer services.
	/// </summary>
	public class P2PServiceRegisterLobbyModule : ServiceRegistrationModule
	{
		public P2PServiceRegisterLobbyModule(IServiceCollection services, Action<DbContextOptionsBuilder> options = null) 
			: base(services, options)
		{

		}

		public override void Register()
		{
			//Register the DbContext but let the caller of this extension dictate the options.
			serviceCollection.AddDbContext<LobbyDbContext<PeerToPeerLobbyConnectionDetails, PeerToPeerLobbyDetails>>(this.DbOptions);

			//Register the lobby user repo
			serviceCollection.AddScoped<ILobbyUserRepositoryAsync<PeerToPeerLobbyConnectionDetails, PeerToPeerLobbyDetails>, LobbyUserRepository<PeerToPeerLobbyConnectionDetails, PeerToPeerLobbyDetails>>();
		}
	}
}
