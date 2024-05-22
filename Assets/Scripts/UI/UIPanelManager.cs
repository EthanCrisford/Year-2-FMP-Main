using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject statsPanel;
    [SerializeField] GameObject questPanel;
    [SerializeField] GameObject quitToMenu;

    private bool menuOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenInventory();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenQuest();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            OpenStats();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
            menuOpen = true;
        }

        if (menuOpen == true && Input.GetKeyUp(KeyCode.Escape))
        {
            CloseMenu();
            menuOpen = false;
        }
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
    }

    public void OpenStats()
    {
        statsPanel.SetActive(!statsPanel.activeInHierarchy);
        questPanel.SetActive(false);
    }

    public void OpenQuest()
    {
        questPanel.SetActive(!questPanel.activeInHierarchy);
        statsPanel.SetActive(false);
    }

    public void OpenMenu()
    {
        quitToMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        quitToMenu.SetActive(false);
    }
}
