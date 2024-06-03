## *Client-prediction and Server reconciliation*

# Intro to Client-prediction and Server reconciliation tutorial

**What is this tutorial about?** <br>
This tutorial will teach you what Client-prediction and Server reconciliation is in a multiplayer game enviroment and how you can apply it to your own project.

**For who is it usefull?** <br>
For anyone making developing a multiplayer game were precision of (for example) the players position needs to be consistend. This is architecture is mostly used in fast-paced multiplayer games. (First person shooters, online parkour games, etc)

*No this is not the gif lagging, it's the gameplay* <br>
![IntroGif](images/lag_intro.gif?raw=true)

**Knowledge expected from you**
- Knowledge of the Unity Engine and C#
- Knowing the basics of networking (Rpcs, packages, multiplayer)
- Being able to write code in a code editor (IDE) <br>
- Using networking solutions or similar to "Netcode for Gameobjects", "Mirror" <br>
  ***(note: I am going to use Netcode for Gameobjects throughout this tutorial)***

**Small example that will be used and referenced to when talking about prediction and reconciliation**
- https://boskodeveloper.github.io <br>
***(note: this link will be shown everytime I use it for reference)***

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
tell us, what my problem is and why i chose this solution
// npc talking
// looting chests
// trigger of game start
// overal movement, most issues could be fixed by having the players locations correct most of the timers

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
<br>
*Using my tool we can demonstrate the same problem like this.*
*As you can see the "player 2" moves the blue circle which is "player 1" a bit delayed* <br>
![MyProblem](images/my_problem_tool.gif?raw=true)

# Next Part: Understanding the problem
[Part 2: Understanding the problem](Part_2.md)  <br>

<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
