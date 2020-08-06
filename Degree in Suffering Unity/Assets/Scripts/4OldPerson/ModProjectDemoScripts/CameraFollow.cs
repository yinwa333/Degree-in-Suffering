using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //target is the object we want the camera to look at
    public Transform target;

    //smoothSpeed adjusts the movement of the camera so it doesn't snap
    public float smoothSpeed = 0.125f;

    //this is the amount the camera is offset from the target
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Even though we're working within a 2D scene, the camera is offset and exists within 3D space, so we use Vector3
        // A Lerp is "linear interpolation", which finds values between two designated points. 
        //This is helpful for camera movement, where we want the camera to move smoothly between two points.
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        //This is the line that actually moves the camera and sets it's position to the smoothedPostition we calculated above.
        transform.position = smoothedPosition;

        //LookAt is used to automatically adjust the camera's rotation to look at the target. 
        //We need this because the Lerp and smooth mean the camera will sometimes be slightly behind the character movement.
        transform.LookAt(target);
    }
}
