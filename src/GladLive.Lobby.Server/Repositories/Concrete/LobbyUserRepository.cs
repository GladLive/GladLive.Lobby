using GladLive.Payload.Lobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladLive.Lobby.Server
{
	/// <summary>
	/// Concrete repository for <see cref="LobbyUser"/> / <see cref="LobbyDbContext"/>.
	/// </summary>
	public class LobbyUserRepository<TLobbyConnectionDetailsType, TLobbyDetailsType> : Repository<LobbyDbContext<TLobbyConnectionDetailsType, TLobbyDetailsType>>, ILobbyUserRepository<TLobbyConnectionDetailsType, TLobbyDetailsType>, ILobbyUserRepositoryAsync<TLobbyConnectionDetailsType, TLobbyDetailsType>
		where TLobbyConnectionDetailsType : class, ILobbyConnectionDetails
		where TLobbyDetailsType : class, ILobbyDetails 
	{
		public LobbyUserRepository(LobbyDbContext<TLobbyConnectionDetailsType, TLobbyDetailsType> context)
			: base(context)
		{

		}

		/// <summary>
		/// Queries for the addition of <see cref="LobbyUser"/> by the <see cref="string"/>
		/// name of the <see cref="LobbyUser"/>.
		/// </summary>
		/// <param name="userName">User name of the <see cref="LobbyUser"/>.</param>
		/// <returns>A the result of trying to add <see cref="LobbyUser"/> with the matching <paramref name="userName"/>.</returns>
		public bool CreateLobbyUser(string userName)
		{
			databaseContext.LobbyUsers.Add(new LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>()
			{
				//Only need username to create it
				UserName = userName
			});

			return databaseContext.SaveChanges() != 0;
		}

		/// <summary>
		/// Asyncronously queries for the <see cref="LobbyUser"/> by the <see cref="string"/>
		/// name of the <see cref="LobbyUser"/>.
		/// </summary>
		/// <param name="userName">User name of the <see cref="LobbyUser"/>.</param>
		/// <returns>A future of the <see cref="LobbyUser"/> with the matching <paramref name="userName"/> or null.</returns>
		public async Task<bool> CreateLobbyUserAsync(string userName)
		{
			databaseContext.LobbyUsers.Add(new LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>()
			{
				//Only need username to create it
				UserName = userName
			});

			return (await databaseContext.SaveChangesAsync()) != 0;
		}

		/// <summary>
		/// Queries for the existence of the model by the id.
		/// </summary>
		/// <param name="id">Model id.</param>
		/// <returns>True if the model exists or false otherwise.</returns>
		public bool Exists(int id)
		{
			//Indicates if at least one account exists with that id (should be unique though)
			return databaseContext.LobbyUsers
				.Where(x => x.LobbyUserId == id)
				.Count() != 0;
		}

		/// <summary>
		/// Async queries for the existence of the model by the <see cref="userName"/>
		/// </summary>
		/// <param name="userName">Model username.</param>
		/// <returns>A future bool of True if the model exists or false otherwise.</returns>
		public async Task<bool> ExistsAsync(string userName)
		{
			return (await databaseContext.LobbyUsers.ToAsyncEnumerable()
				.Where(x => x.UserName == userName)
				.Count()) != 0;
		}

		/// <summary>
		/// Async queries for the existence of the model by the id.
		/// </summary>
		/// <param name="id">Model id.</param>
		/// <returns>A future bool of True if the model exists or false otherwise.</returns>
		public async Task<bool> ExistsAsync(int id)
		{
			//Async: indicates if at least one account exists with that id (should be unique though)
			IEnumerable<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>> accounts = await databaseContext.LobbyUsers.ToAsyncEnumerable()
				.Where(ax => ax.LobbyUserId == id).ToList();

			return accounts.Count() != 0;
		}

		/// <summary>
		/// Queries for the model instance by the id.
		/// </summary>
		/// <param name="id">Model id.</param>
		/// <returns>The model instance or null if not found.</returns>
		public LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType> Get(int id)
		{
			return databaseContext.LobbyUsers
				.FirstOrDefault(x => x.LobbyUserId == id);
		}

		/// <summary>
		/// Queries for a non-lazy collection of all <see cref="LobbyUser"/> models.
		/// </summary>
		/// <returns>A non-lazy non-null collection of all <see cref="LobbyUser"/>s.</returns>
		public IEnumerable<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>> GetAll()
		{
			return databaseContext.LobbyUsers;
		}

		/// <summary>
		/// Async queries for a non-lazy collection of all <see cref="LobbyUser"/> models.
		/// </summary>
		/// <returns>A non-lazy non-null future collection of all <see cref="LobbyUser"/> s.</returns>
		public async Task<IEnumerable<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>>> GetAllAsync()
		{
			return await databaseContext.LobbyUsers.ToAsyncEnumerable().ToList();
		}

		/// <summary>
		/// Async queries for the model instance by the id.
		/// </summary>
		/// <param name="id">Model id.</param>
		/// <returns>A future model instance or null if not found.</returns>
		public async Task<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>> GetAsync(int id)
		{
			return await databaseContext.LobbyUsers.ToAsyncEnumerable()
				.FirstOrDefault();
		}

		/// <summary>
		/// Queries for the account by the <see cref="string"/>
		/// name of the account.
		/// </summary>
		/// <param name="userName">LobbyUser name of the account.</param>
		/// <returns>The account with the matching <paramref name="userName"/> or null.</returns>
		public LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType> GetByLobbyUserName(string userName)
		{
			return databaseContext.LobbyUsers
				.Where(a => a.UserName == userName)
				.FirstOrDefault();
		}

		/// <summary>
		/// Asyncronously queries for the account by the <see cref="string"/>
		/// name of the account.
		/// </summary>
		/// <param name="userName">LobbyUser name of the account.</param>
		/// <returns>A future of the account with the matching <paramref name="userName"/> or null.</returns>
		public async Task<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>> GetByLobbyUserNameAsync(string userName)
		{
			return await databaseContext.LobbyUsers
				.ToAsyncEnumerable()
				.Where(a => a.UserName == userName)
				.FirstOrDefault();
		}

		/// <summary>
		/// Asyncronously queries for the profiles by the <see cref="string"/>
		/// name of the profile.
		/// </summary>
		/// <param name="userNames">User names of the profiles.</param>
		/// <returns>A future of the profiles with the matching <paramref name="userNames"/> or null.</returns>
		public async Task<IEnumerable<LobbyUserModel<TLobbyConnectionDetailsType, TLobbyDetailsType>>> GetByLobbyUsersNameAsync(IEnumerable<string> userNames)
		{
			return await databaseContext.LobbyUsers.ToAsyncEnumerable()
				.Where(p => userNames.Contains(p.UserName))
				.ToList();
		}
	}
}
