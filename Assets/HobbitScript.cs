using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HobbitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var height = getHeight(transform.position.x, transform.position.y);
        var actualHeight = transform.position.y;

        if((height-actualHeight) > 2){
            transform.SetPositionAndRotation(new Vector3(transform.position.x, height, transform.position.y), Quaternion.identity);
        }
    }

     float getHeight(float x, float z){
       
        Ray ray = new Ray(new Vector3(x,1000,z), Vector3.down);
        if(Physics.Raycast(ray, out var hitData)){
            return 1000 - hitData.distance ;
        }
        return 1000;
    }
}
