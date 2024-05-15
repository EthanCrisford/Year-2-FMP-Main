using System;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    [SerializeField] UIBar hpBar;

    public AnimationHandler animationHandler;

    GameObject currentHoverOverObject;

    [HideInInspector]
    public InteractableObjects hoveringOverObject;
    public GameObject player;
    Character hoveringOverCharcter;

    public void Update()
    {
        CheckInteractObject();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hoveringOverObject != null)
            {
                animationHandler.Pickup(hoveringOverObject);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (hoveringOverObject != null)
            {
                animationHandler.Attack(hoveringOverObject);
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
            hoveringOverCharcter = interactableObject.GetComponent<Character>();
            textOnScreen.text = hoveringOverObject.objectName;
            //player.GetComponent<InteractableObjects>();
        }
        else
        {
            hoveringOverCharcter = null;
            hoveringOverObject = null;
            textOnScreen.text = "";
        }
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        if (hoveringOverCharcter != null)
        {
            hpBar.Show(hoveringOverCharcter.lifePool);
        }
        else
        {
            hpBar.Clear();
        }
    }
}
