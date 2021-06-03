using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class photon_player : MonoBehaviourPunCallbacks
{
    
    private PhotonView pv;
    public GameObject myAvatar;
    public Cinemachine.CinemachineFreeLook cineCam;
    public GameObject a;

    void Start()
    {
        // print("yolo start");
        // pv = GetComponent<PhotonView>();
        // // if(SceneManagerHelper.ActiveSceneBuildIndex == 1)
        // // {
        // //     createPlayerModel();
        // // }
        // if(pv.IsMine)
        // {
             createPlayer();
        // }
    }

    void createPlayer()
    {
        Vector3 ogPos = transform.position;
        Vector3 pos = transform.position;
        pos.x = Convert.ToSingle(UnityEngine.Random.Range(10, 50));
        pos.y = 0f;
        pos.z = Convert.ToSingle(UnityEngine.Random.Range(10, 50));
        transform.position = pos;
        myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "player"), transform.position, Quaternion.identity, 0);
        cineCam.Follow = myAvatar.transform;
        cineCam.LookAt = myAvatar.transform;
        
        // transform.position = ogPos;
        //createPlayerModel();
    }

    void createPlayerModel()
    {
        print("scene loaded");
            Vector3 ogPos = transform.position;
            Vector3 pos = transform.position;
            pos.x = Convert.ToSingle(UnityEngine.Random.Range(10, 50));
            pos.z = Convert.ToSingle(UnityEngine.Random.Range(10, 50));
            transform.position = pos;
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "third person player"), transform.position, Quaternion.identity, 0);
            transform.position = ogPos;
        
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = 0f;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //create();
        }
    }

}
