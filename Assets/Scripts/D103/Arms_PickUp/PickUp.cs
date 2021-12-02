using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private Transform theDest;

    public Material PickUpMaterial;
    public Material NormalMaterial;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        theDest = GameObject.FindWithTag("Dest").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey("q") && other.gameObject.tag == "GravityBeam")
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Renderer>().material = PickUpMaterial;
            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
            rb.isKinematic = true;
        }

        if (Input.GetKey("e") && other.gameObject.tag == "GravityBeam")
        {
            this.transform.parent = null;
            this.GetComponent<Renderer>().material = NormalMaterial;
            GetComponent<Rigidbody>().useGravity = true;
            rb.isKinematic = false;
        }

    }
}
