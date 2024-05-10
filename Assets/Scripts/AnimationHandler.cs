using FMP.ARPG;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public enum PlayerStates
    {
        Attack,
        Pickup,
        GoToTargetAttack,
        Idle
    }

    Character character;
    [SerializeField] float attackRange;
    [SerializeField] float pickupRange;
    Animator animator;
    PlayerController characterMovement;
    InteractableObjects target;
    public PlayerStates state;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<PlayerController>();
        character = GetComponent<Character>();
        state = PlayerStates.Idle;
    }

    public void Pickup(InteractableObjects target)
    {
        this.target = target;
        ProcessAction();
    }

    //this method is called when the right mouse button is pressed
    internal void Attack(InteractableObjects target)
    {
        this.target = target;
        //ProcessAction();

        state = PlayerStates.GoToTargetAttack;
    }

    private void Update()
    {
        if( state == PlayerStates.Idle )
        {
            //CheckForAttack();
        }

        if (state == PlayerStates.Attack)
        {

        }

        if (state == PlayerStates.Pickup)
        {

        }

        if( state == PlayerStates.GoToTargetAttack )
        {
            characterMovement.agent.SetDestination(target.transform.position);

            //check for player reaching target
            float distance = Vector3.Distance(transform.position, target.transform.position);

            print("attack range=" + attackRange + "  distance=" + distance);


            if (distance < attackRange)
            {
                //player has reached target
                state = PlayerStates.Attack;
                animator.SetTrigger("Attack");
                characterMovement.Stop();
                Character targetCharacterToAttack = target.GetComponent<Character>();
                targetCharacterToAttack.TakeDamage(character.TakeStats(Stats.Damage).value);
            }
        }
    }

    public void ProcessAction()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        print("attack range=" + attackRange + "  distance=" + distance);

        if (distance < attackRange)
        {
            print("do attack");
            characterMovement.Stop();
            animator.SetTrigger("Attack");

            Character targetCharacterToAttack = target.GetComponent<Character>();

            targetCharacterToAttack.TakeDamage(character.TakeStats(Stats.Damage).value);

            //target = null;
        }
        else
        {
            characterMovement.agent.SetDestination(target.transform.position);
        }

        if (distance < pickupRange)
        {
            characterMovement.Stop();
            animator.SetTrigger("Pickup");
            //target = null;
        }
        else
        {
            characterMovement.agent.SetDestination(target.transform.position);
        }
    }
}
