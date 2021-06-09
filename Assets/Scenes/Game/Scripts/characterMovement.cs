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
    private Vector3 direction;
    private float targetAngle;
    public Vector3 moveDir;
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
            if(horizotal == 0f && horizotal != 1f)
            {
                //print(horizotal);//  + "  " + horizotal);
            }
            direction = new Vector3(horizotal, 0f, vertical).normalized;
            if(direction.magnitude >= 0.1f)
            {
                //print("works ?");
                if(direction.z >= 0f)
                {
                    targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                }
                else if(direction.z < 0)
                {
                    targetAngle = cam.eulerAngles.y;
                }
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                if(direction.z >= 0f)
                {
                    moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                }
                else if(direction.z < 0)
                {
                    moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.back;
                }
                 //print(moveDir + " / " + moveDir.normalized);
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
            Vector3 pos = transform.position;
            if(vertical == 0f)// && horizotal != 1f)
            {
                //print(pos.x  + "  " + pos.z);
            }
            if(pos.y != 0f)
            {
                pos.y = 0f;
                transform.position = pos;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(jumpCoroutine());
            }
        }
    }


    IEnumerator jumpCoroutine()
    {
        animator.SetTrigger("jump");
        yield return new WaitForSeconds(1.05f);
        animator.SetTrigger("jump");
    }
}