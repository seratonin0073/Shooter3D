using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Slider hpBar;
    [SerializeField] private int health = 100;

    private void Start()
    {
        hpBar = GameObject.Find("HPBar").GetComponent<Slider>();
        hpBar.maxValue = health;
    }
    void Update()
    {
        hpBar.value = health;
        Death();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void Death()
    {

        if (health < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
