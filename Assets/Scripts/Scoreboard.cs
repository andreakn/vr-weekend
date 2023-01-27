using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class Scoreboard : MonoBehaviourPunCallbacks {

    public TMP_Text textMesh;

    private Dictionary<int, int> scores = new Dictionary<int, int>();

    void Start() {
        UpdateScoreboardText();
    }

    [PunRPC]
    void OnPlayerScored(int actorNumber, int score) {
        var player = getPlayerByActorNumber(actorNumber);
        if (player == null) {
            return;
        }

        scores[actorNumber] = score;
    }

    private void UpdateScoreboardText() {
        var text = "";
        foreach (var score in scores) {
            var player = getPlayerByActorNumber(score.Key);
            if (player == null) {
                continue;
            }

            text += player.NickName + ": " + score.Value + "\n";
        }

        textMesh.text = text;
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