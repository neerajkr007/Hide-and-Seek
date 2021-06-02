using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class join_room : MonoBehaviourPunCallbacks, IMatchmakingCallbacks
{
    public TMPro.TMP_InputField input;
    public TMPro.TMP_InputField playerName;
    public GameObject join;
    public GameObject host;
    public GameObject[] names; 
    public TMPro.TMP_Text msg;
    public TMPro.TMP_Text log;
    public GameObject startButton;
    string roomId;
    //string[] playerList = new string[10];
    public void joinRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = playerName.text;
        roomId = input.text;
        print(roomId);
        if(roomId != "" && roomId.Length == 4)
        {
            PhotonNetwork.JoinRoom(roomId);
        }
    }
    public override void OnJoinedRoom()
    {
        msg.text = "Room created , Id - " + roomId;
        startButton.SetActive(false);
        Debug.Log("joined the room");
        join.SetActive(false);
        host.SetActive(true);
        // foreach(var kvp in PhotonNetwork.CurrentRoom.Players)
        // {
        //     playerList[(kvp.Key - 1)] = kvp.Value.NickName.ToString();
        // }
        // for(int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        // {
        //     names[i].SetActive(true);
        //     names[i].GetComponent<TMPro.TMP_Text>().text = playerList[i];
        // }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        
        log.text = "room creation failed coz " + message;
        Debug.Log("failed coz " + message);
    }
}
