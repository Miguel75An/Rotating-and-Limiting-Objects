using UnityEngine;
using System.Collections;
using System;

public class Example8 : MonoBehaviour
{

    public Transform center;
    public float spacing = 5f;
    public float mspeed = 10f;
    public float smooth_factor = 2;
    private Vector3 original_position;
    private bool should_return = false; 

    void Start()
    {
        original_position = transform.position;
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

        //transform.position = Vector3.MoveTowards(transform.position, original_position, mspeed * Time.deltaTime); //Doesn't work

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) ||
            should_return) //Activate this if, any wasd key is lifted or should_return is true
        {
            should_return = true; //we keep this true so every frame we "MoveTowards" a little to the original positon

            //transform.position = original_positon; //WE ABRUPTLY TRASNTALE WITH THIS LINE

            Debug.Log("========LERP========!");
            Debug.Log(original_position);

            transform.position = Vector3.MoveTowards(transform.position, original_position, mspeed * Time.deltaTime); //WORKS!

            //transform.position = Vector3.Lerp(transform.position, original_position, Time.deltaTime * smooth_factor); //Lerp interpolates a line between two objects

            if(transform.position == original_position)
            {
                should_return = false; //At this point we have reached the original position, so "turn off" any movement
            }

            
        }
    }

    private void LateUpdate()
    {
        //Return to original position after movement
        //transform.position = original_positon; DOESNT SEEM TO WORK

        //There is a method called OnMouseUp() which might help
    }

}