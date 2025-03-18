using UnityEngine;


public class LookAtIK : MonoBehaviour
{
    public Transform lookTarget; 
    private Animator animator;

    [Range(0f, 1f)] public float weight = 0.3f;
    [Range(0f, 1f)] public float bodyWeight = 0.3f;
    [Range(0f, 1f)] public float headWeight = 0.8f;
    [Range(0f, 1f)] public float eyesWeight = 1f;
    [Range(0f, 1f)] public float clampWeight = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (lookTarget != null)
        {
            animator.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
            animator.SetLookAtPosition(lookTarget.position);
        }
    }
}

