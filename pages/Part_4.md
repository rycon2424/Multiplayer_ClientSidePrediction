## *Client-prediction and Server reconciliation*

# Tips and Optimization

## Unity's multiplayer playmode
Using this package from Unity makes developing multiplayer in general way easier. Since with it you can open multiple game windows and connect with them eachother. <br> <br>
*(Package name: "com.unity.multiplayer.playmode")* <br>
![multiplay](images/multiplay.PNG?raw=true)

## Don't spam Rpcs in the update loop
We're currently sending tick information to the server every tick, but we could optimize it by only transmitting when there's a change in position.

Then, on the server side, we can verify if the player hasn't moved since the last transmission and fill in the gap between the last received tick and the new one by using the new tick's position, given that the player hasn't moved in the till this point.

## Optimize the Rpc's by caching
The server can also cache the "lastMovementData" of the clients instead of the clients sending it themselves. This setup would make it truly anti cheat.

## Unity's client anticipation support (Netcode for Gameobject **only**)
Another interesting approach would be using the "AnticipatedNetworkVariable" that Netcode for Gameobjects has build in. By calling their various Anticipate methods, you can set a visual value that differs from the server value and then react to updates from the server in different ways. <br> <br> But keep in mind this is only a feature in Netcode for Gameobject

## More Tips? <br>
Feel free to e-mail me at: boskoivkovic.developer@gmail.com

<br> <br>
# All parts
[Part 1: Tutorial Intro](Part_1.md)  <br>
[Part 2: Understanding the problem](Part_2.md)  <br>
[Part 3: Resolving the problem](Part_3.md)  <br>
[Part 4: Tips and Optimization](Part_4.md)
