using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorball : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject sensor = null;
    GameObject bilbo = null;
    void Start()
    {
        bilbo = GameObject.Find("leHobbit");

        sensor = getChildGameObject(this.gameObject,"BilboSensor");
       
        
    }

    // Update is called once per frame
    void Update()
    {
        bilbo = bilbo ?? GameObject.Find("leHobbit");
        if(bilbo!=null){
        var distanceToBilbo = Vector3.Distance(bilbo.transform.position, transform.position);

        var renderer = sensor.GetComponent<Renderer>();
        renderer.material.SetColor("_Color",CalculateDistanceColor(distanceToBilbo));
        }
       
    }

    Color CalculateDistanceColor(float distance){
        var maxDistance = 300f;
        if(distance>maxDistance){
            distance = maxDistance;
        }
        var rd = distance / maxDistance;
        var ird = 1 - rd;
        Debug.Log("palantir color: "+rd);
        return Color.HSVToRGB(0.75f, 1.0f, ird);
    }


  static public GameObject getChildGameObject(GameObject fromGameObject, string withName) {
    //Author: Isaac Dart, June-13.
    Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
    foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
    return null;
}
}
