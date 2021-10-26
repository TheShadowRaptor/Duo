using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform theDest;

    public Material PickUpMaterial;
    public Material NormalMaterial;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("g"))
        {
            this.transform.parent = null;
            this.GetComponent<Renderer>().material = NormalMaterial;
            GetComponent<Rigidbody>().useGravity = true;
            rb.isKinematic = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {      
        if (Input.GetKey("f"))
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Renderer>().material = PickUpMaterial;
            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
            rb.isKinematic = true;
        }
            
            
            
    }
}
