using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject helpPanel, mainPanel, endGamePanel;
    [SerializeField] private AudioSource buttonClick;
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
        buttonClick.Play();
        SceneManager.LoadScene("MainScene");
    }

    public void OnMenuButtonClicked()
    {
        buttonClick.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void OnHelpButtonClicked()
    {
        buttonClick.Play();
        helpPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void OnCloseButtonClicked()
    {
        buttonClick.Play();
        helpPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void OnQuitButtonClicked()
    {
        buttonClick.Play();
        Application.Quit();
    }

    public void DisableEndGamePanel()
    {
        endGamePanel.SetActive(false);
    }
    public void EnableEndGamePanel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endGamePanel.SetActive(true);
    }
}

