using UnityEngine;
using System.Collections;
using System;

public class Example4 : MonoBehaviour
{

    public Transform center;
    private Vector3 v;


    void Start()
    {
        // Requires the block to be directly to the right of the center
        //   with rotation set correctly on start
        v = (transform.position - center.position);
    }

    void Update()
    {
        Vector3 centerScreenPos = Camera.main.WorldToScreenPoint(center.position);
        Vector3 dir = Input.mousePosition - centerScreenPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        float distance = dir.magnitude;

        //Console.WriteLine("Welcome to the C# Station Tutorial!" , distance);
        
        print(distance);
        
        if (distance < 80) //less than circle radius
        {
            print("INNER");
            v = Vector3.ClampMagnitude(v, 4); //New Clamp for Circle, 3 is circle radius
                                              //The object will move inside any point of the circle of radius 3
        }
        else
        {
            print("Clamp5");
            v = Vector3.ClampMagnitude(v, 5); //New Clamp for Circle, 3 is circle radius
                                              //The object will move inside any point of the circle of radius 3
        }


        transform.position = center.position + q * v;
        //transform.position = center.position +  v;
        transform.rotation = q;

        //Vector3 pos = transform.position;   //Get pos to be a Vector3 var holding all x,y,z components
        //pos.x = Mathf.Clamp(pos.x, -4, 4);  //Clamp the x component of pos
        //pos.y = Mathf.Clamp(pos.y, 0, 4);   //Clamp the y component of pos
        

        /*if(pos.y > 5)
        {
            pos.y = 5;
        }
        
        if(pos.y < 4)
        {
            pos.y = 4;
        } */

        //transform.position = pos;           //Update transform position


        // C#
        //Vector3 v = newLocation - circleCenter;
        //v = Vector3.ClampMagnitude(v, circleRadius);
        //newLocation = circleCenter + v;

    }
}