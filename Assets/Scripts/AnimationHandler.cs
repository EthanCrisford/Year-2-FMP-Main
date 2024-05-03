using FMP.ARPG;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] float attackRange = 1f;
    [SerializeField] float pickupRange = 1f;
    Animator animator;
    PlayerController characterMovement;
    InteractableObjects target;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<PlayerController>();
    }

    public void Pickup(InteractableObjects target)
    {
        this.target = target;
        ProcessAction();
    }

    internal void Attack(InteractableObjects target)
    {
        this.target = target;
        ProcessAction();
    }

    private void Update()
    {
        if (target != null)
        {
            ProcessAction();
        }
    }

    public void ProcessAction()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < attackRange)
        {
            characterMovement.Stop();
            animator.SetTrigger("Attack");
            target = null;
        }
        else
        {
            characterMovement.agent.SetDestination(target.transform.position);
        }

        if (distance < pickupRange)
        {
            characterMovement.Stop();
            animator.SetTrigger("Pickup");
            target = null;
        }
        else
        {
            characterMovement.agent.SetDestination(target.transform.position);
        }
    }
}
