using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rycon.Online.Examples
{
    public class Player : NetworkBehaviour // Using networkbehaviour or else the rpc calls and synced variables do NOT work
    {
        [Header("Client Specific")]
        [SerializeField] MovementData[] clientMovementDatas = new MovementData[BUFFERSIZE];

        [Header("Client and Server Specific")]
        [SerializeField] float playerSpeed = 2;
        [SerializeField] int tickRate = 60;

        // Client and Server Specific
        private int currentTick;
        private float time;
        private float tickTime;

        // Client Specific
        private const int BUFFERSIZE = 1024;
        [SerializeField] private Vector2 movement;
        private NetworkObject netObject;
        private CharacterInput input;

        // Server Specific (When the movementspeed is higher than this value needs to be higher too)
        private float maxPositionError = 0.5f;

        private void Awake()
        {
            tickTime = 1f / tickRate;
        }

        private void Start()
        {
            netObject = GetComponent<NetworkObject>();

            input = new CharacterInput();

            if (netObject.IsOwner)
            {
                input.PlayerExample.Movement.performed += OnMovement;
                input.PlayerExample.Movement.canceled += OnMovement;

                input.Enable();
            }

            Material mat = new Material(GetComponent<MeshRenderer>().materials[0]); 

            mat.color = netObject.OwnerClientId == 0 ? Color.red : Color.blue;

            GetComponent<MeshRenderer>().materials = new Material[1] { mat };
        }

        private void OnDisable()
        {
            input.PlayerExample.Movement.performed -= OnMovement;
            input.PlayerExample.Movement.canceled -= OnMovement;
        }

        private void Update()
        {
            time += Time.deltaTime;
        }

        private void FixedUpdate()
        {
            if (!IsClient || !IsOwner) // we want only the local client to perform all code here
                return;

            while (time > tickTime)
            {
                currentTick++;
                time -= tickTime;

                Move(); // moving on each of the ticks
            }
        }

        private void Move()
        {
            if (input.PlayerExample.Movement.IsPressed())
            {
                Vector3 calculatedMovement = new Vector3(movement.x, 0, movement.y) * playerSpeed * Time.deltaTime;
                transform.position += calculatedMovement;
            }

            // Store the tick movement
            clientMovementDatas[currentTick % BUFFERSIZE] = new MovementData
            {
                tick = currentTick,
                movementInput = movement,
                position = transform.position
            };

            if ((currentTick % BUFFERSIZE) < 2) // It needs to have atleast 2 ticks already counted before reconciliation
                return;

            Debug.Log("First: " + (currentTick % BUFFERSIZE) + " Before: " + ((currentTick - 1) % BUFFERSIZE));
            MoveServerRpc(clientMovementDatas[currentTick % BUFFERSIZE], clientMovementDatas[(currentTick - 1) % BUFFERSIZE],
                new ServerRpcParams { Receive = new ServerRpcReceiveParams { SenderClientId = OwnerClientId} });
        }

        // Input
        private void OnMovement(InputAction.CallbackContext context)
        {
            Vector2 inputReceived = Vector2.zero;
            if (context.performed)
            {
                inputReceived = context.ReadValue<Vector2>();
            }

            movement = inputReceived;
        }

        /// <param name="currentMovementData"> Current movement data </param>
        /// <param name="lastMovementData"> One tick before the current movement data </param>
        [ServerRpc]
        private void MoveServerRpc(MovementData currentMovementData, MovementData lastMovementData, ServerRpcParams parameters)
        {
            Vector3 startPos = transform.position;

            Vector3 calculatedMovement = new Vector3(lastMovementData.movementInput.x, 0, lastMovementData.movementInput.y) * playerSpeed * Time.deltaTime;

            transform.position = lastMovementData.position;
            transform.position += calculatedMovement;

            Vector3 correctPosition = transform.position;

            // if position is off indeed
            if (Vector3.Distance(correctPosition, currentMovementData.position) > maxPositionError)
            {
                Debug.Log("position is off");
                ReconciliateClientRpc(currentMovementData.tick, new ClientRpcParams
                {
                    Send = new ClientRpcSendParams
                    {
                        TargetClientIds = new List<ulong>() { parameters.Receive.SenderClientId }
                    }
                });
            }
        }

        [ClientRpc]
        private void ReconciliateClientRpc(int activationTick, ClientRpcParams parameters)
        {
            Vector3 correctPosition = clientMovementDatas[(activationTick - 1) % BUFFERSIZE].position;

            // Reconcile until the activation tick also known as the tick were there was something off
            while (activationTick <= currentTick)
            {
                Vector3 activationTickMovement = clientMovementDatas[(activationTick - 1) % BUFFERSIZE].movementInput;

                transform.position = correctPosition;

                Vector3 calculatedMovement = new Vector3(activationTickMovement.x, 0, activationTickMovement.y) * playerSpeed * Time.deltaTime;
                transform.position += calculatedMovement;

                clientMovementDatas[activationTick % BUFFERSIZE].position = correctPosition;
                activationTick++;
            }

            transform.position = correctPosition;
        }
    }

    [System.Serializable]
    public class MovementData : INetworkSerializable
    {
        public int tick;
        public Vector3 movementInput;
        public Vector3 position;

        // Serialized so it can be send through an RPC
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref tick);
            serializer.SerializeValue(ref movementInput);
            serializer.SerializeValue(ref position);
        }
    }
}