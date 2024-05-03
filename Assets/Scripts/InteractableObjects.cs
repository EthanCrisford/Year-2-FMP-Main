using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    [SerializeField] string postMessage;

    public void Interact()
    {
        Debug.Log(postMessage);
    }
}
