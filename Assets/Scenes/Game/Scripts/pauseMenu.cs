using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class pauseMenu : MonoBehaviour
{

    public GameObject pauseMenuObject;
    private GameObject player;
    public Cinemachine.CinemachineFreeLook cineCam;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            showPauseMenu();
        }
    }

    public void showPauseMenu()
    {
        if(pauseMenuObject.activeSelf)
        {
            player.GetComponent<characterMovement>().enabled = true;
            cineCam.enabled = true;
            pauseMenuObject.SetActive(false);
            //Cursor.visible = false;
            return;
        }

        player.GetComponent<characterMovement>().enabled = false;
        cineCam.enabled = false;
        pauseMenuObject.SetActive(true);
        Cursor.visible = true;

    }

    public void exitToMainMenu()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }
}
