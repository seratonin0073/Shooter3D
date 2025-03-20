using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator anim;
    public Transform camTransform;
    public CharacterStatus status;
    public float rotationSpeed;

    private float moveAmount;
    private float vertical;
    private float horizontal;
    
    private Vector3 rotationDirection;
    private Vector3 moveDirection;

    public float MoveAmount
    {
        get { return moveAmount; }
    }
    public float Vertical
    {
        get { return vertical; }
    }
    public float Horizontal
    {
        get { return horizontal; }
    }


    public void MoveUpdate()
    { 
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal"); 
        moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));

        Vector3 moveDir = camTransform.forward * vertical;
        moveDir += camTransform.right * horizontal;
        moveDir.Normalize();
        moveDirection = moveDir;
        rotationDirection = camTransform.forward;

        RotationNormal();
        status.isGround = Ground();
    }

    public void RotationNormal()
    {
        if(!status.isAniming)
        {
            rotationDirection = moveDirection;
        }

        Vector3 targetDir = rotationDirection;
        if(targetDir == Vector3.zero) targetDir = transform.forward;

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, rotationSpeed);
        transform.rotation = targetRot;
    }

    public bool Ground()
    {
        Vector3 origin = transform.position;
        origin.y += 0.6f;
        Vector3 dir = -Vector3.up;
        float dist = 0.7f;
        RaycastHit hit;
        if (Physics.Raycast(origin, dir, out hit, dist))
        {
            Vector3 tp = hit.point;
            transform.position = tp;
            return true;
        }
        return false;
    }

}
