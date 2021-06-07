using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Connect : MonoBehaviourPunCallbacks, IMatchmakingCallbacks
{

    public GameObject alert;
    public TMPro.TMP_InputField playerName;
    void Start()
    {
        if(!PhotonNetwork.IsConnected)
        {
            alert.SetActive(true);
            PhotonNetwork.GameVersion = "v1.0";
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            playerName.text = PhotonNetwork.LocalPlayer.NickName;
            alert.SetActive(false);
        }
    }
    public override void OnConnectedToMaster()
    {
        alert.SetActive(false);
        print("connected to server. ");
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("disconnected from server coz " + cause.ToString());
        //msg.text = cause.ToString();
    }

}
