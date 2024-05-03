using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;

    InteractableObjects hoveringOverObject;

    void Update()
    {
        CheckInteractObject();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hoveringOverObject != null)
            {
                hoveringOverObject.Interact();
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
