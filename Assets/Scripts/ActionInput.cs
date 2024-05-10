using UnityEngine;

public class ActionInput : MonoBehaviour
{
    InteractInput interactInput;
    AnimationHandler animationHandler;

    private void Awake()
    {
        interactInput = GetComponent<InteractInput>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Picking up");
            animationHandler.Pickup(interactInput.hoveringOverObject);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Attacking");
            animationHandler.Attack(interactInput.hoveringOverObject);
        }
    }
}
