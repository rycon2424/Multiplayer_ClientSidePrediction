using Netcode.Transports.Facepunch;
using Steamworks;
using Steamworks.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace Rycon.Online
{
	public class GameNetworkManager : MonoBehaviour
	{
		public string steamName;
		public int lobbySeed;
		public bool gameStarted;

		public delegate void HostDisconnected();
		public event HostDisconnected OnHostDisconnected;

		public static GameNetworkManager Singleton { get; private set; } = null;

		[HideInInspector] public FacepunchTransport transport;
		public Lobby? CurrentLobby { get; set; } = null;

		public List<Lobby> Lobbies { get; private set; } = new List<Lobby>(capacity: 100);

		public StoredLobbyInformation StoredLobbyInformation { get; set; }

		[Header("Temporary")]
		public UnityEngine.UI.Button serverButton;
		public UnityEngine.UI.Button localButton;
		public UnityEngine.UI.Button localJoinButton;

		private void Awake()
		{
			if (Singleton == null)
				Singleton = this;
			else
			{
				Destroy(gameObject);
				return;
			}

			SetupGameManager();
			DontDestroyOnLoad(gameObject);
		}

		private void SetupGameManager()
		{
			StoredLobbyInformation = GetComponent<StoredLobbyInformation>();

			transport = NetworkManager.Singleton.GetComponent<FacepunchTransport>();

			if (transport)
			{
				serverButton.interactable = true;
				steamName = Steamworks.SteamClient.Name;

				SteamMatchmaking.OnLobbyCreated += OnLobbyCreated;
				SteamMatchmaking.OnLobbyEntered += OnLobbyEntered;
				SteamMatchmaking.OnLobbyMemberJoined += OnLobbyMemberJoined;
				SteamMatchmaking.OnLobbyMemberLeave += OnLobbyMemberLeave;
				SteamMatchmaking.OnLobbyInvite += OnLobbyInvite;
				SteamFriends.OnGameLobbyJoinRequested += OnGameLobbyJoinRequested;
			}
			else
			{
				localJoinButton.interactable = true;
				localButton.interactable = true;
				steamName = "LocalTesting";
			}
		}

		private void OnDestroy()
		{
			SteamMatchmaking.OnLobbyCreated -= OnLobbyCreated;
			SteamMatchmaking.OnLobbyEntered -= OnLobbyEntered;
			SteamMatchmaking.OnLobbyMemberJoined -= OnLobbyMemberJoined;
			SteamMatchmaking.OnLobbyMemberLeave -= OnLobbyMemberLeave;
			SteamMatchmaking.OnLobbyInvite -= OnLobbyInvite;
			SteamFriends.OnGameLobbyJoinRequested -= OnGameLobbyJoinRequested;

			if (NetworkManager.Singleton == null)
				return;

			NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnectedCallback;
			NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnectCallback;
			NetworkManager.Singleton.OnServerStarted -= OnServerStarted;
		}

		private void OnApplicationQuit() => Disconnect();

		public async void StartHost(uint maxMembers)
		{
			NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
			NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectCallback;
			NetworkManager.Singleton.OnServerStarted += OnServerStarted;

			NetworkManager.Singleton.StartHost();

			if (transport)
			{
				CurrentLobby = await SteamMatchmaking.CreateLobbyAsync((int)maxMembers);
			}
		}

		public bool StartClient(SteamId id)
		{
			NetworkManager.Singleton.OnClientConnectedCallback += ClientConnected;
			NetworkManager.Singleton.OnClientDisconnectCallback += ClientDisconnected;
			NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectCallback;

			if (transport)
			{
				transport.targetSteamId = id;

				Debug.Log($"Joining room hosted by {transport.targetSteamId}", this);
			}

			if (NetworkManager.Singleton.StartClient())
			{
				Debug.Log("Client has joined!", this);
				return true;
			}
			return false;
		}

		public void Disconnect()
		{
			CurrentLobby?.Leave();

			if (NetworkManager.Singleton == null)
				return;

			NetworkManager.Singleton.Shutdown();
		}

		public async Task<bool> RefreshLobbies(int maxResults = 20)
		{
			try
			{
				Lobbies.Clear();

				var lobbies = await SteamMatchmaking.LobbyList
						.FilterDistanceClose()
				.WithMaxResults(maxResults)
				.RequestAsync();

				if (lobbies != null)
				{
					for (int i = 0; i < lobbies.Length; i++)
						Lobbies.Add(lobbies[i]);
				}

				return true;
			}
			catch (System.Exception ex)
			{
				Debug.Log("Error fetching lobbies", this);
				Debug.LogException(ex, this);
				return false;
			}
		}

		private Steamworks.ServerList.Internet GetInternetRequest()
		{
			var request = new Steamworks.ServerList.Internet();
			//request.AddFilter("secure", "1");
			//request.AddFilter("and", "1");
			//request.AddFilter("gametype", "1");
			return request;
		}

		#region Steam Callbacks

		private void OnGameLobbyJoinRequested(Lobby lobby, SteamId id)
		{
			if (CurrentLobby.HasValue)
			{
				Debug.Log("cant join while already in a lobby");
				return;
			}
			CurrentLobby = lobby;

			bool isSame = lobby.Owner.Id.Equals(id);

			Debug.Log($"Owner: {lobby.Owner}");
			Debug.Log($"Id: {id}");
			Debug.Log($"IsSame: {isSame}", this);

			StartClient(id);
		}

		private void OnLobbyInvite(Friend friend, Lobby lobby) => Debug.Log($"You got a invite from {friend.Name}", this);

		private void OnLobbyMemberLeave(Lobby lobby, Friend friend) { Debug.Log($" {friend.Name} / {friend.Id} left"); }

		private void OnLobbyMemberJoined(Lobby lobby, Friend friend) { Debug.Log($" {friend.Name} / {friend.Id} joined"); }

		private void OnLobbyEntered(Lobby lobby)
		{
			//Debug.Log($"You have entered in lobby, clientId={NetworkManager.Singleton.LocalClientId}", this);

			if (NetworkManager.Singleton.IsHost)
				return;

			StartClient(lobby.Owner.Id);
		}

		private void OnLobbyCreated(Result result, Lobby lobby)
		{
			if (result != Result.OK)
			{
				Debug.LogError($"Lobby couldn't be created!, {result}", this);
				return;
			}

			lobby.SetFriendsOnly(); // Set to friends only!
			lobby.SetData("name", "Random Cool Lobby");
			lobby.SetJoinable(true);

			//Debug.Log("Steam Lobby has been created!");
		}

		#endregion

		#region Network Callbacks

		private void ClientConnected(ulong clientId)
		{
			Debug.Log($"I'm connected, clientId = {clientId}");
		}

		private void ClientDisconnected(ulong clientId)
		{
			NetworkManager.Singleton.OnClientDisconnectCallback -= ClientDisconnected;
			NetworkManager.Singleton.OnClientConnectedCallback -= ClientConnected;
		}

		private void OnServerStarted()
		{

        }

		private void OnClientConnectedCallback(ulong clientId)
		{
			//Debug.Log($"Client connected, clientId = {clientId}", this);
		}

		private void OnClientDisconnectCallback(ulong clientId)
		{
			Debug.Log($"Client disconnected, clientId = {clientId}", this);
			if (clientId == 0)
			{
				Debug.Log("## HOST LEFT SERVER DISCONNECTED ##");
				OnHostDisconnected.Invoke();
			}
		}

		#endregion
	}
}