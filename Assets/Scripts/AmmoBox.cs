using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private float magnitude = 0.1f;
    [SerializeField] private float duration = 1;

    [Header("Properties")]
    [SerializeField] private int ammo = 30;

    Vector3 upPos;
    Vector3 downPos;
    void Start()
    {
        upPos = transform.position + Vector3.up * magnitude;  
        downPos = transform.position + Vector3.up * -magnitude;
        StartCoroutine(Fluctuation());
    }

    
    IEnumerator Fluctuation()
    {
        transform.DOMove(upPos, duration);
        yield return new WaitForSeconds(duration);
        transform.DOMove(downPos, duration);
        yield return new WaitForSeconds(duration);
        StartCoroutine(Fluctuation());
    }

    

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
           collision.gameObject.GetComponentInChildren<AK74>().ExtraAmmo = 30; 
           Destroy(this.gameObject);
        }
    }
}
