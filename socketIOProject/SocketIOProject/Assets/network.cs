using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;


public class network : MonoBehaviour
{
    static SocketIOComponent socket;

    public GameObject playerPrefab;

    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("spawn player", OnSpawn);
    }

    void OnConnected(SocketIOEvent e)
    {
        Debug.Log("We are connected.");

        socket.Emit("playerhere");

    }

    void OnSpawn(SocketIOEvent e)
    {
        Debug.Log("Player spawned.");
        Instantiate(playerPrefab);
    }
}
