using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static Scoreboard scoreboard { get { return instance.scoreboardObj.GetComponent<Scoreboard>(); } }

    private GameObject scoreboardObj;

    void Start() {
        Debug.Log("GameController instantiated")
        instance = this;
    }

    public void ConnectedToRoom() {
        Debug.Log("GameController creating networked objects for RPC calls");
        scoreboardObj = PhotonNetwork.Instantiate("Scoreboard", Vector3.zero, Quaternion.identity);
    }
}
