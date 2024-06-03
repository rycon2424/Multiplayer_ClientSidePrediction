using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Steamworks;
using Rycon.Online;

namespace Rycon.Online
{
    public class PlayerLobby : NetworkBehaviour
    {
        void Start()
        {
            NetworkManager.Singleton.OnClientConnectedCallback += AddPlayerListNetcode;
            NetworkManager.Singleton.OnClientDisconnectCallback += RemovePlayerFromList;
            if (GetComponent<NetworkObject>().IsOwner)
            {
                AddPlayerListNetcode(NetworkManager.Singleton.LocalClientId);
            }
        }

        private void OnDisable()
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= AddPlayerListNetcode;
            NetworkManager.Singleton.OnClientDisconnectCallback -= RemovePlayerFromList;
        }

        void AddPlayerListNetcode(ulong id)
        {
            if (NetworkManager.Singleton.LocalClientId == id)
            {
                if (GameNetworkManager.Singleton.transport)
                    AddPlayerInfoServerRpc(id, SteamClient.SteamId.Value, SteamClient.Name);
                else
                    AddPlayerInfoServerRpc(id, id, $"Player {id.ToString()}");
            }
        }

        void RemovePlayerFromList(ulong id)
        {
            if (IsServer)
            {
                RemovePlayerServerRpc(id);
            }
        }

        [ServerRpc(RequireOwnership = false)]
        void RemovePlayerServerRpc(ulong leavingPlayerID)
        {
            GameNetworkManager.Singleton.StoredLobbyInformation.playerInformation.Remove(leavingPlayerID);
            UpdatePlayerList();
        }

        [ServerRpc(RequireOwnership = false)]
        void AddPlayerInfoServerRpc(ulong id, ulong steamID, string playerName)
        {
            PlayerInfo playerInfo = new PlayerInfo(id, steamID, playerName);
            playerInfo.steamID = steamID;
            playerInfo.playerName = playerName;
            GameNetworkManager.Singleton.StoredLobbyInformation.playerInformation.Add(id, playerInfo);

            UpdatePlayerList();
        }

        void UpdatePlayerList()
        {
            List<string> playerinfoJson = new List<string>();

            foreach (var pInfo in GameNetworkManager.Singleton.StoredLobbyInformation.playerInformation)
            {
                SyncedPlayerInfo playerInfoStruct = new SyncedPlayerInfo
                { playerID = pInfo.Value.playerID, steamID = pInfo.Value.steamID, playerName = pInfo.Value.playerName };

                string playerInfo = JsonUtility.ToJson(playerInfoStruct);

                playerinfoJson.Add(playerInfo);
            }

            PlayerList playerList = new PlayerList(playerinfoJson.ToArray());

            ReceivePlayerInfoClientRpc(JsonUtility.ToJson(playerList), GameNetworkManager.Singleton.lobbySeed);
        }

        [ClientRpc]
        void ReceivePlayerInfoClientRpc(string players, int lobbyseed)
        {
            GameNetworkManager.Singleton.lobbySeed = lobbyseed;

            GameNetworkManager.Singleton.StoredLobbyInformation.playerInformation.Clear();
            PlayerList playerList = JsonUtility.FromJson<PlayerList>(players);
            string debugText = "////////\n";
            debugText += "View Playerlist here!\n";
            foreach (var player in playerList.players)
            {
                SyncedPlayerInfo receivedInfo = JsonUtility.FromJson<SyncedPlayerInfo>(player);
                PlayerInfo temp = new PlayerInfo(receivedInfo.playerID, receivedInfo.steamID, receivedInfo.playerName);

                GameNetworkManager.Singleton.StoredLobbyInformation.playerInformation.Add(temp.playerID, temp);

                debugText += ($"ID = '{temp.playerID}' Player: '{temp.playerName}' \n");
            }
            debugText += "////////\n" + "Lobby seed: " + GameNetworkManager.Singleton.lobbySeed;
            Debug.Log(debugText);
            GameNetworkManager.Singleton.StoredLobbyInformation.InvokeEvent();
        }
    }
}