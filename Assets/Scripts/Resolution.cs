using UnityEngine;

public class Resolution : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(640, 480, true);
    }
}
