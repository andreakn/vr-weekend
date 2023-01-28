using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public string playerName = "Gandalf the Vague";
    private Collider collider;
    public GameObject cameraHolder;

    float turnSpeed = 4.0f;
    Rigidbody rigidbody = null;
    GameObject cam = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * 10f * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * 10f * Time.deltaTime;
        transform.Translate(x, 0, z); 
    }

    void Update(){
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0,mouseX*turnSpeed,0));

        float mouseY = Input.GetAxis("Mouse Y");
        cameraHolder.GetComponent<CameraHolder>().rotationY = mouseY;
    }
}
