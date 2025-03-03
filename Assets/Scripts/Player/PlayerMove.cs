using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        transform.Translate(x,0,z);
    }
}
