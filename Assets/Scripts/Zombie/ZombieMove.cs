using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ZombieMove : MonoBehaviour
{
    [SerializeField] private GameObject AmmoBox;
    [SerializeField] private string playerTag = "Player";
    //[SerializeField] private float speed = 0.5f;
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 20;
    
    private List<Rigidbody> GetRigidbodies = new List<Rigidbody>();
    private Animator animator;
    private AnimatorStateInfo animStateInfo;
    private GameObject Player;


    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag(playerTag);
    }

    void Update()
    {
        ZombieController();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("Attack", true);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Attack", false);
        }
    }

    void RigidbodyIsKineaticOn()
    {
        animator.enabled = true;
        for (int i = 0; i < GetRigidbodies.Count; i++)
        {
            GetRigidbodies[i].isKinematic = true;
        }
    }

    void RigidbodyIsKineaticOff()
    {
        animator.enabled = false;
        /*for (int i = 0; i < GetRigidbodies.Count; i++)
        {
            GetRigidbodies[i].isKinematic = false;
        }*/
    }

    void ZombieController()
    {
        //animator.speed = speed;
        //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        if(health > 0)
        {
            animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if(animStateInfo.IsName("Walking"))
            {
                transform.LookAt(Player.transform.position);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hit");
        if (health <= 0)
        {
            RigidbodyIsKineaticOff();
            GetComponent<Collider>().enabled = false;
            int rnd = Random.Range(0, 100);
            if(rnd <= 30)
            {
                Instantiate(AmmoBox, transform.position, Quaternion.identity);
            }
        }
    }
}
