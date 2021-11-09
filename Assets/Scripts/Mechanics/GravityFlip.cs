using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public Transform target;
    public bool flip = false;

    public GameObject camera;

    public GameObject D103;
    public GameObject U20;

    public float speed;

    private void Start()
    {
       
    }
    private void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            
            Physics.gravity = new Vector3(0f, 9.807f, 0f);
            camera.transform.Rotate = Quaternion.Slerp(transform.rotation, target.rotation, speed * Time.deltaTime);
            flip = true;
            D103.GetComponent<D103Universal>().isGravityFlipped = true;
            U20.GetComponent<PlayerController>().isGravityFlipped = true;
        }                        
    }
}
