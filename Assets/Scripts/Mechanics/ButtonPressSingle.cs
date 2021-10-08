using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSingle : MonoBehaviour
{
    public GameObject trigger;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("NormalBlock") || collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("smallBox"))
        {
            trigger.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
