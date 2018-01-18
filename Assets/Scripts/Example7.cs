using UnityEngine;
using System.Collections;
using System;

public class Example7 : MonoBehaviour
{

    public Transform center;
    public float spacing = 5f;
    public float mspeed = 10f;
    private Vector3 original_positon;

    void Start()
    {
        original_positon = transform.position;
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

       if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || 
          Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            transform.position = original_positon;
        }
    }

    private void LateUpdate()
    {
        //Return to original position after movement
        //transform.position = original_positon; DOESNT SEEM TO WORK

        //There is a method called OnMouseUp() which might help
    }

}