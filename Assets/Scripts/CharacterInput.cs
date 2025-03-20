using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public CharacterStatus status;

    private bool debugAiming;
    private bool isAiming;

    public void InputUpdate()
    {
        if(!debugAiming)
            status.isAniming = Input.GetMouseButton(1); 
        else 
            status.isAniming = isAiming;
    }
}
