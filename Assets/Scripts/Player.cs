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

         var height = getHeight(transform.position.x, transform.position.y);
        var actualHeight = transform.position.y;

        // if((height-actualHeight) > 2){
        //     transform.SetPositionAndRotation(new Vector3(transform.position.x, height, transform.position.y), Quaternion.identity);
        // }
    }

     float getHeight(float x, float z){
       
        Ray ray = new Ray(new Vector3(x,1000,z), Vector3.down);
        if(Physics.Raycast(ray, out var hitData)){
            return 1000 - hitData.distance ;
        }
        return 1000;
    }
}
