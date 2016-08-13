using GladLive.Payload.Lobby;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GladLive.Lobby.Server
{
	public class RegisteredLobbyModel<TLobbyConnectionDetailsType, TLobbyDetailsType>
		where TLobbyConnectionDetailsType : class, ILobbyConnectionDetails
		where TLobbyDetailsType : class, ILobbyDetails
	{
		/// <summary>
		/// The key for the registered lobby.
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int LobbyId { get; private set; }

		/// <summary>
		/// The connection details for the lobby.
		/// </summary>
		[Required]
		public TLobbyConnectionDetailsType ConnectionDetails { get; set; }

		/// <summary>
		/// Foriegn key ID for the <see cref="LobbyOwner"/> property.
		/// </summary>
		[Required]
		public int LobbyOwnerId { get; set; }

		/// <summary>
		/// The current owner of the lobby.
		/// </summary>
		[Required]
		[ForeignKey(nameof(LobbyOwnerId))]
		public LobbyUser<TLobbyConnectionDetailsType, TLobbyDetailsType> LobbyOwner { get; set; }

		/// <summary>
		/// The collection of users occupying the lobby.
		/// </summary>
		public virtual List<LobbyUser<TLobbyConnectionDetailsType, TLobbyDetailsType>> LobbyMember { get; set; }
	}
}
