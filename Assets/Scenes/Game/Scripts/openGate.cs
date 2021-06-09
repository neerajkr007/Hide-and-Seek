using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class openGate : MonoBehaviour
{
    Animator animator;
    private GameObject player;
    private characterMovement cm;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(getPlayer()); 
    }

    IEnumerator getPlayer()
    {
        yield return new WaitForSeconds(1);
        player = GameObject.FindWithTag("Player");
        if(player.GetComponent<PhotonView>().IsMine)
        {
            cm = player.GetComponent<characterMovement>();
            //print("is mine");
        }
        else
        {
            //print("is not mine");
        }
    }


    //      FUTURE ME U NEED TO USE MOVEdIR TO CHECK THE DOOR'S ORIENTATION AS WELL THE FIRST LEVEL HAD ALL DOOR IN SAME DIRECTION 


    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "player(Clone)")
        {
            //print("entered  " + cm.moveDir);
            if(cm.moveDir.x < 0)
            {
                Quaternion rotation = Quaternion.Euler(0, 90, 0);
                gameObject.transform.SetPositionAndRotation(gameObject.transform.position, rotation);
            }
            else if(cm.moveDir.x > 0)
            {
                Quaternion rotation = Quaternion.Euler(0, -90, 0);
                gameObject.transform.SetPositionAndRotation(gameObject.transform.position, rotation);
            }
            animator.SetBool("isOpen_Obj_1", true);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.name == "player(Clone)")
        {
            //print("staying " + cm.moveDir);

            animator.SetBool("isOpen_Obj_1", true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.name == "player(Clone)")
        {
            // print("exited");
            animator.SetBool("isOpen_Obj_1", false);
        }
    }
}
