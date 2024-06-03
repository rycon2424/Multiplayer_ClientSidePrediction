## *Client-prediction and Server reconciliation*

# Tips and Optimization

## Unity's multiplayer playmode
Using this package from unity makes developing multiplayer in general way easier. Since can open multiple game windows and connect with eachother. <br> <br>
*(Package name: "com.unity.multiplayer.playmode")* <br>
![multiplay](images/multiplay.PNG?raw=true)

## Don't spam Rpcs in the update loop
tell us

## Optimize the Rpc's by caching
The server can also cache the "lastMovementData" of the clients instead of the clients sending it themselves. This setup would also make it even more anti cheat.

## Check if (movement) value has changed before sending
tell us

## Unity's client anticipation support (Netcode for Gameobject **only**)
tell us

## More Tips? <br>
Feel free to e-mail me at: boskoivkovic.developer@gmail.com

<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
