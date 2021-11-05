using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject door;
    public GameObject doorAnimate;
    public GameObject AnimatedObject;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = AnimatedObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("NormalBlock") || collision.gameObject.tag == ("smallBox") || collision.gameObject.tag == ("Player"))
        {
            door.SetActive(false);
            doorAnimate.SetActive(true);
            _animator.enabled = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        door.SetActive(true);
        doorAnimate.SetActive(false);
   
    }
}
