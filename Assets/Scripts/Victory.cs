using UnityEngine;

public class Victory : MonoBehaviour
{
    public static int enemyCount = 0;

    public void Awake()
    {
        enemyCount++;
    }

    private void Die()
    {
        enemyCount--;
    }
}
