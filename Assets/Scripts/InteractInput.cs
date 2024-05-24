using FMP.ARPG;
using System;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    [SerializeField] UIBar hpBar;

    public AnimationHandler animationHandler;
    public InteractInput interactInput;

    GameObject currentHoverOverObject;
    [HideInInspector]
    public InteractableObjects hoveringOverObject;
    public GameObject player;
    [HideInInspector]
    public Character hoveringOverCharacter;

    InteractableObjects InteractedObject;
    [SerializeField] float interactRange = 0.5f;

    public Character character;
    public AnimationHandler playerMovement;
    public PlayerController playerController;

    public LayerMask hoverMask;

    private void Awake()
    {
        interactInput = GetComponent<InteractInput>();
        animationHandler = GetComponent<AnimationHandler>();
        character = GetComponent<Character>();
        playerMovement = GetComponent<AnimationHandler>();
    }

    public void Update()
    {
        CheckInteractObject();

        if (InteractedObject != null)
        {
            ProcessInteract();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactInput.hoveringOverObject != null)
            {
                animationHandler.Pickup(hoveringOverObject);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (interactInput.hoveringOverCharacter != null)
            {
                //transform.LookAt(hoveringOverCharacter.transform);
                animationHandler.Attack(hoveringOverCharacter);
            }
        }
    }

    internal void Interact()
    {
        InteractedObject = hoveringOverObject;

        //hoveringOverObject.Interact();
    }

    private void ProcessInteract()
    {
        float distance = Vector3.Distance(transform.position, InteractedObject.transform.position);

        if (distance < interactRange)
        {
            //hoveringOverObject.Interact();
            //playerMovement.Stop();

            //InteractedObject = null;    
        }
        else
        {
            //playerMovement.SetDestination(InteractedObject.transform.position);
        }
    }

    public Camera myCamera;

    private void CheckInteractObject()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay( ray.origin, ray.direction, Color.yellow );   

        if (Physics.Raycast(ray, out hit, 1000000))
        {
            //print("cho=" + currentHoverOverObject);
            //print("mouse hover=" + hit.transform.gameObject.name);
            if (currentHoverOverObject != hit.transform.gameObject)
            {
                
                currentHoverOverObject = hit.transform.gameObject;
                UpdateInteractableObject(hit);
            }
        }
    }

    private void UpdateInteractableObject(RaycastHit hit)
    {
        InteractableObjects interactableObject = hit.transform.GetComponent<InteractableObjects>();
        if (interactableObject != null)
        {
            animationHandler.AssignTarget(hit.collider.gameObject);
            hoveringOverObject = interactableObject;
            hoveringOverCharacter = interactableObject.GetComponent<Character>();
            textOnScreen.text = hoveringOverObject.objectName;
            //player.GetComponent<InteractableObjects>();
        }
        else
        {
            hoveringOverCharacter = null;
            hoveringOverObject = null;
            textOnScreen.text = "";
        }
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        if (hoveringOverCharacter != null)
        {
            hpBar.Show(hoveringOverCharacter.lifePool);
        }
        else
        {
            hpBar.Clear();
        }
    }
}
