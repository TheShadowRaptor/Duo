using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("NormalBlock") || collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("smallBox"))
        {
            door.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        door.SetActive(true);
    }
}
