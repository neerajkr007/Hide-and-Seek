using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Connect : MonoBehaviourPunCallbacks, IMatchmakingCallbacks
{

    void Start()
    {
        PhotonNetwork.GameVersion = "v1.0";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        print("connected to server. ");
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("disconnected from server coz " + cause.ToString());
        //msg.text = cause.ToString();
    }

}
