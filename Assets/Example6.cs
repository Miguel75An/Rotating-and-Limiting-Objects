using UnityEngine;
using System.Collections;
using System;

public class Example6 : MonoBehaviour
{

    public Transform center;
    public float spacing = 5f;
    private Vector3 v;
    public float mspeed = 10f;
    private Vector3 movement = new Vector3(5f, 0f, 0f);


    void Start()
    {
        // Requires the block to be directly to the right of the center
        //   with rotation set correctly on start
        v = (transform.position - center.position);
    }

    void Update()
    {
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

        //Calculate magniture using new postion 'pos'
        Vector3 new_distance = pos - center.position;
        float distance = Vector3.Distance(pos, center.position);

        //Magnitude is the distance between the two circle centers

        if (v.magnitude < 4) //in other words if it touches any point of distance == 4 then clamp it to that point, or update it to such point
        {
            //Place small circle just outside the big circle
            //But how can we clamp that?
        }
        else if(v.magnitude > 5)
        {
            //Place small circle just inside imaginary circle with radius 5
        }
        else
        {
            //No boundaries have been traspassed
            //Transform normally with keys

        }

        //Second attemp, calculating distances
        Debug.Log("new_distance = " + new_distance.magnitude);
        Debug.Log("distance = " + distance);


        //print(new_distance.magnitude);
        //print(distance);
        if (new_distance.magnitude < 4) //in other words if it touches any point of distance == 4 then clamp it to that point, or update it to such point
        {
            print("RAD4");
            //Place small circle just outside the big circle
            //But how can we clamp that?
            transform.position = Vector3.MoveTowards(transform.position, previous_position, mspeed * Time.deltaTime);
        }
        else if (new_distance.magnitude > 6)
        {
            //Place small circle just inside imaginary circle with radius 5
            transform.position = Vector3.MoveTowards(transform.position, pos, mspeed * Time.deltaTime);
        }
        else
        {
            //No boundaries have been traspassed
            //Transform normally with keys
            transform.position = Vector3.MoveTowards(transform.position, pos, mspeed * Time.deltaTime);

        }

        
    }

}