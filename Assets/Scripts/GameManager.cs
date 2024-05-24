using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool areAllEnemiesDead;

    private void Start()
    {
        areAllEnemiesDead = false;
    }

    void Update()
    {
        if (areAllEnemiesDead)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
