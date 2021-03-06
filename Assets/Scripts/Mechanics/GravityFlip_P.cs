using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip_P : MonoBehaviour
{
    public GameObject gravity;

    public GameObject D103;
    public GameObject U20;

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Physics.gravity = new Vector3(0f, -9.807f, 0f);
            gravity.GetComponent<GravityFlip>().isFlipped = false;
            D103.GetComponent<D103Universal>().isGravityFlipped = false;
            D103.GetComponent<D103Universal>().oneTime = true;
            U20.GetComponent<PlayerController>().isGravityFlipped = false;
        }
    }
}
