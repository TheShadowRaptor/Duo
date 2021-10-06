using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{
    public float movingSpeed = 0;
    private Rigidbody rb;

    public bool stopF = false;
    public bool stopG = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stopF == false && Input.GetKey("f"))
        {
            transform.Translate(-0.01f, 0, 0);
        }

        if (stopF == true)
        {
            transform.Translate(0, 0, 0);
        }

        if (stopG == false && Input.GetKey("g"))
        {
            transform.Translate(0.01f, 0, 0);
        }

        if (stopG == true)
        {
            transform.Translate(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("armCollid") || other.gameObject.CompareTag("NormalBlock"))
            {
                stopF = true;
            }
        }
        if (other.gameObject.CompareTag("Screw"))
        {
            stopG = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        stopF = false;
        stopG = false;
    }
}