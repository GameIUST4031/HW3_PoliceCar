using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Movement : MonoBehaviour
{

    public Rigidbody car_rb;
    [SerializeField] float speed = 1000;

    // Update is called once per frame
    void Update()
    {
        
        // a = moving left
        if (Input.GetKey(KeyCode.A))
        {
            car_rb.AddForce(0, 0, speed * Time.deltaTime);
        }

        // d => moving right
        if (Input.GetKey(KeyCode.D))
        {
            car_rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        // w => moving forward
        if (Input.GetKey(KeyCode.W))
        {
            car_rb.AddForce(speed * Time.deltaTime, 0, 0);
        }

        // s => moving backward
        if (Input.GetKey(KeyCode.S))
        {
            car_rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }

    }
}
