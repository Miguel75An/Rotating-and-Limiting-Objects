using UnityEngine;
using System.Collections;
using System;

public class Example7 : MonoBehaviour
{

    public Transform center;
    public float spacing = 5f;
    public float mspeed = 10f;

    void Start()
    {

    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, center.position);
        Debug.Log("distance = " + distance);

        Vector3 previous_position = transform.position;
        Vector3 pos = transform.position;   //Get pos to be a Vector3 var holding all x,y,z components

        if (Input.GetKey(KeyCode.W))
            pos.y += spacing;
        if (Input.GetKey(KeyCode.S))
            pos.y -= spacing;
        if (Input.GetKey(KeyCode.A))
            pos.x -= spacing;
        if (Input.GetKey(KeyCode.D))
            pos.x += spacing;

        transform.position = Vector3.MoveTowards(transform.position, pos, mspeed * Time.deltaTime);

       

    }

}