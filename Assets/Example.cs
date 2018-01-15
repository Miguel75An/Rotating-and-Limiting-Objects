using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
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
    }
}