using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public bool isFlipped = false;

    public GameObject D103;
    public GameObject U20;

    public GameObject animatedObject;

    public Animator _animator;


    private void Start()
    {
        _animator = animatedObject.GetComponent<Animator>();
        
    }

    private void Update()
    {
        _animator.SetBool("isFlipped", isFlipped);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            
            Physics.gravity = new Vector3(0f, 9.807f, 0f);
            
            isFlipped = true;
            D103.GetComponent<D103Universal>().isGravityFlipped = true;
            D103.GetComponent<D103Universal>().oneTime = true;
            U20.GetComponent<PlayerController>().isGravityFlipped = true;
        }                        
    }
}
