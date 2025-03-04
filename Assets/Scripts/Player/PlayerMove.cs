using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float sprintSpeed = 4f;
    [SerializeField] private float backwardSpeed = 1f;
    private float currentSpeed;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentSpeed = speed;
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * currentSpeed * Time.fixedDeltaTime;
        float z = Input.GetAxis("Vertical") * currentSpeed * Time.fixedDeltaTime;
        transform.Translate(x,0,z);
        
        AnimController(x, z);

    }

    void AnimController(float x, float z)
    {
        if(z > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetInteger("Move", 2);
                currentSpeed = sprintSpeed;
            }
            else
            {
                animator.SetInteger("Move", 1);
                currentSpeed = speed;
            }
            
        }
        else if(z < 0)
        {
            animator.SetInteger("Move", -1);
            currentSpeed = backwardSpeed;
        }
        else
        {
            animator.SetInteger("Move", 0);
        }
    }
}
