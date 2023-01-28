using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GandalfSpawner : MonoBehaviourPunCallbacks {
    public GameObject gandalfPrefab;

    void Start() {
        if (!photonView.IsMine) {
            var gandalf = MonoBehaviour.Instantiate(gandalfPrefab);
            gandalf.transform.parent = transform;
        }
        
    }
}
