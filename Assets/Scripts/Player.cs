using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{
    float turnSpeed = 4.0f;
    Rigidbody rigidbody = null;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();



    }

    float getHeight(float x, float z){
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(x,1000,z), Vector3.down);
        if(Physics.Raycast(ray, out var hitData)){
            return 1000 - hitData.distance;
        }
        return 1000;
    }

    void FixedUpdate()
    {
        if(photonView.IsMine){
            float x = Input.GetAxis("Horizontal") * 10f * Time.deltaTime;
            float z = Input.GetAxis("Vertical") * 10f * Time.deltaTime;
            transform.Translate(x, 0, z);
        }


    }

void Update(){
    

float mouse = Input.GetAxis("Mouse X");
 transform.Rotate(new Vector3(0,mouse*turnSpeed,0));
}

}
