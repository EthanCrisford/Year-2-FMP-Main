using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject how2playPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Spawn");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HowToPlayButton()
    {
        how2playPanel.SetActive(true);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
