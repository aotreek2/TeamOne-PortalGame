using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject helpPanel, mainPanel, endGamePanel;
    public TMP_Text outcomeTxt;
    Scene scene;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Main Menu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            helpPanel.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnHelpButtonClicked()
    {
        helpPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void OnCloseButtonClicked()
    {
        helpPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    public void DisableEndGamePanel()
    {
        endGamePanel.SetActive(true);
    }
    public void EnableEndGamePanel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endGamePanel.SetActive(true);
    }
}

