using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                InteractableObjects interactableObject = hit.transform.GetComponent<InteractableObjects>();
                if (interactableObject != null)
                {
                    interactableObject.Interact();
                }
            }
        }
    }
}
