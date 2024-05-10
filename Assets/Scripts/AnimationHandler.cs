using FMP.ARPG;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Character character;
    [SerializeField] float attackRange;
    [SerializeField] float pickupRange;
    Animator animator;
    PlayerController characterMovement;
    InteractableObjects target;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<PlayerController>();
        character = GetComponent<Character>();
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

            Character targetCharacterToAttack = target.GetComponent<Character>();

            targetCharacterToAttack.TakeDamage(character.TakeStats(Stats.Damage).value); 

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
