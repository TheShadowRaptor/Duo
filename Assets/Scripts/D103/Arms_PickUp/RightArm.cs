using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{
    public float movingSpeed = 0;
    private Rigidbody rb;

    public bool stopF = false;
    public bool stopG = false;

    public GameObject NormalBlock;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
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

    // Update is called once per frame
    void FixedUpdate()
    {
        float xPos = Mathf.Clamp(transform.localPosition.x, 1.515f, 1.989f);
        transform.localPosition = new Vector3(xPos, 0.532f, 0.329f);
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("NormalBlock"))
            {
                stopF = true;
            }            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        stopF = false;
    } 
}