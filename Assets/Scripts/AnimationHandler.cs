using FMP.ARPG;
using UnityEngine;
using UnityEngine.AI;

public class AnimationHandler : MonoBehaviour
{
    public enum PlayerStates
    {
        Attack,
        Pickup,
        GoToTargetAttack,
        GoToTargetPickup,
        Idle,
        Dead
    }

    Character character;

    [SerializeField] float attackRange;
    [SerializeField] float defaultTimeToAttack;
    float attackTimer;
    [SerializeField] float pickupRange;

    Animator animator;
    PlayerController characterMovement;
    public GameObject target;
    Character enemyTarget;
    InteractableObjects _target;

    InteractableObjects InteractableObject;
    public PlayerStates state;
    float distance;
    [SerializeField] NavMeshAgent agent;
    public bool isEnemy;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<PlayerController>();
        character = GetComponent<Character>();
        state = PlayerStates.Idle;
        attackTimer = 1;// GetAttackTime();
    }

    //this method should be called when E is pressed
    public void Pickup(InteractableObjects target)
    {
        this.InteractableObject = target;

        if(target.tag == "pickup")

            state = PlayerStates.GoToTargetPickup;
    }

    //this method should be called when the right mouse button is pressed
    public void Attack(Character target)
    {
        this.enemyTarget = target;

        if (target.tag == "enemy" || target.tag == "Player")
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
            animator.SetFloat("Move", agent.velocity.magnitude);
        }

        if (state == PlayerStates.Attack)
        {
            //print("attack state");
            AttackTimerTick();

            if (attackTimer > 0)
            {
                return;
            }

            attackTimer = GetAttackTime();
            if (!isEnemy)
            {
                characterMovement.Stop();
            }
            animator.SetTrigger("Attack");
            enemyTarget.TakeDamage(character.TakeStats(Stats.Damage).integer_value);
            
            state = PlayerStates.Idle;
        }

        if (state == PlayerStates.Pickup)
        {
            print("pick up state");
            animator.SetTrigger("Pickup");
            characterMovement.Stop();
            state = PlayerStates.Idle;
        }

        if(state == PlayerStates.GoToTargetAttack)
        {
            //print("going to target attack");
            if (isEnemy)
            {
                agent.SetDestination(target.transform.position);

                if (distance < attackRange && (target.gameObject.tag == "enemy" || target.gameObject.tag == "Player")  )
                {
                    state = PlayerStates.Attack;
                }
            }
            else
            {
                characterMovement.agent.SetDestination(target.transform.position);

                if (distance < attackRange && (target.gameObject.tag == "enemy" || target.gameObject.tag == "Player"))
                {
                    state = PlayerStates.Attack;
                }
            }
        }

        if (state == PlayerStates.GoToTargetPickup)
        {
            //print("going to target pickup");
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

    public void AssignTarget(GameObject _target)
    {
        target = _target;
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

        //print (attackTime);
        return attackTime;
    }
}
