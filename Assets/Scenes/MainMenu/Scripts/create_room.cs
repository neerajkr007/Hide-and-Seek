using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class create_room : MonoBehaviourPunCallbacks, IMatchmakingCallbacks
{
    string RoomId;
    public TMPro.TMP_Text msg;
    public GameObject[] playerNames;
    public GameObject menu;
    public GameObject host;
    public TMPro.TMP_InputField inputName;
    public TMPro.TMP_Text log;
    string newPlayer;
    int playerCount;


    public void createRoom()
    {
        RoomId = UnityEngine.Random.Range(1000, 9999).ToString();
        RoomOptions options = new RoomOptions();
        options.IsVisible = false;
        options.MaxPlayers = (byte)10;
        PhotonNetwork.LocalPlayer.NickName = inputName.text;
        PhotonNetwork.CreateRoom(RoomId, options, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        msg.text = "Room created , Id - " + RoomId;
        //playerNames[0].SetActive(true);
        //playerNames[0].GetComponent<TMPro.TMP_Text>().text = inputName.text;
        menu.SetActive(false);
        host.SetActive(true);
        Debug.Log("created successfully");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        log.text = "room creation failed coz " + message;
        Debug.Log("room creation failed coz " + message);
    }
}

