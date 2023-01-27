using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;

    public GameObject dwarfPrefab;
    public GameObject hobbitPrefab;

    int r = 200;

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

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        
        SpawnHobbit();
    }

    public override void OnJoinedRoom()
    {


        SpawnPlayer();
        Debug.Log("Joined room success");

        SpawnDwarves();
        
    }

    void SpawnPlayer(){
         var x = Random.Range(-1*r,r);
        var z = Random.Range(-1*r,r);
        var y = getHeight(x,z)+1f;

        var playerObj = PhotonNetwork.Instantiate("Player", new Vector3(x,y,z), Quaternion.identity);
        
        // Assign a name to the player
        var player = playerObj.GetComponent<Player>();
        var names = new string[] {
            "Gandalf the Gray",
            "Gandalf the White",
            "Saruman the White",
            "Radagast the Brown",
            "Alatar the Blue",
            "Pallando the Also Bluer",
            "Fufu the Green",
            "Jebb the Red",
            "Frode the Yellow",
        };

        var index = PhotonNetwork.CountOfPlayers;
        if (index < names.Length) {
            player.playerName = names[index];
        } else {
            player.playerName = "Pippin the Overflowed";
        }
    }

    void SpawnHobbit(){
        var x = Random.Range(-1*r,r);
        var z = Random.Range(-1*r,r);
        var y = getHeight(x,z)+1f;

        PhotonNetwork.Instantiate("leHobbit", new Vector3(x,y,z), Quaternion.identity);
        // Debug.Log("Spawned hobbit @ "+x+" "+y+" "+z+" ");
    }   
    void SpawnDwarves(){
        for(int i = 0; i < 300; i++){
            var x = Random.Range(-1*r,r);
            var z = Random.Range(-1*r,r);
            var y = getHeight(x,z)+1f;

            Instantiate(dwarfPrefab ,new Vector3(x,y,z),Quaternion.identity);
            //Debug.Log("Spawned local dwarf @ "+x+" "+y+" "+z+" ");
        }

    }

    float getHeight(float x, float z){
        Ray ray = new Ray(new Vector3(x,1000,z), Vector3.down);
        if(Physics.Raycast(ray, out var hitData)){
            return 1000 - hitData.distance ;
        }
        return 1000;
    }
}
