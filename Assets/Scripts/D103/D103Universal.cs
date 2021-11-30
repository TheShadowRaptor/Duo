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
    public bool moveDown = true;
    public bool moveUp = true;
    public bool moveDL = true;

    public bool isGravityFlipped = false;

    public Animator animator;

    private Rigidbody rb;

    private float xRotate;
    public float yRotate;

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
        if (Input.GetKey("left") && moveL == (true) && Input.GetKey("left shift") && isGravityFlipped == (false))
        {
            transform.Translate(-0.17f, 0, 0);
        }
        else if (Input.GetKey("left") && moveL == (true) && isGravityFlipped == (false))
        {
            transform.Translate(-0.12f, 0, 0);
        }

        if (Input.GetKey("right") && moveR == (true) && Input.GetKey("left shift") && isGravityFlipped == (false))
        {
            transform.Translate(0.17f, 0, 0);
        }
        else if (Input.GetKey("right") && moveR == (true) && isGravityFlipped == (false))
        {
            transform.Translate(0.12f, 0, 0);
        } 


        xRotate = cameraBlock.transform.eulerAngles.x;

        if (xRotate <= 70f || xRotate >= 290)
        {
            if (Input.GetKey("up") && (moveUp == true) && isGravityFlipped == (false))
            {
                xRotate += -turningSpeed;
            }

            if (Input.GetKey("down") && (moveDown == true) && isGravityFlipped == (false))
            {
                xRotate += turningSpeed;
            }
        }

        else if (xRotate > 70f && xRotate < 170f)
        {
            xRotate = 69.9f;
        }

        else if (xRotate < 290f && xRotate > 170f)
        {
            xRotate = 290.1f;
        }
            cameraBlock.transform.rotation = Quaternion.Euler(xRotate, yRotate, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") && Input.GetKey("left"))
        {
            moveL = false;
        }
        if (collision.gameObject.CompareTag("Wall") && Input.GetKey("right"))
        {
            moveR = false;
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            moveDown = false;
            Debug.Log("Hit");
        }
        if (collision.gameObject.CompareTag("Ceiling") && Input.GetKey("up"))
        {
            moveUp = false;
        }       

        //-------------------------------------------------------------------------------
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            moveL = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            moveR = true;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            moveDown = true;
        }
        
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            moveUp = true;
        }
    }
}

