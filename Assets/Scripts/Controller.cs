using UnityEngine;


[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterAnimation))]
[RequireComponent(typeof(CharacterInput))]
public class Controller : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public CharacterAnimation characterAnimation;
    public CharacterInput characterInput;
    void Update()
    {
        characterMovement.MoveUpdate();
        characterAnimation.UpdateAnimation();
        characterInput.InputUpdate();
    }
}
