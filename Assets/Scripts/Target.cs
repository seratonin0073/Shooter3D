using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
