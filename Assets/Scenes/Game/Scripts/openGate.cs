using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "player(Clone)")
        {
            // print("entered");
            animator.SetBool("isOpen_Obj_1", true);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.name == "player(Clone)")
        {
            // print("staying");
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
