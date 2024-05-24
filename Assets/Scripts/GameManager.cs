using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool areAllEnemiesDead = Victory.enemyCount == 0;
   
    void Update()
    {
        if (areAllEnemiesDead)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
