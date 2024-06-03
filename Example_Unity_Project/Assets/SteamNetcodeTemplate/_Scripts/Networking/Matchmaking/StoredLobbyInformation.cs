using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Steamworks;
using Steamworks.Data;
using Netcode.Transports.Facepunch;

namespace Rycon.Online
{
    public class StoredLobbyInformation : NetworkBehaviour
    {
        public Dictionary<ulong, PlayerInfo> playerInformation = new Dictionary<ulong, PlayerInfo>();

        public delegate void UpdatedPlayerInfo();
        public event UpdatedPlayerInfo PlayerInfoUpdated;

        void Start()
        {
            playerInformation.Clear();

            if (NetworkManager.Singleton.GetComponent<FacepunchTransport>())
            {
                SteamMatchmaking.OnLobbyCreated += OnLobbyCreated;
            }
        }

        public void OnDisconnect()
        {
            GameNetworkManager.Singleton.lobbySeed = 0;
            GameNetworkManager.Singleton.CurrentLobby?.Leave();

            playerInformation.Clear();

            if (NetworkManager.Singleton == null)
                return;

            playerInformation.Clear();
            NetworkManager.Singleton.Shutdown();
        }

        public void InvokeEvent()
        {
            PlayerInfoUpdated?.Invoke();
        }

        void LeaveServer() // Called by the client
        {
            playerInformation.Clear();
        }

        void OnLobbyCreated(Result result, Lobby lobby)
        {
            Debug.Log("Created lobby");
        }

        private void OnDisable()
        {
            try
            {
                OnDisconnect();
            }
            catch (System.Exception e)
            {
                //Debug.Log(e.Message);
            }
        }

    }

    [System.Serializable]
    public class PlayerList
    {
        public string[] players;

        public PlayerList(string[] _players)
        {
            players = _players;
        }
    }

    [System.Serializable]
    public class PlayerInfo
    {
        public ulong playerID = 999;
        public ulong steamID = 999;
        public string playerName;
        public Texture2D playerPicture;

        public PlayerInfo(ulong _playerID, ulong _steamID, string _playerName)
        {
            playerID = _playerID;
            steamID = _steamID;
            playerName = _playerName;
        }
    }

    public struct SyncedPlayerInfo : INetworkSerializable
    {
        public ulong playerID;
        public ulong steamID;
        public string playerName;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref playerID);
            serializer.SerializeValue(ref steamID);
            serializer.SerializeValue(ref playerName);
        }
    }
}