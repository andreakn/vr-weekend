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
        // SpawnHobbit();
        // SpawnDwarves();
    }

    void SpawnPlayer(){
         var x = Random.Range(-1*r,r);
        var z = Random.Range(-1*r,r);
        var y = getHeight(x,z)+1f;

        var syncPosition = PhotonNetwork.Instantiate("SyncPosition", new Vector3(x,y,z), Quaternion.identity);
        
        GameObject player;
        if (UnityEngine.XR.XRSettings.enabled) {
            Debug.Log("Instantiating VR player");
            player = MonoBehaviour.Instantiate(vrPlayerPrefab, new Vector3(x,y,z), Quaternion.identity);
        } else {
            Debug.Log("Instantiating Non-VR player");
            player = MonoBehaviour.Instantiate(nonVrPlayerPrefab, new Vector3(x,y,z), Quaternion.identity);
        }

        player.GetComponent<SyncMyPosition>().syncObject = syncPosition;
    }

    void SpawnHobbit(){
        var x = Random.Range(-1*r,r);
        var z = Random.Range(-1*r,r);
        var y = getHeight(x,z)+1f;

        PhotonNetwork.Instantiate("leHobbit", new Vector3(x,y,z), Quaternion.identity);
        Debug.Log("Spawned hobbit @ "+x+" "+y+" "+z+" ");
    }   
    void SpawnDwarves(){
        return;
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
