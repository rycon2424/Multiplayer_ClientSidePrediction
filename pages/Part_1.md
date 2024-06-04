## *Client-prediction and Server reconciliation*

# Intro to Client-prediction and Server reconciliation tutorial

**What is this tutorial about?** <br>
This tutorial will teach you what Client-prediction and Server reconciliation is in a multiplayer game enviroment and how you can apply it to your own project.

**For who is it useful?** <br>
For anyone making developing a multiplayer game were precision of (for example) the players position needs to be consistend. This is architecture is mostly used in fast-paced multiplayer games. (First person shooters, online parkour games, etc)

*No this is not the gif lagging, it's the gameplay* <br>
![IntroGif](images/lag_intro.gif?raw=true)

**Knowledge expected from you**
- Knowledge of the Unity Engine and C# <br>
  ***(note: To keep this tutorial relevant for a long time, im using Unity's new input system in this tutorial. Although you can follow it with the default/old one too)***
- Knowing the basics of networking (Rpcs, packages, multiplayer)
- Being able to write code in a code editor (IDE) <br>
- Using networking solutions or similar to "Netcode for Gameobjects", "Mirror" <br>
  ***(note: I am going to use Netcode for Gameobjects throughout this tutorial)***
- This tutorial includes an **example build** of the final product + **a build** so you can test it locally.

**Small example that will be used and referenced to when talking about prediction and reconciliation**
- https://boskodeveloper.github.io <br>
***(note: this link will be shown everytime I use it for reference)***
<br>

**Contact**  <br>
For any questions feel free to mail at: boskoivkovic.developer@gmail.com

## Introduction
Welcome to my tutorial on client-side prediction and server reconciliation, key techniques that make online multiplayer games smooth and responsive.

### What You'll Learn
- Client-Side Prediction: Learn how your game instantly reflects your actions, like moving a character or firing a weapon, without waiting for server confirmation. This keeps gameplay fluid and responsive.
 - Server Reconciliation: Understand how the game server ensures fairness and consistency by validating and correcting the actions predicted by the client, maintaining a synchronized experience for all players.

### Why These Concepts Matter
Client-side prediction and server reconciliation are crucial for responsive and fair online gaming. Without them, games would feel laggy and inconsistent.

By the end of this tutorial, you'll understand how these systems work together to create seamless gameplay. 

## Who am I?
I am a game developer who is very interested in multiplayer/netcode functionality. I have dedicated myself the last 6 years working with different multiplayer solutions (Photon Pun, MLAPI, Netcode for Gameobjects, Mirror, Facepunch). Whenever I made a fast paced multiplayer game I always noticed how half a second delay could impact the whole balancing and fairness of the game. I also noticed that all these Networking solutions never have implemented a thing such as Client-side prediction. Probably because they are expecting different kinds of games to be made with them and thus do not have it high in their priority list.
<br> <br>
Currently, I am working on a game where the problem has risen again. I have stuff like opening chests, talking to npc's and triggering the game start, all based on when a player is at X location and pressing a button. Now imagine if a player presses a button as soon as he enters the trigger. Locally nothing would be wrong since he is inside the trigger. But for the other players where he is standing were he was half a second ago, this causes the other players to not receive the input of the player at the right location.
<br> <br>
I am definitely not the only game developer with this problem. That is why I have decided to make this tutorial.


## What is Client-prediction and server reconciliation?
Client Prediction is like guessing what will happen next in a game based on what you're doing. <br>
Server Reconciliation is like double-checking those guesses to make sure everyone is seeing the same thing in the game. <br>
*In part 2 we will dive deeper in those 2 topics.*

# Why They Are Important
- **Smooth Gameplay:** <br>
Client prediction makes sure you see your actions happen right away, making the game feel responsive and enjoyable. <br> <br>
- **Consistency and Fairness:** <br>
Server reconciliation ensures that everyone in the game world sees the same thing and plays by the same rules, making it fair and consistent.

![IntroGif](images/lag_input.gif?raw=true)

## How it looks like without any Client-prediction and Server reconciliation
Here is an example of how it looks like in my own project. As you can see the player moves on (25-50ms ping) **a whole second** later for the other player. This means the whole player positioning is a second off. <br>
![MyProblem](images/my_problem.gif?raw=true)
<br> <br>
*Using my tool (https://boskodeveloper.github.io) we can demonstrate the same problem like this.* <br>
*As you can see the "player 2" moves the blue circle which is "player 1" a bit delayed* <br>
![MyProblem](images/my_problem_toolV2.gif?raw=true)

# Next Part: Understanding the problem
[Part 2: Understanding the problem](Part_2.md)  <br>

<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
