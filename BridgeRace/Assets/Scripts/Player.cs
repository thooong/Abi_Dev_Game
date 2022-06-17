using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] public FixedJoystick joystick;
    [SerializeField] public Animator playerAnimator;
    [SerializeField] private float moveSpeed;
    private int animState;
    // Start is called before the first frame update
    void Start()
    {
   
    }

  
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(joystick.Horizontal * moveSpeed, _rigidbody.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
         
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            if (animState != 3)
            {
                animState = 1;
                playerAnimator.SetInteger("Actions", animState);
            }
           

        }
        else
        {
            if (animState != 3)
            {
                animState = 0;
                playerAnimator.SetInteger("Actions", animState);
            }
        }
    }
}
