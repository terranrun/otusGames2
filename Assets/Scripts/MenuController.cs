using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    enum Screen
    {
        None,
        Main,
        Settings,
        LoadLVL,
        LoadMainMenu

    }

    public CanvasGroup mainScreen;
    public CanvasGroup settingsScreen;
    public CanvasGroup LoadLVL;
    


    private void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Settings);
        Utility.SetCanvasGroupEnabled(LoadLVL, screen == Screen.LoadLVL);
        
    }
    
    void Start()
    {
        SetCurrentScreen(Screen.Main);
    }

    
    public void StartNewGame()
    {
        SetCurrentScreen(Screen.None);
        
        LoadingScreen.instance.LoadScene("Game");
        
    }
    public void OpenLoad()
    {
        SetCurrentScreen(Screen.LoadLVL);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void OpenSettings()
    {
        SetCurrentScreen(Screen.Settings);
    }

    public void Close()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
