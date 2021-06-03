using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        print(collision.collider.name);
    }
}
