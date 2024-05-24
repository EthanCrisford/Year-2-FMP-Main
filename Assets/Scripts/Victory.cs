using UnityEngine;

public class Victory : MonoBehaviour
{
    public static int enemyCount = 0;

    public void Awake()
    {
        enemyCount++;
    }

    public void Update()
    {
        print(enemyCount);
    }

    public void Die()
    {
        enemyCount--;
    }
}
