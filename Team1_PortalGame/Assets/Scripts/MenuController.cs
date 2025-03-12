using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text resultTxt;
    [SerializeField] private GameObject helpPanel, mainPanel, resultsPanel;
    Scene scene;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            helpPanel.SetActive(false);
        }
        else if (scene.name == "MainGame")
        {
            resultsPanel.SetActive(false);
        }

    }
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnMenuButtonClicked()
    {
        resultsPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
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
}

