using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class characterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private PhotonView pv;
    public Animator animator;

    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
        pv = GetComponent<PhotonView>();
    }
    void Update()
    {
        // the pv.ismine is only for debugging and dev purposes 

        if(pv.IsMine)
        {
            float horizotal = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("horizontal", horizotal);
            float vertical = Input.GetAxis("Vertical");
            animator.SetFloat("vertical", vertical);
            if(vertical != 0f && vertical != 1f)
            {
                //print(vertical + "  " + horizotal);
            }
            Vector3 direction = new Vector3(horizotal, 0f, vertical).normalized;

            if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        }
        
    }
}