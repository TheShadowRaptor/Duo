using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt2 : MonoBehaviour
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
        if (Input.GetKey("left"))
        {
            transform.Translate(-0.01f, 0, 0);
        }

        if (Input.GetKey("right"))
        {
            transform.Translate(0.01f, 0, 0);
        }
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.2300001f, 78f), 13.5f, 1.3f);
    }
}
