using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraRotation : MonoBehaviour
{

    private Rigidbody rb;
    public float rotationSpeed = 100.0f;
    
    private Vector3 rotateValue;

    private float lockPos = 0;
    private float rotateY = 0.0f;
    private float rotateX = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rotateY = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        rotateX = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Rotate(-rotateY, rotateX, 0);
     

        rotateX = Mathf.Clamp(rotateX + Input.GetAxis("Horizontal"), -20f, 75f);
        rotateY = Mathf.Clamp(rotateY + Input.GetAxis("Vertical"), -30f, 30f);

       
    }
}
