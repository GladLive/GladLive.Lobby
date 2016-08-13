using GladLive.Payload.Lobby;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GladLive.Lobby.Server
{
	/// <summary>
	/// Represents a user on the lobby server.
	/// </summary>
	public class LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>
		where TLobbyConnectionDetailsType : class, ILobbyConnectionDetails
		where TLobbyDetailsType : class, ILobbyDetails
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int LobbyUserId { get; private set; }

		/// <summary>
		/// Username of the user.
		/// </summary>
		[Required]
		public string UserName { get; set; } //WARNING: There is no support in EF7 for annoations denoting uniqueness or multiple indexing.

		/// <summary>
		/// Foreign key for the <see cref="CurrentLobby"/> which could be null if
		/// the <see cref="LobbyUserModel{TLobbyConnectionDetailsType, TLobbyDetailsType}"/> is not in a lobby.
		/// </summary>
		public int? CurrentLobbyId { get; set; }

		/// <summary>
		/// Possible lobby the user may be in. A user can ONLY be in a single lobby at a time or in no lobby at all.
		/// </summary>
		[ForeignKey(nameof(CurrentLobbyId))]
		public virtual RegisteredLobbyModel<TLobbyConnectionDetailsType, TLobbyDetailsType> CurrentLobby { get; set; }
	}
}
