## *Client-prediction and Server reconciliation*

# Understanding the problem.

## Why is understanding the problem important?
tell us

## Understanding latency
tell us

## Tick and update rates
In addition to the effects of latency, gameplay experience in a multiplayer game is also affected by the server's tick rate and the client's update rate. Low tick and update rates reduce game responsiveness and add to perceived latency for users.

For example on the default settings using my tool: https://boskodeveloper.github.io/
You can see that changing the servers "Updates per second" increases the smoothness significantly.


### Tick rate
Tick rate, also known as the simulation rate, is a measure of how frequently the server updates the game state. At the beginning of a tick, the server starts to process the data it's received from clients since the last tick and runs the necessary simulations to update the game state. The updated game state is then sent back to the clients. The faster the server finishes a tick, the earlier clients can receive the updated game state (subject to the client's update rate).

### Update rate
Update rate is a measure of how frequently the client sends and receives data to and from the server. It's also measured in hertz and, like tick rate, a higher update rate results in a more responsive game at the cost of increased processing and network demands on the client and server.
<br> <br>
*If the update rate of a client is lower than the tick rate of the server, then the client won't see the benefit of the high tick rate, because it will only receive updates at the client update rate, even if multiple ticks have been processed in the interim.*

## Server authoritive vs Client authoritive
tell us
<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
