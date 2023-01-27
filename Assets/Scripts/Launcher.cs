using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //try to connect
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room success");
        PhotonNetwork.Instantiate("Player", new Vector3(0,-0.2f,0), Quaternion.identity);
    }
}
