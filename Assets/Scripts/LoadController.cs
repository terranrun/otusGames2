using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour
{
    enum Screen
    {
        PauseMenu,
        Tools
    }
    public CanvasGroup Tools;
    public CanvasGroup PauseMenu;

    private void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(Tools, screen == Screen.Tools);
        Utility.SetCanvasGroupEnabled(PauseMenu, screen == Screen.PauseMenu);
    }

    void Start()
    {
        SetCurrentScreen(Screen.Tools);
    }

    public void PauseMenuPanel()
    {
        SetCurrentScreen(Screen.PauseMenu);
        Time.timeScale = 0;
    }
    public void LoadPanelBtn()
    {
        SetCurrentScreen(Screen.Tools);
        
    }
    public void Continue()
    {
        SetCurrentScreen(Screen.Tools);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
