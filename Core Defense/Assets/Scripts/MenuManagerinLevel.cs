using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManagerinLevel : MonoBehaviour
{
    public Button PauseButton;
    public Button ResumeButton;
    public Image SettingsImg;

    public void Save()
    {
        SaveLoadSystem.SaveLoadSystem.SaveNew();
    }
    public void SaveAndExit()
    {
        SaveLoadSystem.SaveLoadSystem.SaveNew();
        SceneManager.LoadScene(0);
    }
    public void exit()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenSettings()
    {
        Time.timeScale = 0;
        SettingsImg.gameObject.SetActive(true);
    }
    public void CloseSettings()
    {
        Time.timeScale = 1;
        SettingsImg.gameObject.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;    
        PauseButton.gameObject.SetActive(false);
        ResumeButton.gameObject.SetActive(true);
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        ResumeButton.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(true);
    }
}
