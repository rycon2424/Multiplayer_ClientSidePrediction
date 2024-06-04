## *Client-prediction and Server reconciliation*

# Resolving the problem

## Before we start implementing it
Make sure you have a connection setup ready and a spawn manager so when the host and client connect they will both spawn in their own player and be visible for the other.

*How it looks like on my end, make sure you have something similar to it* <br>
![Spawning Players](images/tutorial_spawn.gif?raw=true) <br>
*To clarify, the red capsule functions as the host, while the blue one acts as the client.*

## Before we start
We will implement the Client-prediction and Server reconciliation as bare bone as possible. This can after this tutorial easily be optimized and expanded.

## Applying client-side prediction by storing all movement per tick
The first thing we need is to store all movement each tick. We can do this by making a class to store a ticks information. <br>
We need to store 3 values.
- tick: The current tick of this data.
- movementInput: The current input where the player is headed.
- position: The position of the player. <br>
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

### All Variables
Now lets set up all the variables in the player movement script. <br> 
*(You can do this elsewhere but for simplicity reasons ill be doing all code in the player movement script)*
<br> <br>
Explanation

```c#
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
        private const int BUFFERSIZE = 1024;
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
  
```c#
        private void Move()
        {
            if (input.PlayerExample.Movement.IsPressed())
            {
                transform.position += CalculateMovement(movement);
            }
        }

        private Vector3 CalculateMovement(Vector3 inputMovement)
        {
            return new Vector3(inputMovement.x, 0, inputMovement.y) * playerSpeed * Time.deltaTime;
        }
```

## Applying server side reconciliation using x
tell us

# Next Part: Tips and Optimization
[Part 4: Tips and Optimization](Part_4.md)  <br>

<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
