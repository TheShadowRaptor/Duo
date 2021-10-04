using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 0;
    public float jump = 0;
    public float rayLength;
    public float falseGravityPos = 0;
    public float falseGravityNag = 0;


    private Rigidbody rb;

    public bool isgrounded;

    private float MovementX;
    private float MovementY;
    public bool stop = true;
    public bool gravityNorm = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();     
    }

    void Update()
    {
        if(rb.velocity.magnitude > jump)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, jump);
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        MovementX = movementVector.x;
        MovementY = movementVector.y;

    }

    // Update is called once per frame
    private void FixedUpdate()
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
        Vector3 movement = new Vector3(MovementX, 0.0f, MovementY);

        rb.AddForce(movement * speed);
        rb.AddForce(Physics.gravity * rb.mass);
        
        

            if (isgrounded && Input.GetButton("Jump"))
            {
                rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);               
                isgrounded = false;

            }         
            
            if (gravityNorm == true)
        {
            rb.AddForce(0, falseGravityPos, 0);
        }
            else
        {
            rb.AddForce(0, falseGravityNag, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("upGravity"))
        {
            gravityNorm = false;
            isgrounded = false;
        }

        if (collision.gameObject.tag == ("downGravity"))
        {
            gravityNorm = true;
        }
    }
}
