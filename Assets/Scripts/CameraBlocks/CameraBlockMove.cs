using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlockMove : MonoBehaviour
{
    public GameObject cameraBlock;
    public float turningSpeed = 0;
    public float movingSpeed = 0;

    private Rigidbody rb;

    private float Xrotate;
    private float Yrotate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Physics.IgnoreCollision(cameraBlock.GetComponent<Collider>(), GetComponent<Collider>());
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
        Xrotate = cameraBlock.transform.eulerAngles.x;

        if (Xrotate <= 85f || Xrotate >= 360)
        {
            if (Input.GetKey("up"))
            {
                Xrotate += -turningSpeed;
            }

            if (Input.GetKey("down"))
            {
                Xrotate += turningSpeed;
            }
        }

        else if (Xrotate > 85f && Xrotate < 180f)
        {
            Xrotate = 84.9f;
        }

        else if (Xrotate < 360f && Xrotate > 180f)
        {
            Xrotate = 360.1f;
        }

        cameraBlock.transform.rotation = Quaternion.Euler(Xrotate, Yrotate, 0f);
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.9f, 8.3f), 10.9f, -7f);
    }
}
