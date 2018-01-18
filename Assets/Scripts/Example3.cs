using UnityEngine;
using System.Collections;

public class Example3 : MonoBehaviour
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

        transform.position = center.position + q * v;
        transform.rotation = q;

        Vector3 pos = transform.position;   //Get pos to be a Vector3 var holding all x,y,z components
        pos.x = Mathf.Clamp(pos.x, -4, 4);  //Clamp the x component of pos
        pos.y = Mathf.Clamp(pos.y, 0, 4);   //Clamp the y component of pos
        transform.position = pos;           //Update transform position


    }
}