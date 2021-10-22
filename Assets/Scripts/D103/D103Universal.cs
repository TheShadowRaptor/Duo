using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D103Universal : MonoBehaviour
{
    public GameObject cameraBlock;
    public float turningSpeed = 0;
    public float movingSpeed = 0;

    public bool moveL = true;
    public bool moveR = true;

    private Rigidbody rb;

    private float xRotate;
    private float yRotate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey("left") && moveL == (true) && Input.GetKey("left shift"))
        {
            transform.Translate(-0.12f, 0, 0);
        }
        else if (Input.GetKey("left") && moveL == (true))
        {
            transform.Translate(-0.07f, 0, 0);
        }

        if (Input.GetKey("right") && moveR == (true) && Input.GetKey("left shift"))
        {
            transform.Translate(0.12f, 0, 0);
        }
        else if (Input.GetKey("right") && moveR == (true))
        {
            transform.Translate(0.07f, 0, 0);
        }

        xRotate = cameraBlock.transform.eulerAngles.x;

        if (xRotate <= 70f || xRotate >= 360)
        {
            if (Input.GetKey("up"))
            {
                xRotate += -turningSpeed;
            }

            if (Input.GetKey("down"))
            {
                xRotate += turningSpeed;
            }
        }

        else if (xRotate > 70f && xRotate < 180f)
        {
            xRotate = 69.9f;
        }

        else if (xRotate < 360f && xRotate > 180f)
        {
            xRotate = 360.1f;
        }

        cameraBlock.transform.rotation = Quaternion.Euler(xRotate, yRotate, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") && Input.GetKey("left") || collision.gameObject.CompareTag("Wall") && Input.GetKey("left") && Input.GetKey("left shift"))
        {
            moveL = false;
        }
        if (collision.gameObject.CompareTag("Wall") && Input.GetKey("right") || collision.gameObject.CompareTag("Wall") && Input.GetKey("right") && Input.GetKey("left shift"))
        {
            moveR = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        moveL = true;
        moveR = true;
    }
}

