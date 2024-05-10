using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    public AnimationHandler animationHandler;

    [HideInInspector]
    public InteractableObjects hoveringOverObject;

    void Update()
    {
        CheckInteractObject();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hoveringOverObject != null)
            {
                hoveringOverObject.Interact();
                animationHandler.Pickup(hoveringOverObject);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (hoveringOverObject != null)
            {
                hoveringOverObject.Interact();
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
            InteractableObjects interactableObject = hit.transform.GetComponent<InteractableObjects>();
            if (interactableObject != null)
            {
                hoveringOverObject = interactableObject;
                textOnScreen.text = hoveringOverObject.objectName;
            }
            else
            {
                hoveringOverObject = null;
                textOnScreen.text = "";
            }
        }
    }
}
