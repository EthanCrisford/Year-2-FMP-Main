using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    [SerializeField] string postMessage;
    public string objectName;

    private void Start()
    {
        objectName = transform.name;
    }

    public void Interact()
    {
        Debug.Log(postMessage);
    }
}
