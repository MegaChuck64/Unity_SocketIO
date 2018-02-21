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
        players = new Dictionary<string, GameObject>();
    }

    void OnConnected(SocketIOEvent e)
    {
        Debug.Log("We are connected.");

        socket.Emit("playerhere");

    }

    void OnSpawn(SocketIOEvent e)
    {
        Debug.Log("Player spawned.");
        var player = Instantiate(playerPrefab);
        Material mat = new Material(player.GetComponent<Renderer>().material);
        mat.color = Random.ColorHSV();
        player.GetComponent<Renderer>().material = mat;
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
}
