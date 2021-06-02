using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class update_names : MonoBehaviourPunCallbacks, IMatchmakingCallbacks
{
    string newPlayer;
    int playerCount = 0;
    public GameObject[] playerNames = new GameObject[10];
    void Update()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount != playerCount)
        {
            playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            foreach(var kvp in PhotonNetwork.CurrentRoom.Players)
            {
                newPlayer = kvp.Value.NickName.ToString();
                playerNames[(kvp.Key - 1)].SetActive(true);
                playerNames[(kvp.Key - 1)].GetComponent<TMPro.TMP_Text>().text = newPlayer;
            }
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
