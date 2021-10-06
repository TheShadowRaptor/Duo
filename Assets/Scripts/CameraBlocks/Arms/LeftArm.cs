using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
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

    void Update()
    {
        if (stopF == false && Input.GetKey("f"))
        {
            transform.Translate(0.01f, 0, 0);
        }

        if (stopF == true)
        {
            transform.Translate(0, 0, 0);
        }

        if (stopG == false && Input.GetKey("g"))
        {
            transform.Translate(-0.01f, 0, 0);
        }

        if (stopG == true)
        {
            transform.Translate(0, 0, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = new Vector3(Mathf.Clamp(transform.position.x, -1.043943f, -0.5439431f), 0.2f, 0.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NormalBlock"))
        {
            stopF = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stopF = false;
    }
}
