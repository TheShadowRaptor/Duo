using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{
    public float movingSpeed = 0;
    private Rigidbody rb;

    public bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("f"))
        {
            transform.Translate(-0.01f, 0, 0);
        }

        if(stop == true)
        {
            if (Input.GetKey("f"))
            {
                transform.Translate(0.01f, 0, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("armCollid") || other.gameObject.CompareTag("NormalBlock"))
            {
                stop = true;
            }
        }
    }

}