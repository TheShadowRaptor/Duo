using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSingle : MonoBehaviour
{
    public GameObject AnimatedObject;
    public GameObject Button;
    public GameObject bridge;

    public bool isDoorOpen;
    public bool Pressed;

    private Animator blueButton;
    private Animator _animator;
    


    // Start is called before the first frame update
    void Start()
    {
        _animator = AnimatedObject.GetComponent<Animator>();
        blueButton = Button.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("IsDoorOpen", isDoorOpen);
        blueButton.SetBool("Pressed", Pressed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("NormalBlock") || collision.gameObject.tag == ("smallBox") || collision.gameObject.tag == ("Player"))
        {
            isDoorOpen = true;
            Pressed = true;
            bridge.SetActive(true);
        }
    }
}