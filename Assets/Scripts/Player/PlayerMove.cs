using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Animator animator;
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        transform.Translate(x,0,z);
        animator = GetComponent<Animator>();
        AnimController(x, z);

    }

    void AnimController(float x, float z)
    {
        if(z > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            { 
                animator.SetInteger("Move", 2);
            }
            else animator.SetInteger("Move", 1);
        }
        else if(z < 0)
        {
            animator.SetInteger("Move", -1);
        }
        else
        {
            animator.SetInteger("Move", 0);
        }
    }
}
