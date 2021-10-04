using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject WinText;

    private void Start()
    {
        WinText.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            WinText.SetActive(true);
        }
    }
}
