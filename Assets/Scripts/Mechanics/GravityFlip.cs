using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Player"))
            {
                Physics.gravity = new Vector3(0f, 9.807f, 0f);
            }                         
    }
}
