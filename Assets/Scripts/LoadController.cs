using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
    [SerializeField] private AudioSource _playSoundMenu;
    [SerializeField] private AudioSource _playSoundBack;
    
    

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
        _playSoundMenu.Play();
        _playSoundBack.Pause();
        Time.timeScale = 0;
    }
    public void LoadPanelBtn()
    {
        SetCurrentScreen(Screen.Tools);
        _playSoundMenu.Pause();
        _playSoundBack.Play();
    }
    public void Continue()
    {
        SetCurrentScreen(Screen.Tools);
        
        _playSoundMenu.Pause();
        _playSoundBack.Play();
        Time.timeScale = 1;
    }
    public void Restart()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("Menu");
    }


}
