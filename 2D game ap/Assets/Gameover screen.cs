using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public GameObject menuPanel; // Reference to the menu panel GameObject

    void Start()
    {
        // Disable the game over panel at the start of the game
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the menu panel active state
            if (menuPanel != null)
            {
                menuPanel.SetActive(!menuPanel.activeSelf);

                // Toggle the game pause state
                if (Time.timeScale == 0)
                    Time.timeScale = 1;
                else
                    Time.timeScale = 0;
            }
        }
    }
}
