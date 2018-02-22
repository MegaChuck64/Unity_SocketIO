using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;


public class network : MonoBehaviour
{
    static SocketIOComponent socket;

    public GameObject playerPrefab;

    Dictionary<string, GameObject> players;

    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("spawn player", OnSpawn);
        socket.On("disconnected", OnDisconnected);
        socket.On("move", OnMove);
        players = new Dictionary<string, GameObject>();
    }

    void OnConnected(SocketIOEvent e)
    {
        Debug.Log("We are connected.");

       // socket.Emit("playerhere");

    }

    void OnSpawn(SocketIOEvent e)
    {
        Debug.Log("Player spawned.");
        var player = Instantiate(playerPrefab);
        players.Add(e.data["id"].ToString(), player);
        Debug.Log("count: " + players.Count);
    }

    void OnDisconnected(SocketIOEvent e)
    {
        Debug.Log("Player disconnected: " + e.data);

        var id = e.data["id"].ToString();

        var player = players[id];

        Destroy(player);
        players.Remove(id);
    }

    void OnMove(SocketIOEvent e)
    {
       Debug.Log("Networked player is moving " + e.data);
        var id = e.data["id"].ToString();
        var player = players[id];
        var pos = new Vector3(GetFloatFromJson(e.data, "x"), 0, GetFloatFromJson(e.data, "y"));
        Debug.Log("pos: " + pos);

        var netMove = player.GetComponent<CharacterMovement>();
           
        netMove.NetworkMovement(pos);

        
    }

    float GetFloatFromJson(JSONObject data, string key)
    {
        return float.Parse(data[key].ToString().Replace("\"", ""));
    }
}
