using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GandalfSpawner : MonoBehaviourPunCallbacks {
    public GameObject gandalfPrefab;
    private GameObject gandalf;

    void Start() {
        if (!photonView.IsMine) {
            gandalf = MonoBehaviour.Instantiate(gandalfPrefab, Vector3.zero, Quaternion.Euler(270, 0, 0));
        }
        
    }

    void Update() {
        if (gandalf != null) {
            gandalf.transform.position = transform.position;
            var rotation = transform.rotation;
            gandalf.transform.rotation = Quaternion.Euler(270, rotation.eulerAngles.y - 180, 0);
        }
    }
}
