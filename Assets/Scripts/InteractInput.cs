using System;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    [SerializeField] UIBar hpBar;

    public AnimationHandler animationHandler;
    InteractInput interactInput;

    GameObject currentHoverOverObject;

    [HideInInspector]
    public InteractableObjects hoveringOverObject;
    public GameObject player;
    [HideInInspector]
    public Character hoveringOverCharacter;

    private void Awake()
    {
        interactInput = GetComponent<InteractInput>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    public void Update()
    {
        CheckInteractObject();

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
                animationHandler.Attack(hoveringOverCharacter);
            }
        }
    }

    private void CheckInteractObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
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
