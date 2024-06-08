## *Client-prediction and Server reconciliation*

# Understanding the problem.

## Why is understanding the problem important?
Understanding client-prediction and server reconciliation is crucial in multiplayer game development for several reasons:

### Improved Player Experience
- **Reduced Latency:** Client-prediction provides immediate responses to inputs, reducing perceived lag and making the game feel more responsive.
- **Smooth Gameplay:** Server reconciliation corrects inconsistencies between client predictions and server-confirmed states, ensuring consistent gameplay.

### Consistency and Fairness
- **Accurate State Synchronization:** Ensures all players have a consistent view of the game world, maintaining fair gameplay.
- **Error Correction:** Addresses network issues by making the server the authoritative source, correcting client prediction errors smoothly.

### Cheat Prevention
- **Server Authority:** Keeps the server as the authoritative entity, preventing client-side manipulation and cheating.
<br>
I am going to explain in depth how latency works and what Client-Side prediction and server reconciliation means.
I collected most of these explanations from this web blog about client-side prediction with physics and Unity it's explanation in these following links: <br>
- https://codersblock.org/posts/unity-client-side-prediction/ <br>
- https://docs-multiplayer.unity3d.com/netcode/current/learn/lagandpacketloss/ <br>

## Understanding latency
Multiplayer games operating over the internet have to manage adverse network factors that don't affect single-player or LAN-only multiplayer games, most notably network latency. Latency (also known as lag) is the delay between a user taking an action and seeing the expected result. When latency is too high, a game feels unresponsive and slow.

*Here you can see how your ping (delay in ms) is measured.* <br>
![testimage](images/ping-animation-dark.gif?raw=true)

Generally, 200ms of latency is the point at which users notice gameplay degradation, although different types of games can tolerate more or less latency. For example, first-person shooter games perform best with less than 100ms of latency, whereas real-time strategy games can tolerate higher latency values of up to 500ms before gameplay is meaningfully impacted.

High ping (ms) can cause actions/events and even movement to be processed way later, causing a big desync and making some games unplayable. <br> <br>
Using my tool (https://boskodeveloper.github.io) we can simulate lag by setting the player 1 lag to 100+ ms. 
When you move with the arrow keys you will notice that it takes a second before the player actually moves after the input.

![testimage](images/lag_meme.gif?raw=true)

## Tick and update rates
In addition to the effects of latency, gameplay experience in a multiplayer game is also affected by the server's tick rate and the client's update rate. Low tick and update rates reduce game responsiveness and add to perceived latency for users.

For example on the default settings using my tool: https://boskodeveloper.github.io/
You can see that changing the server's "Updates per second" increases the smoothness significantly.
![testimage](images/tick_update_rate.gif?raw=true)


### Tick rate
Tick rate, also known as the simulation rate, is a measure of how frequently the server updates the game state. At the beginning of a tick, the server starts to process the data it's received from clients since the last tick and runs the necessary simulations to update the game state. The updated game state is then sent back to the clients. The faster the server finishes a tick, the earlier clients can receive the updated game state (subject to the client's update rate).

### Update rate
Update rate is a measure of how frequently the client sends and receives data to and from the server. It's also measured in hertz and, like tick rate, a higher update rate results in a more responsive game at the cost of increased processing and network demands on the client and server.
<br> <br>
*If the update rate of a client is lower than the tick rate of the server, then the client won't see the benefit of the high tick rate, because it will only receive updates at the client update rate, even if multiple ticks have been processed in the meantime.*

## Server authoritive vs Client authoritive

### Server authoritive 
When handling an online action for example shooting a bullet, the safest and most anti cheat way of doing it would look like this:
- 1 Client asks the server if he can shoot a bullet
- 2 Server checks if the client has a bullet in his magazine, if so. Tell the client he may shoot.
- 3 The client shoots and all other clients see him shooting a bullet. 
<br> <br>
*Visual example of a **Server Authorative** messaging system.* <br> <br>
![ServerAuthorative](images/server_authorative.png?raw=true)
<br>
However, the problem here is that the delay between when the client presses shoot and the actual shot is dependent on the network latency (ping in ms) of the client. When it is 25ms it's unnoticeable, but when you have 100ms or higher, the game will perform all your actions delayed causing the feedback from all actions to feel weird and not satisfying.

### Client authoritive
This version of messaging is never used since it can cause the client to send whatever he wants to other clients without there being someone to overlook if the client is allowed to do that action.
This makes cheating very easy. Imagine if you could just send "I’m shooting" to everyone and no one checking if it was actually possible. That is very exploitative.

*Visual example of a **Client Authorative** messaging system.*
![ClientAuthorative](images/client_authorativeV2.png?raw=true)

## Client-side prediction and Server reconciliation explained
### Client-side prediction
When client-side prediction is implemented and a player performs an action (for example; moving their character or shooting a weapon), the input is immediately processed by the client. This means the client updates the game state locally based on the player's input without waiting for the server's response.

### Server reconciliation
Server reconciliation is on a very simple level checking if a client was allowed to ever perform an action. If yes then the server sends the client an approval check. But if the server got an action requested that was not possible for the client (for example; shooting a bullet while the magazine is empty, or moving while the clients character was blocked). Then the server will reconciliate that action, for the shooting example one way to reconciliate it is by making the bullet not do damage (since it was never supposed to spawn in the first place). For the movement the reconciliation would be to teleport the client back to his last position were he was allowed to be from the server.

*How the messaging looks like when there is Client-side prediction and server reconciliation implemented*
![ServerReconciliation](images/server_reconciliation.png?raw=true)

# Next Part: Resolving the problem
[Part 3: Resolving the problem](Part_3.md)  <br>

<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
