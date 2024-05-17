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

        private void Start()
        {
            player = GetComponent<Collider>();
            cam = Camera.main;
            agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            movement.Enable();
        }

        private void OnDisable()
        {
            movement.Disable();
        }

        private void Update()
        {
            HandleInput();

            
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
                SceneManager.LoadScene(1);
            }
        }

        internal void Stop()
        {
            agent.isStopped = true;
        }
    }
}
