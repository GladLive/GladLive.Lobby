using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using GladLive.Payload.Lobby;

namespace GladLive.Lobby.Server
{
	/// <summary>
	/// The Lobby system database context.
	/// </summary>
	public class LobbyDbContext<TLobbyConnectionDetailsType, TLobbyDetailsType> : DbContext
		where TLobbyConnectionDetailsType : class, ILobbyConnectionDetails
		where TLobbyDetailsType : class, ILobbyDetails
	{
		/// <summary>
		/// Set of the queryable lobby users registered in the context.
		/// </summary>
		public DbSet<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>> LobbyUsers { get; set; }

		/// <summary>
		/// Set of queryable registered lobbies in the context.
		/// </summary>
		public DbSet<RegisteredLobbyModel<TLobbyConnectionDetailsType, TLobbyDetailsType>> RegisteredLobbies { get; set; }

		public LobbyDbContext(DbContextOptions options) 
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Setup the alternative key for the lobby users
			//Usernames should be unique.
			modelBuilder.Entity<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>>()
				.HasAlternateKey(ls => ls.UserName);

			//Foreign keys for the lobbyuser as a lobby owner should be unique.
			modelBuilder.Entity<RegisteredLobbyModel<TLobbyConnectionDetailsType, TLobbyDetailsType>>()
				.HasAlternateKey(rl => rl.LobbyOwnerId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
