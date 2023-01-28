using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;

    public GameObject dwarfPrefab;
    public GameObject hobbitPrefab;
    public GameObject vrPlayerPrefab;
    public GameObject nonVrPlayerPrefab;


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
        Debug.Log("Created room " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        var room = PhotonNetwork.CurrentRoom;
        

        Debug.Log("Joined room " + PhotonNetwork.CurrentRoom.Name);
        GameController.instance.ConnectedToRoom();
        SpawnPlayer();
        SpawnHobbit();
        SpawnDwarves();
    }

Vector3 GetValidLocation(){
    var found = false;
    var sanity = 0;
    float x = 0, y=0, z=0;
    while(!found && sanity < 100){
        sanity++;
         x = Random.Range(-1*r, r);
         z = Random.Range(-1*r, r);
         y = getHeight(x, z);
        if(y > 101 && y < 300){
            found = true;
        }
    }
   

    return new Vector3(x,y,z);
}

Vector3 GetValidLocation(float radius){
    var found = false;
    var sanity = 0;
    float x = 0, y=0, z=0;
    while(!found && sanity < 100){
        sanity++;
         x = Random.Range(-1*radius, radius);
         z = Random.Range(-1*radius, radius);
         y = getHeight(x, z);
        if(y > 101 && y < 300){
            found = true;
        }
    }
   

    return new Vector3(x,y,z);
}

    void SpawnPlayer(){
        var validLocation = GetValidLocation(2);
        var mod = new Vector3(validLocation.x, validLocation.y+1, validLocation.z);
        var syncPosition = PhotonNetwork.Instantiate("SyncPosition", mod, Quaternion.identity);
        
        GameObject player;
        if (UnityEngine.XR.XRSettings.enabled) {
            Debug.Log("Instantiating VR player");
            player = MonoBehaviour.Instantiate(vrPlayerPrefab, mod, Quaternion.identity);
        } else {
            Debug.Log("Instantiating Non-VR player");
            player = MonoBehaviour.Instantiate(nonVrPlayerPrefab, mod, Quaternion.identity);
        }

        player.GetComponent<SyncMyPosition>().syncObject = syncPosition;
    }

    void SpawnHobbit(){
        PhotonNetwork.Instantiate("leHobbit", GetValidLocation(), Quaternion.identity);
    }
    void SpawnDwarves(){
        for(int i = 0; i < 300; i++){
            Instantiate(dwarfPrefab ,GetValidLocation(),Quaternion.identity);
         
        }

    }

    float getHeight(float x, float z){
        Ray ray = new Ray(new Vector3(x,1000,z), Vector3.down);
        if(Physics.Raycast(ray, out var hitData)){
            return 1000 - hitData.distance ;
        }
        return 1000;
    }

    private void AssignNickname() {
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
            PhotonNetwork.LocalPlayer.NickName = names[index];
        } else {
            PhotonNetwork.LocalPlayer.NickName = "Pippin the Overflowed";
        }
    }
}
