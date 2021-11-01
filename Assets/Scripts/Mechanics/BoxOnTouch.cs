using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOnTouch : MonoBehaviour
{

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.freezeRotation = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.freezeRotation = false;
        }
    }
}
