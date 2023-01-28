using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCollisionDetector : MonoBehaviour
{
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Contains("leDwarf")){
            Debug.Log("I hit a dwarf");
            score--;
            GameController.scoreboard.photonView.RPC("OnPlayerScored", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, score);
        }
        else if(other.gameObject.name.Contains("leHobbit")){
            score+=100;
            GameController.scoreboard.photonView.RPC("OnPlayerScored", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, score);
            Debug.Log("I hit a hobbit");
        }
    }
}
