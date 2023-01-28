using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncMyPosition : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform transformToSyncTo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transformToSyncTo = transform;
    }
}
