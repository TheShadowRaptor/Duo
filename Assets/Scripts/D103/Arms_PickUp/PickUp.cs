using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject normalBox;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("g"))
        {
            Rigidbody normalBoxRigidbody = normalBox.GetComponent<Rigidbody>();
            normalBox.transform.parent = null;
            normalBoxRigidbody.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == normalBox && Input.GetKey("f"))
        {
            Rigidbody normalBoxRigidbody = normalBox.GetComponent<Rigidbody>();
            normalBox.transform.parent = transform;
            normalBoxRigidbody.isKinematic = true;
        }        
    }
}