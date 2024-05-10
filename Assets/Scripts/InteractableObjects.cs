using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    [SerializeField] string postMessage;
    public string objectName;

    private void Start()
    {
        objectName = transform.name;
    }
}
