using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Pickup(InteractableObjects hoveringOverObject)
    {
        animator.SetTrigger("Pickup");
    }

    public void Attack(InteractableObjects hoveringOverObject)
    {
        animator.SetTrigger("Attack");
    }
}
