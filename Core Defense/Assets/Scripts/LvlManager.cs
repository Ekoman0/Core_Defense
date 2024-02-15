using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LvlManager : MonoBehaviour
{
    public Button lvl2SelectButton;
    public Button lvl2PlayButton;
    public Button lvl3SelectButton;
    public Button lvl3PlayButton;
    public Button lvl4SelectButton;
    public Button lvl4PlayButton;
   

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Lvl1Complete") == 1)
        {
            lvl2SelectButton.gameObject.SetActive(false);
            lvl2PlayButton.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lvl2Complete") == 1)
        {
            lvl3SelectButton.gameObject.SetActive(false);
            lvl3PlayButton.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lvl3Complete") == 1)
        {
            lvl4SelectButton.gameObject.SetActive(false);
            lvl4PlayButton.gameObject.SetActive(true);
        }
    }
   
    public void openlvl()
    {
        PlayerPrefs.SetInt("Lvl1Complete", 1);
        PlayerPrefs.SetInt("Lvl2Complete", 1);
        PlayerPrefs.SetInt("Lvl3Complete", 1);
    }

    public void PlayLvl1()
    {
       lvlclear();
        PlayerPrefs.SetInt("Lvl1Select", 1);
        SceneManager.LoadScene(1);
    }
    public void PlayLvl2()
    {
        lvlclear();
        PlayerPrefs.SetInt("Lvl2Select", 1);
        SceneManager.LoadScene(1);
    }
    public void PlayLvl3()
    {
        lvlclear();
        PlayerPrefs.SetInt("Lvl3Select", 1);
        SceneManager.LoadScene(1);
    }
    public void PlayLvl4()
    {
        lvlclear();
        PlayerPrefs.SetInt("Lvl4Select", 1);
        SceneManager.LoadScene(1);
    }


    void lvlclear()
    {
        PlayerPrefs.SetInt("Lvl1Select", 0);
        PlayerPrefs.SetInt("Lvl2Select", 0);
        PlayerPrefs.SetInt("Lvl3Select", 0);
        PlayerPrefs.SetInt("Lvl4Select", 0);
    }
}
