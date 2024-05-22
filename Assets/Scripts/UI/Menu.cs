using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        how2playPanel.SetActive(!how2playPanel.activeInHierarchy);
        how2playPanel.SetActive(true);
    }
}
