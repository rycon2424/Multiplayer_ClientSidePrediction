using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Rycon.Online.Examples
{
    public class SpawnManager : NetworkBehaviour
    {
        public List<Vector3> spawnPositions = new List<Vector3>();
        [Space]
        public GameObject player;

        public void Start()
        {
            SpawnUnit();

            // cleaner way is sending a ready check to the host and if all players are connected then spawn them in
        }

        public void SpawnUnit()
        {
            RequestSpawnServerRpc(NetworkManager.Singleton.LocalClientId);
        }

        [ServerRpc(RequireOwnership = false)]
        void RequestSpawnServerRpc(ulong clientID)
        {
            if (IsHost)
            {
                Vector3 spawn = spawnPositions[Random.Range(0, spawnPositions.Count)];
                spawnPositions.Remove(spawn);
                NetworkObject spawnedPlayer = Instantiate(player, spawn, Quaternion.identity).GetComponent<NetworkObject>();
                spawnedPlayer.SpawnWithOwnership(clientID);
            }
        }

        private void OnDrawGizmos()
        {
            if (spawnPositions.Count > 0)
            {
                Gizmos.color = Color.yellow;
                foreach (var pos in spawnPositions)
                {
                    Gizmos.DrawSphere(pos, 1);
                }
            }
        }
    }
}
