using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace FMP.ARPG
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputAction movement = new InputAction();
        [SerializeField] private LayerMask layerMask = new LayerMask();
        public Collider player;
        [SerializeField] public NavMeshAgent agent = null;
        private Camera cam = null;
        public Animator animator;
        Character character;
        [SerializeField] int default_MoveSpeed = 3;
        //StatsValue moveSpeed;
        //int current_MoveSpeed;

        private void Awake()
        {
            player = GetComponent<Collider>();
            cam = Camera.main;
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<Character>();
        }

        private void Start()
        {
            //moveSpeed = character.TakeStats(Stats.MoveSpeed);
            //UpdateMoveSpeed();
        }

        /*
        private void UpdateMoveSpeed()
        {
            agent.speed = default_MoveSpeed * moveSpeed.integer_value;
        }*/

        private void Update()
        {
            HandleInput();

            /*(if (current_MoveSpeed != moveSpeed.integer_value)
            {
                current_MoveSpeed = moveSpeed.integer_value;
                UpdateMoveSpeed();
            }*/
        }
            private void OnEnable()
        {
            movement.Enable();
        }

        private void OnDisable()
        {
            movement.Disable();
        }

        private void HandleInput()
        {
            if (movement.ReadValue<float>() == 1)
            {
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, layerMask))
                {
                    PlayerMove(hit.point);
                }
            }
        }

        public void PlayerMove(Vector3 location)
        {
            agent.isStopped = false;
            agent.SetDestination(location);
        }

        public void OnTriggerEnter(Collider player)
        {
            if (player.gameObject.tag == "Portal") 
            {
                SceneManager.LoadScene(2);
            }
        }

        internal void Stop()
        {
            agent.isStopped = true;
        }
    }
}
