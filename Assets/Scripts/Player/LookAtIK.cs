using UnityEngine;

using UnityEngine;

public class LookAtIK : MonoBehaviour
{
    public Transform lookTarget; // Точка прицілу (наприклад, об'єкт під курсором)
    private Animator animator;

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
        Debug.Log("IK called on layer " + layerIndex);
        if (lookTarget != null)
        {
            animator.SetLookAtWeight(1.0f, bodyWeight, headWeight, eyesWeight, clampWeight);
            animator.SetLookAtPosition(lookTarget.position);
        }
    }
}

