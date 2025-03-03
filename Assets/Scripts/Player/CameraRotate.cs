using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    Vector2 turn; 

    [SerializeField] private float mosueSens = 0.5f;//mouse sens
    [SerializeField] private float maxVertialView = 40f;
    [SerializeField] private float mixVertialView = -40f;

    [SerializeField] private GameObject player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        
        turn.x += Input.GetAxis("Mouse X") * mosueSens;
        turn.y += Input.GetAxis("Mouse Y") * mosueSens;
        turn.y = Mathf.Clamp(turn.y, mixVertialView, maxVertialView);
;
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, turn.x, 0);

    }
}
