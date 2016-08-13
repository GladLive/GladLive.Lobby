using GladLive.Payload.Lobby;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GladLive.Lobby.Server
{
	//Based on: https://github.com/aspnet/Entropy/commit/42171b7
	/// <summary>
	/// Register the closed generic versions of the <see cref="GladLive.Lobby.Server"/> controllers.
	/// </summary>
	/// <typeparam name="TLobbyConnectionDetailsType">The lobby connection details type to register with.</typeparam>
	/// <typeparam name="TLobbyDetailsType">The lobby details type to register with.</typeparam>
	public class GenericLobbyControllerFeatureProvider<TLobbyConnectionDetailsType, TLobbyDetailsType> : IApplicationFeatureProvider<ControllerFeature>
		where TLobbyConnectionDetailsType : class, ILobbyConnectionDetails
		where TLobbyDetailsType : class, ILobbyDetails
	{
		/// <summary>
		/// Registers the closed generic controller for lobby requests.
		/// </summary>
		/// <param name="parts"></param>
		/// <param name="feature"></param>
		public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
		{
			feature.Controllers.Add(typeof(RegisterLobbyRequestController<TLobbyConnectionDetailsType, TLobbyDetailsType>).GetTypeInfo());
			feature.Controllers.Add(typeof(HelloRequestController<TLobbyConnectionDetailsType, TLobbyDetailsType>).GetTypeInfo());
			
		}
	}
}
