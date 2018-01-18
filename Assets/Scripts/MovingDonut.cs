using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDonut : MonoBehaviour {

    public float mspeed = 10f;
    public float smooth_factor = 2;
    private Vector3 destination_position = new Vector3(0,0,0);

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position = Vector3.MoveTowards(transform.position, destination_position, mspeed * Time.deltaTime); //WORKS WONDERFULLY! Smooth transition to destination

        transform.position = Vector3.Lerp(transform.position, destination_position, Time.deltaTime * smooth_factor); //Lerp interpolates a line between two objects
        //Lerp also works amazingly with smooth_factor set to 0.5 and seems faster than MoveTowards

        Debug.Log(Time.frameCount); //This will show total number of frames that have passed
    }
}
