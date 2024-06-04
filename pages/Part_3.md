## *Client-prediction and Server reconciliation*

# Resolving the problem

## Before we start implementing it
Make sure you have a connection setup ready and a spawn manager so when the host and client connect they will both spawn in their own player and be visible for the other. <br>
***NOTE: the movement should not be synced yet***
<br> <br>
*How it looks like on my end, make sure you have something similar to it* <br>
![Spawning Players](images/tutorial_spawnV2.gif?raw=true) <br>
*To clarify, the red capsule functions as the host, while the blue one acts as the client.*

## Before we start
We will implement the Client-prediction and Server reconciliation as bare bone as possible. This can after this tutorial easily be optimized and expanded.

## Applying client-side prediction by moving locally and sending all data
The first thing we need is to store all movement each tick. We can do this by making a class to store a ticks information. <br>
We need to store 3 values.
- **tick** : The current tick of this data.
- **movementInput** : The current input where the player is headed.
- **position** : The position of the player. <br>
```c#
    using Unity.Netcode;

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
```
We need to implement the "INetworkSerializable" interface for this class to be able to get send through the network.

### NetworkBehaviour !!!
For Netcode for Gameobjects to be able to send Rpcs inside a class it needs to inherit from NetworkBehaviour.
```c#
public class Player : NetworkBehaviour
```

### All Variables
Now lets set up all the variables in the player movement script. <br> 
*(You can do this elsewhere but for simplicity reasons ill be doing all code in the player movement script)*
<br>
- **BUFFERSIZE** : Amount of ticks that will be recorded as history. (1024)
  <br> <br>
- **clientMovementDatas** : History of all MovementData's that have been send to the server. The furthest it can look back to is 1024 ticks ago based on the BUFFERSIZE.
  <br> <br>
- **playerSpeed** : The players movement speed.
  <br> <br>
- **currentTick** : The current tick the player is on.
- **time** : The time elapsed since start.
- **tickTime** : The time per tick we will calculate in Awake based on the tickrate
  <br> <br>
- **movement** : The current movement direction that will be a vector2 (Up/Down / Left/Right).
  <br> <br>
- **maxPositionError** : The maximum distance allowed that the player can travel between ticks.
- **tickRate** : The tickrate the server runs on (How many times per second the server communicates to the client and the other way around).

```c#
        private const int BUFFERSIZE = 1024;

        [Header("Client Specific")]
        [SerializeField] MovementData[] clientMovementDatas = new MovementData[BUFFERSIZE];

        [Header("Client and Server Specific")]
        [SerializeField] float playerSpeed = 2;

        // Client and Server Specific
        private int currentTick;
        private float time;
        private float tickTime;

        // Client Specific
        [SerializeField] Vector2 movement;

        // Server Specific (When the movementspeed is higher than this value needs to be higher too)
        [SerializeField] float maxPositionError = 0.5f;
        private int tickRate = 60;
```

### Set the ticktime in awake and count the time going up in the update loop
```c#
        private void Awake()
        {
            tickTime = 1f / tickRate;
        }

        private void Update()
        {
            time += Time.deltaTime;
        }
```

### Movement Handling
Make sure to make a function that calculated the movement since this needs to be the same on 3 occasions. We do this because there will be 3 places where it can possibly be called. <br>
1 - Local as soon as the player presses move <br>
2 - On the server so the server updates the position <br>
3 - On reconciliation if the player is cheating <br>
<br>
*Example of my way of getting and calculating the movement* 
```c#
        // Input system
        private void OnMovement(InputAction.CallbackContext context)
        {
            Vector2 inputReceived = Vector2.zero;
            if (context.performed)
            {
                inputReceived = context.ReadValue<Vector2>();
            }

            movement = inputReceived; // update the movement variable
        }

        private void Move()
        {
            transform.position += CalculateMovement(movement);
        }

        private Vector3 CalculateMovement(Vector3 inputMovement)
        {
            return new Vector3(inputMovement.x, 0, inputMovement.y) * playerSpeed * Time.deltaTime;
        }
```

### Performing the movement each tick and letting the server know
In the fixed update we will first check if this object is owned by the local client. If it is owned the local client, we will perform all movement logic each tick. <br>
Each tick we be doing 2 things:
- Move the client locally
- Send a new MovementData class **of this tick** with all current information to the server. (tick, movement direction and current position)

```c#
        private void FixedUpdate()
        {
            if (!IsClient || !IsOwner) // we want only the local client to perform all code here
                return;

            while (time > tickTime)
            {
                currentTick++;
                time -= tickTime;

                Move(); // moving on each of the ticks
                StoreAndSendTick(); // sending the tick data of last movement and position
            }
        }

        private void StoreAndSendTick()
        {
            // Store the tick movement
            clientMovementDatas[currentTick % BUFFERSIZE] = new MovementData
            {
                tick = currentTick,
                movementInput = movement,
                position = transform.position
            };

            if ((currentTick % BUFFERSIZE) < 2) // It needs to have atleast 2 ticks already counted before reconciliation
                return;

            MoveServerRpc(clientMovementDatas[currentTick % BUFFERSIZE], clientMovementDatas[(currentTick - 1) % BUFFERSIZE],
                new ServerRpcParams { Receive = new ServerRpcReceiveParams { SenderClientId = OwnerClientId } });
        }

        [ServerRpc]
        private void MoveServerRpc(MovementData currentMovementData, MovementData lastMovementData, ServerRpcParams parameters)
        {
            // Here we will implement the reconciliation later
        {
```
<br>
Now that we are done with the clients side of data. We now need to make the server actually do something with this info.

## Applying server side reconciliation using x

### Checking if the position gap is too high
tell us

### Returning the player to it's old position if there is weird behavior detected
tell us

# Next Part: Tips and Optimization
[Part 4: Tips and Optimization](Part_4.md)  <br>

<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
