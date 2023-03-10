using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFurniture : MonoBehaviour
{
    public GameObject[] Trees;
    public GameObject[] Houses;

private int radius = 200;  

int numberOfTrees = 2000;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(100000);
        for(int i = 0; i < numberOfTrees; i++){
            var obj = Trees[i%Trees.Length];
            var validLocation = GetRandomLocation(radius);
            var q = Quaternion.identity;
            if(i%100 == 0){
                     obj = Houses[0];
                     q = GetNormalFor(validLocation);
            }
             q = GetNormalFor(validLocation);
            var go = Instantiate(obj, validLocation, q);
            go.layer = 2;
        }
    }

Quaternion GetNormalFor(Vector3 vector){
     Ray ray = new Ray(new Vector3(vector.x,1000,vector.z), Vector3.down);
        if(Physics.Raycast(ray, out var hitData)){
           return Quaternion.FromToRotation (Vector3.up, hitData.normal);
        }
        return Quaternion.identity;
}

Vector3 GetRandomLocation(float radius){
    var found = false;
    var sanity = 0;
    float x = 0, y=0, z=0;
    while(!found && sanity < 100){
        sanity++;
         x = Random.Range(-1*radius, radius);
         z = Random.Range(-1*radius, radius);
         y = getHeight(x, z);
        if(y > 101 && y < 300){
            found = true;
        }
    }
   

    return new Vector3(x,y,z);
}

    float getHeight(float x, float z){
       
        Ray ray = new Ray(new Vector3(x,1000,z), Vector3.down);
        if(Physics.Raycast(ray, out var hitData)){
            return 1000 - hitData.distance ;
        }
        return 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
