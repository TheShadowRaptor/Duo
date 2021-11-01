using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSingle : MonoBehaviour
{
    public GameObject trigger;

    public GameObject AnimatedObject;

    private Animator _animator;
    // Start is called before the first frame update

    private void Start()
    {
        _animator = AnimatedObject.GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("NormalBlock") || collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("smallBox"))
        {
            trigger.SetActive(true);

            _animator.enabled = true;
        }
    }

    // Update is called once per frame

}
