using UnityEngine;

public class AK74 : MonoBehaviour
{
    [SerializeField] private float rayLenght = 50f;

    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayLenght))
        {
            Debug.Log("Shoot");
            if (hit.collider.gameObject.tag == "Mark") Debug.Log("Mark");
        }
        
    }
}
