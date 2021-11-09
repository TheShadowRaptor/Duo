using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 0;
    public float jump = 0;
    public float rayLength;
    public float falseGravityPos = 0;
    public float falseGravityNag = 0;


    private Rigidbody rb;

    public bool isgrounded;
    public bool isGravityFlipped = false;

    private float MovementX;
    private float MovementY;
    public bool stop = true;
    public bool gravityNorm = true;

    // Start is called before the first frame update
    void Start()
        //=================Gives RigidBody=====================
    {
        rb = GetComponent<Rigidbody>();     
    }
        //=====================================================
    void Update()
    {
        //=================Clamps Jump=========================
        if(rb.velocity.magnitude > jump)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, jump);
        }
        //=====================================================
    }

    private void OnMove(InputValue movementValue)
    {
        //============Determines movement values================
        Vector2 movementVector = movementValue.Get<Vector2>();

        MovementX = movementVector.x;
        MovementY = movementVector.y;
        //======================================================
    }

    // Update is called once per frame
    private void FixedUpdate()
    {     
        //=================Raycast Ground detect================
        
        if (isGravityFlipped == false)
        {
            RaycastHit hit;
            Ray Grounded = new Ray(transform.position, Vector3.down);
            if (!isgrounded)
            {
                if (Physics.Raycast(Grounded, out hit, rayLength))
                {
                    if (hit.collider)
                    {
                        isgrounded = true;
                    }
                    else
                    {
                        isgrounded = false;
                    }
                }
            }
        }

        if (isGravityFlipped == true)
        {
            RaycastHit hit;
            Ray Grounded = new Ray(transform.position, Vector3.up);
            if (!isgrounded)
            {
                if (Physics.Raycast(Grounded, out hit, rayLength))
                {
                    if (hit.collider)
                    {
                        isgrounded = true;
                    }
                    else
                    {
                        isgrounded = false;
                    }
                }
            }
        }

        //======================================================

        //====================Adds Force to ball================        

        if (isGravityFlipped == false)
        {
            Vector3 movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(MovementX, 0.0f, MovementY);
            rb.AddForce(movement * speed);
        }

        if (isGravityFlipped == true)
        {
            Vector3 movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(-MovementX, 0.0f, MovementY);
            rb.AddForce(movement * speed);
        }

        //======================================================

        //==================Gives Mass Gravity==================
        rb.AddForce(Physics.gravity * rb.mass);
        //======================================================

        //====================Jump button=======================
        if (isgrounded && Input.GetButton("Jump") && isGravityFlipped == false)
            {
                rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);               
                isgrounded = false;

            }

        if (isgrounded && Input.GetButton("Jump") && isGravityFlipped == true)
        {
            rb.AddForce(new Vector3(0, -jump, 0), ForceMode.Impulse);
            isgrounded = false;

        }
        //=====================================================

        //===================False Gravity===================== (Temp)
        if (gravityNorm == true)
        {
            rb.AddForce(0, falseGravityPos, 0);
        }
            else
        {
            rb.AddForce(0, falseGravityNag, 0);
        }
           //==================================================
    }

    private void OnCollisionEnter(Collision collision)
    {
        //=================Gravity Changer detect=============
        if (collision.gameObject.tag == ("upGravity"))
        {
            gravityNorm = false;
            isgrounded = false;
        }

        if (collision.gameObject.tag == ("downGravity"))
        {
            gravityNorm = true;
        }
        //======================================================
    }

    private void OnTriggerEnter(Collider other)
    {
        // ================Acid Detect=====================

        if (other.gameObject.CompareTag("Acid"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //==================================================
    }
}
