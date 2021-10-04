using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemMove : MonoBehaviour
{
    public float movingSpeed = 0;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            rb.velocity = -transform.right * movingSpeed;
        }

        if (Input.GetKey("e"))
        {
            rb.velocity = transform.right * movingSpeed;
        }
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1f, 15f), 10.76f, -18.131f);
    }
}
