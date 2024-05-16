using FMP.ARPG;
using System;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public enum PlayerStates
    {
        Attack,
        Pickup,
        GoToTargetAttack,
        GoToTargetPickup,
        Idle
    }

    Character character;
    [SerializeField] float attackRange;
    [SerializeField] float defaultTimeToAttack;
    float attackTimer;
    [SerializeField] float pickupRange;
    Animator animator;
    PlayerController characterMovement;
    public GameObject target;
    InteractableObjects InteractableObjects;
    public PlayerStates state;
    float distance;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<PlayerController>();
        character = GetComponent<Character>();
        state = PlayerStates.Idle;
        attackTimer = 1;// GetAttackTime();
    }

    private void Start()
    {

    }

    //this method should be called when E is pressed
    public void Pickup(InteractableObjects target)
    {
        this.InteractableObjects = target;

        if(target.tag == "pickup")
            state = PlayerStates.GoToTargetPickup;
    }

    //this method should be called when the right mouse button is pressed
    public void Attack(InteractableObjects target)
    {
        this.InteractableObjects = target;

        if (target.tag == "enemy")
        {
            state = PlayerStates.GoToTargetAttack;
        }
    }

    private void Update()
    {
        if (target != null)
        {
            distance = Vector3.Distance(transform.position, target.transform.position);
        }
        else
        {
            distance = 0;
        }

        if (state == PlayerStates.Idle)
        {
            //print(" Idle state");
        }

        if (state == PlayerStates.Attack)
        {
            print("attack state");
            AttackTimerTick();

            if (attackTimer > 0)
            {
                return;
            }

            attackTimer = GetAttackTime();
            characterMovement.Stop();
            animator.SetTrigger("Attack");
            Character targetCharacterToAttack = target.GetComponent<Character>();
            targetCharacterToAttack.TakeDamage(character.TakeStats(Stats.Damage).integer_value);
            
            state = PlayerStates.Idle;
        }

        if (state == PlayerStates.Pickup)
        {
            print("pick up state");
            animator.SetTrigger("Pickup");
            characterMovement.Stop();
            state = PlayerStates.Idle;
        }

        if( state == PlayerStates.GoToTargetAttack)
        {
            print("going to target attack");
            characterMovement.agent.SetDestination(target.transform.position);

            if (distance < attackRange && target.gameObject.tag == "enemy")
            {
                state = PlayerStates.Attack;
            }
        }

        if (state == PlayerStates.GoToTargetPickup)
        {
            print("going to target pickup");
            characterMovement.agent.SetDestination(target.transform.position);
            
            if ((distance < pickupRange) && (target.gameObject.tag == "pickup"))
            {
                state = PlayerStates.Pickup;
            }
        }
    }

    private void AttackTimerTick()
    {
        if (attackTimer > 0f)
        {
            //print(attackTimer);
            attackTimer -= Time.deltaTime;
        }
    }

    public void AssignTarget(GameObject targett)
    {
        target = targett;
    }

    private void OnGUI()
    {
        string text = "";

        text = "\nstate=" + state;
        text += "\ndistance=" + distance;
        //text += "\ntarget=" + target.transform.position;

        GUI.Label(new Rect(10, 10, 1500, 900), text);
    }
    private float GetAttackTime()
    {
        float attackTime = defaultTimeToAttack;

        attackTime /= character.TakeStats(Stats.AttackSpeed).integer_value;
        //attackTime /= 1;

        print (attackTime);
        return attackTime;
    }
}
