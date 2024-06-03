## *Client-prediction and Server reconciliation*

# Intro to Client-prediction and Server reconciliation tutorial

**What is this tutorial about?** <br>
tell us

**For who is it usefull?** <br>
For anyone making developing a multiplayer game were precision of (for example) the players position needs to be consistend. This is architecture is mostly used in fast-paced multiplayer games. (First person shooters, online parkour games, etc)

// insert lag gif

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

## How it looks like without any Client-prediction and Server reconciliation
tell us - delayed
// show the tools delay
// show my own project delay

# Next Part: Understanding the problem
[Part 2: Understanding the problem](Part_2.md)  <br>

<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
