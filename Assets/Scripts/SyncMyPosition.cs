using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncMyPosition : MonoBehaviour {
    public GameObject syncObject;

    void Update() {
        syncObject.transform.position = transform.position;
        syncObject.transform.rotation = transform.rotation;
    }
}
