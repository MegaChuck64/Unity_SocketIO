using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NetworkMovement : MonoBehaviour
{
    Vector3 pos;
    public SocketIOComponent socket;


    void FixedUpdate()
    {
        pos = transform.position;
        OnMove(pos);
    }

    public void OnMove(Vector3 position)
    {
        Debug.Log("sending pos to server " + VectorToJson(position));
        socket.Emit("move", new JSONObject(VectorToJson(position)));
    }


    string VectorToJson(Vector3 vector)
    {
        return string.Format(@"{{""x"":""{0}"", ""y"":""{1}""}}", vector.x, vector.z);
    }
}


