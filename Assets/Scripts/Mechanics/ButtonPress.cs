using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject AnimatedObject;
    public bool isDoorOpen;
    public Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = AnimatedObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("IsDoorOpen", isDoorOpen);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("NormalBlock") || collision.gameObject.tag == ("smallBox") || collision.gameObject.tag == ("Player"))
        {
            isDoorOpen = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isDoorOpen = false;   
    }
}
