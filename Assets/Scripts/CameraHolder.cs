using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    float turnSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    float mouseY = Input.GetAxis("Mouse Y");        
    transform.Rotate(new Vector3(-mouseY * turnSpeed,0,0));


    }
}
