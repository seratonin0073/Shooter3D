using UnityEngine;

public class AK74 : MonoBehaviour
{
    [SerializeField] private float rayLenght = 50f;
    [SerializeField] private float damage = 10f;
    [SerializeField] float fireRate = 0.2f;

    [SerializeField] ParticleSystem shootEffect;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioSource shootAudio;

    [SerializeField] LayerMask ignoreLayer;


    private float nextTimeToShoot = 0f;

    
    
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToShoot)
        {
            Shoot();
            nextTimeToShoot = Time.time + fireRate;
        }

    }

    void Shoot()
    {
        shootAudio.Play();
        shootEffect.Play();
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayLenght, ~ignoreLayer))
        {
            
            if (hit.collider.gameObject.tag == "Mark") hit.collider.GetComponent<Target>().TakeDamage(damage);
            Debug.Log("Hit: " + hit.collider.gameObject.name);
            GameObject particle = Instantiate(hitEffect.gameObject, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(particle, 0.5f);
        }

    }
}
