using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public bool flip = false;

    public GameObject camera;

    public GameObject D103;
    public GameObject U20;

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            Physics.gravity = new Vector3(0f, 9.807f, 0f);
            camera.transform.Rotate(0, 0 * Time.deltaTime, 180);
            flip = true;
            D103.GetComponent<D103Universal>().isGravityFlipped = true;
            U20.GetComponent<PlayerController>().isGravityFlipped = true;
        }                        
    }
}
