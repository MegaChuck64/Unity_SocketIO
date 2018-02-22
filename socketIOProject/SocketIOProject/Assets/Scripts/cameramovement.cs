using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float speed;
    float currentSpeed;
    Vector3 movement = Vector3.zero;

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");


        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement.y = Input.GetAxis("Vertical");
        }
        else
        {
            movement.z = Input.GetAxis("Vertical");
        }


        if (Input.GetKey(KeyCode.None))
        {
            currentSpeed = 0;
        }
        else
        {
            currentSpeed = speed;
        }
        transform.Translate(movement * currentSpeed * Time.deltaTime);
    }

    
}
