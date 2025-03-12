using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float speed = 0.5f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Attack", false);
        }
    }

    void ZombieController()
    {
        transform.LookAt(Player.transform.position);
        animator.speed = speed;
        //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
}
