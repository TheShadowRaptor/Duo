using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlock1 : MonoBehaviour
{
    public GameObject cameraBlock;
    public float turningSpeed = 0;
    public float movingSpeed = 0;

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
        if (Input.GetKeyDown("left"))
        {
            rb.velocity = -transform.right * movingSpeed;
        }

        if (Input.GetKeyUp("left"))
        {
            rb.velocity = -transform.right * (movingSpeed * 0);
        }

        if (Input.GetKeyDown("right"))
        {
            rb.velocity = transform.right * movingSpeed;
        }

        if (Input.GetKeyUp("right"))
        {
            rb.velocity = transform.right * (movingSpeed * 0);
        }
    }

    private void FixedUpdate()
    {
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

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.0f, 9f), 6.91f, -9.75f);
    }
}
