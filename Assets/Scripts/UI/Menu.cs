using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject how2playPanel;
    private bool h2pOpen;

    private void Start()
    {
        h2pOpen = false;
    }

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
        h2pOpen = !h2pOpen;

        if (h2pOpen)
        {
            how2playPanel.SetActive(true);
        }
        else
        {
            how2playPanel.SetActive(false);
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
