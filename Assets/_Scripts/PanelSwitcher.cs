using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject firstPanel;
    public GameObject secondPanel;

    private void Start()
    {
        // Initially hide the second panel
        secondPanel.SetActive(false);
    }

    public void SwitchToSecondPanel()
    {
        // Hide the first panel and show the second panel
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
    }

    public void SwitchToFirstPanel()
    {
        // Hide the second panel and show the first panel
        secondPanel.SetActive(false);
        firstPanel.SetActive(true);
    }
}
