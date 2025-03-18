using System.Collections;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    [SerializeField] private float period = 4f;
    [SerializeField] private GameObject[] Zombies;
    void Start()
    {
        StartCoroutine(WaitTimeForSpawn());
    }

    IEnumerator WaitTimeForSpawn()
    {
        
        yield return new WaitForSeconds(period);
        Instantiate(Zombies[0], transform.position, Quaternion.identity);
        StartCoroutine(WaitTimeForSpawn());
    }
}
