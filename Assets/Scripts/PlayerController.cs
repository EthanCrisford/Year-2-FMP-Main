using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

namespace FMP.ARPG
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputAction movement = new InputAction();
        [SerializeField] private LayerMask layerMask = new LayerMask();

        public Collider player;

        private NavMeshAgent agent = null;
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

            animator.SetFloat("Move", agent.velocity.magnitude);
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

        private void PlayerMove(Vector3 location)
        {
            agent.SetDestination(location);
        }

        public void OnTriggerEnter(Collider player)
        {
            if (player.gameObject.tag == "Portal")
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
