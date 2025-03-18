using System;
using System.Collections;
using UnityEngine;

public class AK74 : MonoBehaviour
{
    [SerializeField] private float rayLenght = 50f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private float reloadTime = 2f;

    [SerializeField] ParticleSystem shootEffect;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioSource shootAudio;

    [SerializeField] LayerMask ignoreLayer;


    private float nextTimeToShoot = 0f;
    private int currentAmmo;
    private bool isReloading = false;
    private int extraAmmo = 0;

    public int ExtraAmmo
    {
        set { extraAmmo += value; }
    }


    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading) return;
        if ((currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo) && extraAmmo > 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToShoot)
        {
            Shoot();
            nextTimeToShoot = Time.time + fireRate;
        }

    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        extraAmmo -= maxAmmo;
        if(extraAmmo < 0) currentAmmo -= extraAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        currentAmmo--;
        shootAudio.Play();
        shootEffect.Play();
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayLenght, ~ignoreLayer))
        {
            ZombieMove zombie;
            if (hit.collider.gameObject.tag == "Mark") hit.collider.GetComponent<Target>().TakeDamage(damage); 
            if(hit.collider.TryGetComponent<ZombieMove>(out zombie)) zombie.TakeDamage(damage);

            GameObject particle = Instantiate(hitEffect.gameObject, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(particle, 0.5f);
        }

    }
}
