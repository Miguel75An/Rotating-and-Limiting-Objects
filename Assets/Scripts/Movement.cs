using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float mspeed = 10f;
    private Vector3 movement = new Vector3(5f, 0f, 0f);

    void Start()
    {
    }

    void Update()
    {
        PlayerController();
    }

    void PlayerController()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(movement * mspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-movement * mspeed * Time.deltaTime);
        }

        Vector3 pos = transform.position;   //Get pos to be a Vector3 var holding all x,y,z components
        pos.x = Mathf.Clamp(pos.x, -8, 8);  //Clamp only the x component of pos
        transform.position = pos;           //Update transform position
    }
}
