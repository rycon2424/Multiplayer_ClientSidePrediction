## *Client-prediction and Server reconciliation*

# Intro to Client-prediction and Server reconciliation Tutorial

**What is this tutorial about?** <br>
tell us

**For who is it usefull?** <br>
tell us

**Knowledge expected from you**
- Knowledge of the Unity Engine and C#
- Knowing the basics of networking (Rpcs, packages, multiplayer)
- Using networking solutions or similar to "Netcode for Gameobjects", "Mirror"
- Being able to write code in a code editor (IDE)

**Small example that will be used and referenced to when talking about prediction and reconciliation**
- https://boskodeveloper.github.io <br>
(note: this link will be shown everytime I use it for reference)

**Contact**  <br>
For any questions feel free to mail at: boskoivkovic.developer@gmail.com

## Introduction
tell us

## Who am I?
tell us

## What is Client-prediction and server reconciliation?
When handling an online action for example shooting a bullet, the safest and most anti cheat way of doing it would look like this:
- 1 Client asks the server if he can shoot a bullet
- 2 Server checks if the client has a bullet in his magazine, if so. Tell the client he may shoot.
- 3 The client shoots and all others clients see him shooting a bullet. 
<br> <br>
This way of handling it is also known as **Server Authorative**

![ServerAuthorative](images/server_authorative.png?raw=true)

<br>
However the problem here is that the delay between when the client presses shoot and the actual shot is dependend on the network latency (ping in ms) of the client. When it's 25ms it's unnoticeable but as you have 100ms or higher, the game will perform all your actions delayed causing the feedback from all actions to feel weird and not satisfying.

### Client-side prediction
When client-side prediction is implemented and a player performs an action (for example; moving their character, shooting a weapon), the input is immediately processed by the client. This means the client updates the game state locally based on the player's input without waiting for the server's response.

### Server reconciliation
tell us

*How the messaging looks like when there is Client-side prediction and server reconciliation implemented*
![ServerReconciliation](images/server_reconciliation.png?raw=true)

## How it looks like without any Client-prediction and Server reconciliation
tell us - delayed
<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
