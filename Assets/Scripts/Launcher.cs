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
        SpawnPlayer();
        Debug.Log("Joined room success");
        
    }

    void SpawnPlayer(){
         var x = Random.Range(-300,300);
        var z = Random.Range(-300,300);
        var y = getHeight(x,z)+1f;

        PhotonNetwork.Instantiate("Player", new Vector3(x,y,z), Quaternion.identity);
    }




      float getHeight(float x, float z){
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(x,1000,z), Vector3.down);
        if(Physics.Raycast(ray, out var hitData)){
            return 1000 - hitData.distance ;
        }
        return 1000;
    }
}
