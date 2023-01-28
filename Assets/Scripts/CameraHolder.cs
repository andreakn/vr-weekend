using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    float turnSpeed = 4.0f;
public float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


     transform.Rotate(new Vector3(-rotationY * turnSpeed,0,0));



    }
}
