using Netcode.Transports.Facepunch;
using Steamworks;
using Steamworks.Data;
using Unity.Netcode;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Threading.Tasks;
using Rycon.Online.SteamTools;

namespace Rycon.Online.Matchmaking
{
    public class Matchmaking : MonoBehaviour
    {
        [Tooltip("Max amount of players in a server")]
        public int serverMaxPlayers = 5;
        [Tooltip("The multiplayer scene the players will go after the host starts the game")]
        public string mpScene;

        [Header("Menus")]
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject lobbyMenu;

        [Header("Main Menu")]
        [SerializeField] TMP_Text welcomeText;

        [Header("Lobby Menu")]
        [SerializeField] TMP_Text[] playerNames;
        [SerializeField] UnityEngine.UI.RawImage[] playerImages;
        [SerializeField] GameObject startGameButton;

        [Header("Invite Menu")]
        [SerializeField] GameObject invitePopup;
        [SerializeField] TMP_Text inviteText;
        [SerializeField] UnityEngine.UI.Image inviteTimerSlider;

        private void OnEnable()
        {
            SteamMatchmaking.OnLobbyInvite += GotInvited;
            SteamMatchmaking.OnLobbyEntered += JoinedLobby;
            NetworkManager.Singleton.OnServerStarted += OnServerStarted;
        }

        private void OnDisable()
        {
            SteamMatchmaking.OnLobbyInvite -= GotInvited;
            SteamMatchmaking.OnLobbyEntered -= JoinedLobby;
            NetworkManager.Singleton.OnServerStarted -= OnServerStarted;
            GameNetworkManager.Singleton.StoredLobbyInformation.PlayerInfoUpdated -= UpdatePlayerList;
            GameNetworkManager.Singleton.OnHostDisconnected -= DisconnectedFromServer;
        }

        private void Start()
        {
            GameNetworkManager.Singleton.StoredLobbyInformation.PlayerInfoUpdated += UpdatePlayerList;
            GameNetworkManager.Singleton.OnHostDisconnected += DisconnectedFromServer;

            welcomeText.text = $"Welcome {GameNetworkManager.Singleton.steamName}!";
        }

        Lobby recentLobbyInvite;
        public void GotInvited(Friend friend, Lobby lobby)
        {
            if (GameNetworkManager.Singleton.CurrentLobby.HasValue)
            {
                Debug.Log("cant receive invite while already in a lobby");
                return;
            }
            recentLobbyInvite = lobby;
            inviteText.text = "You received an invite from " + friend.Name + "!";
            StopCoroutine("InviteTimer");
            StartCoroutine("InviteTimer");
        }

        IEnumerator InviteTimer()
        {
            invitePopup.SetActive(true);

            float ElapsedTime = 0.0f;
            float TotalTime = 10.0f;
            while (ElapsedTime < TotalTime)
            {
                ElapsedTime += Time.deltaTime;
                inviteTimerSlider.fillAmount = Mathf.Lerp(1, 0, (ElapsedTime / TotalTime));
                yield return null;
            }

            invitePopup.SetActive(false);
        }

        private void OnServerStarted()
        {
            Debug.Log($"Created Server! I'm connected, clientId = {NetworkManager.Singleton.LocalClientId}");

            mainMenu.SetActive(false);
            lobbyMenu.SetActive(true);
        }

        public void JoinedLobby(Lobby lobby)
        {
            mainMenu.SetActive(false);
            lobbyMenu.SetActive(true);
        }

        async void UpdatePlayerList()
        {
            ResetPlayerLobbyVisuals();

            int i = 0;
            foreach (var player in GameNetworkManager.Singleton.StoredLobbyInformation.playerInformation)
            {
                if (GameNetworkManager.Singleton.transport)
                {
                    if (player.Value.playerPicture == null)
                    {
                        var avatar = SteamAvatarHelper.GetAvatar(player.Value.steamID);

                        await Task.WhenAll(avatar);

                        Texture2D texture = avatar.Result?.Covert();

                        playerImages[i].texture = texture;
                    }
                    else
                    {
                        playerImages[i].texture = player.Value.playerPicture;
                    }
                }
                playerNames[i].text = player.Value.playerName;
                i++;
            }
        }

        // Start Game
        public void LoadSceneForAllClients()
        {
            if (GameNetworkManager.Singleton.CurrentLobby != null)
            {
                GameNetworkManager.Singleton.CurrentLobby.Value.SetJoinable(false);
            }
            GameNetworkManager.Singleton.gameStarted = true;
            LoadSceneClientRpc(mpScene);
        }

        [ClientRpc]
        private void LoadSceneClientRpc(string sceneName)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
        }

        void ResetPlayerLobbyVisuals()
        {
            for (int j = 0; j < playerNames.Length; j++)
            {
                playerNames[j].text = "";
                playerImages[j].texture = null;
            }
        }

        void DisconnectedFromServer()
        {
            ResetPlayerLobbyVisuals();

            startGameButton.SetActive(false);

            GameNetworkManager.Singleton.StoredLobbyInformation.OnDisconnect();

            NetworkManager.Singleton.Shutdown();

            GameNetworkManager.Singleton.CurrentLobby?.Leave();
            GameNetworkManager.Singleton.CurrentLobby = null;

            mainMenu.SetActive(true);
            lobbyMenu.SetActive(false);
        }

        #region UI Buttons

        public async void B_AcceptInvite()
        {
            invitePopup.SetActive(false);

            SteamId steamid = new SteamId();
            steamid.Value = recentLobbyInvite.Id;
            GameNetworkManager.Singleton.CurrentLobby = await SteamMatchmaking.JoinLobbyAsync(steamid);
        }

        public void B_Disconnect()
        {
            DisconnectedFromServer();
        }

        public void B_InviteFriendsLayout()
        {
            Debug.Log("Invite Layout only works if the game is added as non steam game on steam and LAUNCHED on steam");
            Steamworks.SteamFriends.OpenGameInviteOverlay(GameNetworkManager.Singleton.CurrentLobby.Value.Id);
        }

        public void B_CreateServer()
        {
            startGameButton.SetActive(true);
            GameNetworkManager.Singleton.StartHost((uint)serverMaxPlayers);
        }

        public void B_StartLocalClient()
        {
            Steamworks.SteamId zero = new Steamworks.SteamId();
            GameNetworkManager.Singleton.StartClient(zero);
        }

        #endregion
    }
}