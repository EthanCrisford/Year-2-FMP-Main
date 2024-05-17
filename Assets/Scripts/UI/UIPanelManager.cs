using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject statsPanel;
    [SerializeField] GameObject questPanel;

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
}
