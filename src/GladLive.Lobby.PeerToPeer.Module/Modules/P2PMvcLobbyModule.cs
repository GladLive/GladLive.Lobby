using GladLive.Module.System.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using GladLive.Lobby.Module;
using GladLive.Lobby.Server;

namespace GladLive.Lobby.PeerToPeer.Module
{
	/// <summary>
	/// Registers the Peer-To-Peer MVC components for the lobby.
	/// </summary>
	public class P2PMvcLobbyModule : MvcBuilderServiceRegistrationModule
	{
		public P2PMvcLobbyModule(IMvcBuilder mvcBuilderService) 
			: base(mvcBuilderService)
		{

		}

		public override void Register()
		{
			//Hook into the MVC pipeline to add custom controller register
			mvcBuilderService.ConfigureApplicationPartManager(p => p.FeatureProviders.Add(new GenericLobbyControllerFeatureProvider<PeerToPeerLobbyConnectionDetails, PeerToPeerLobbyDetails>()));
			mvcBuilderService.ConfigureApplicationPartManager(p => p.FeatureProviders.Add(new GenericLobbyControllerFeatureProvider<PeerToPeerLobbyConnectionDetails, PeerToPeerLobbyDetails>()));

			
		}
	}
}
