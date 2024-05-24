using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject statsPanel;
    [SerializeField] GameObject questPanel;
    [SerializeField] GameObject quitToMenu;


    private bool menuOpen;

    private void Start()
    {
        menuOpen = false;
    }

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
            menuOpen = menuOpen ? false : true;

            if( menuOpen )
            {
                //Time.timeScale = 0;
                OpenMenu();
            }
            else
            {
                Time.timeScale = 1;
                CloseMenu();
            }
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
        print("close menu");
        quitToMenu.SetActive(false);
    }
}
