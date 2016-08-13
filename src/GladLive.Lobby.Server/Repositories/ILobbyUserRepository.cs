using GladLive.Payload.Lobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladLive.Lobby.Server
{
	/// <summary>
	/// Repository service for <see cref="LobbyUserModel{TLobbyConnectionDetailsType, TLobbyDetailsType}"/> model objects.
	/// </summary>
	public interface ILobbyUserRepository<TLobbyConnectionDetailsType, TLobbyDetailsType> : IRepository<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>>
		where TLobbyConnectionDetailsType : class, ILobbyConnectionDetails
		where TLobbyDetailsType : class, ILobbyDetails
	{
		/// <summary>
		/// Queries for the <see cref="LobbyUser"/> by the <see cref="string"/>
		/// name of the <see cref="LobbyUser"/>.
		/// </summary>
		/// <param name="userName">User name of the <see cref="LobbyUser"/>.</param>
		/// <returns>The <see cref="LobbyUser"/> with the matching <paramref name="userName"/> or null.</returns>
		LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType> GetByLobbyUserName(string userName);

		/// <summary>
		/// Queries for the addition of <see cref="LobbyUser"/> by the <see cref="string"/>
		/// name of the <see cref="LobbyUser"/>.
		/// </summary>
		/// <param name="userName">User name of the <see cref="LobbyUser"/>.</param>
		/// <returns>A the result of trying to add <see cref="LobbyUser"/> with the matching <paramref name="userName"/>.</returns>
		bool CreateLobbyUser(string userName);
	}

	/// <summary>
	/// Repository service for <see cref=LobbyUserModel{TLobbyConnectionDetailsType, TLobbyDetailsType}"/> model objects.
	/// </summary>
	public interface ILobbyUserRepositoryAsync<TLobbyConnectionDetailsType, TLobbyDetailsType> : IRepositoryAsync<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>>
		where TLobbyConnectionDetailsType : class, ILobbyConnectionDetails
		where TLobbyDetailsType : class, ILobbyDetails
	{
		/// <summary>
		/// Asyncronously queries for the addition of <see cref="LobbyUser"/> by the <see cref="string"/>
		/// name of the <see cref="LobbyUser"/>.
		/// </summary>
		/// <param name="userName">User name of the <see cref="LobbyUser"/>.</param>
		/// <returns>A future of the result of trying to add <see cref="LobbyUser"/> with the matching <paramref name="userName"/>.</returns>
		Task<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>> GetByLobbyUserNameAsync(string userName);

		/// <summary>
		/// Asyncronously queries for the <see cref="LobbyUser"/> by the <see cref="string"/>
		/// name of the <see cref="LobbyUser"/>.
		/// </summary>
		/// <param name="userName">User name of the <see cref="LobbyUser"/>.</param>
		/// <returns>A future of the <see cref="LobbyUser"/> with the matching <paramref name="userName"/> or null.</returns>
		Task<bool> CreateLobbyUserAsync(string userName);
	}
}
