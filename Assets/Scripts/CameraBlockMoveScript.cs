using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlockMoveScript : MonoBehaviour
{
    public GameObject cameraBlock;
    public float turningSpeed = 0;

    private float rotatex;
    private float yRotate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rotatex = cameraBlock.transform.eulerAngles.x;
        yRotate = cameraBlock.transform.eulerAngles.y;

        if (yRotate <= 60f || yRotate >= 280)
        {
            if (Input.GetKey("right"))
            {
                yRotate += turningSpeed;
            }

            if (Input.GetKey("left"))
            {
                yRotate += -turningSpeed;
            }
        }

        else if (yRotate > 60f && yRotate < 140f)
        {
            yRotate = 59.9f;
        }

        else if (yRotate < 280f && yRotate > 140f)
        {
            yRotate = 280.1f;
        }

        if (rotatex <= 70f || rotatex >= 360)
        {
            if (Input.GetKey("up"))
            {
                rotatex += -turningSpeed;
            }

            if (Input.GetKey("down"))
            {
                rotatex += turningSpeed;
            }
        }

        else if (rotatex > 70f && rotatex < 180f)
        {
            rotatex = 69.9f;
        }

        else if (rotatex < 360f && rotatex > 180f)
        {
            rotatex = 360.1f;
        }

        cameraBlock.transform.rotation = Quaternion.Euler(rotatex, yRotate, 0f);
    }
}
