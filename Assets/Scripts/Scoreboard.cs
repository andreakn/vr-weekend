using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Photon.Pun;

public class Scoreboard : MonoBehaviourPunCallbacks {

    [PunRPC]
    void OnPlayerScored(int actorNumber, int score) {
        var player = getPlayerByActorNumber(actorNumber);
        if (player == null) {
            return;
        }

        Debug.Log("Player " + player.NickName + " scored " + score + " points");
    }

    private Photon.Realtime.Player getPlayerByActorNumber(int actorNumber) {
        var playerList = PhotonNetwork.PlayerList;
        for (int i = 0; i < playerList.Length; i++) {
            if (playerList[i].ActorNumber == actorNumber) {
                return playerList[i];
            }
        }

        return null;
    }
}