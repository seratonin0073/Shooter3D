using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator anim;
    public CharacterMovement characterMovement;
    public CharacterStatus status;

    public void UpdateAnimation()
    {

        anim.SetBool("Sprint", status.isSprint);
        anim.SetBool("Aiming", status.isAniming);
        if (!status.isAniming) AnimationNormal();
        else AnimationAiming();
    }

    void AnimationNormal()
    {
        anim.SetFloat("Vertical", characterMovement.MoveAmount, 0.15f, Time.deltaTime);
    }

    void AnimationAiming()
    {
        float v = characterMovement.Vertical;
        float h = characterMovement.Horizontal;

        anim.SetFloat("Vertical", v, 0.15f, Time.deltaTime);
        anim.SetFloat("Horizontal", h, 0.15f, Time.deltaTime);

    }
}
