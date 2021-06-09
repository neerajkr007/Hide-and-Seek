using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("shooting", true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("shooting", false);
        }
        if(animator.GetBool("shooting"))
        {
            gameObject.GetComponent<characterMovement>().speed = 3f;
            
        }
        else
        {
            gameObject.GetComponent<characterMovement>().speed = 6f;
        }
    }
}
