using FMP.ARPG;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public enum PlayerStates
    {
        Attack,
        Pickup,
        GoToTargetInteract,
        Idle
    }

    Character character;
    [SerializeField] float attackRange;
    [SerializeField] float pickupRange;
    Animator animator;
    PlayerController characterMovement;
    public GameObject target;
    InteractableObjects InteractableObjects;
    public PlayerStates state;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<PlayerController>();
        character = GetComponent<Character>();
        state = PlayerStates.Idle;
    }

    //this method should be called when E is pressed
    public void Pickup(InteractableObjects target)
    {
        this.InteractableObjects = target;

        state = PlayerStates.GoToTargetInteract;
    }

    //this method should be called when the right mouse button is pressed
    public void Attack(InteractableObjects target)
    {
        this.InteractableObjects = target;

        state = PlayerStates.GoToTargetInteract;
    }

    private void Update()
    {
        if(state == PlayerStates.Idle)
        {
            print(" Idle state");
        }

        if (state == PlayerStates.Attack)
        {
            print("attack state");
            animator.SetTrigger("Attack");
            characterMovement.Stop();
            Character targetCharacterToAttack = target.GetComponent<Character>();
            targetCharacterToAttack.TakeDamage(character.TakeStats(Stats.Damage).value);
            state = PlayerStates.Idle;
        }

        if (state == PlayerStates.Pickup)
        {
            print("pick up state");
            animator.SetTrigger("Pickup");
            characterMovement.Stop();
            state = PlayerStates.Idle;
        }

        if( state == PlayerStates.GoToTargetInteract)
        {
            print("going to target");
            characterMovement.agent.SetDestination(target.transform.position);

            /*float distance = Vector3.Distance(transform.position, target.transform.position);*/

            float distanceX = characterMovement.transform.position.x - target.transform.position.x;
            float distanceY = characterMovement.transform.position.y - target.transform.position.y;
            float distanceZ = characterMovement.transform.position.z - target.transform.position.z;

            float totalDis = distanceX * distanceY * distanceZ;
            //print(totalDis);

            if (totalDis < attackRange && target.gameObject.tag == "enemy")
            {
                state = PlayerStates.Attack;
            }
            else
            {
                state = PlayerStates.Idle;
            }

            if (totalDis < pickupRange && target.gameObject.tag == "pickup")
            {
                state = PlayerStates.Pickup;
            }
            else
            {
                state = PlayerStates.Idle;
            }
        }
    }

    public void AssignTarget(GameObject targett)
    {
        target = targett;
    }
}
