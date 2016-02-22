using UnityEngine;
using System.Collections;
using System;

public class ObjectMover : MonoBehaviour
{
    public Transform startLocation, endLocation;
    public float speed = 0.5f;
    public float delay = 0f;

    private bool forward = true;
    private int reverseFactor = 1;
    private float delayTimer;

    void Start()
    {
        delayTimer = Time.time + delay;
    }

    void Update()
    {
        if (Time.time < delayTimer)
        {
            return;
        }

         if(forward && EndpointReached())
         {
             forward = false;
             reverseFactor = -1;
         }
         else if(!forward && StartpointReached())
         {
             forward = true;
             reverseFactor = 1;
         }

        transform.Translate((endLocation.position - startLocation.position) * reverseFactor * speed * Time.deltaTime, Space.World);
    }

    private bool EndpointReached()
    {
        return Vector3.Distance(startLocation.position, transform.position) > Vector3.Distance(startLocation.position, endLocation.position);
    }

    private bool StartpointReached()
    {
        return Vector3.Distance(endLocation.position, transform.position) > Vector3.Distance(startLocation.position, endLocation.position);
    }
}
