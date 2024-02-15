using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
public class Menu : MonoBehaviour
{
    string sceneName;

 

    public TMP_InputField input;
    private int inputÝnt;
    public TextMeshProUGUI InvalidData;
    public Scrollbar IronFrequencyScrollbar;
    public TextMeshProUGUI IronFrequencyText;
    public Scrollbar CoalFrequencyScrollbar;
    public TextMeshProUGUI CoalFrequencyText;
    public Scrollbar CopperFrequencyScrollbar;
    public TextMeshProUGUI CopperFrequencyText;
    public Scrollbar UraniumFrequencyScrollbar;
    public TextMeshProUGUI UraniumFrequencyText;



    // Start is called before the first frame update
    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();
         sceneName = currentScene.name;
        if (InvalidData != null)
        {
            InvalidData.enabled = false;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sceneName == "MenuSettings")
        {
            if (IronFrequencyScrollbar.value <= 0.25)
            {
                IronFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Az");
            }
            else if (IronFrequencyScrollbar.value > 0.25 && IronFrequencyScrollbar.value < 0.75)
            {
                IronFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Normal");
            }
            else if (IronFrequencyScrollbar.value >= 0.75)
            {
                IronFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Çok");
            }

            //Kömür Sýklýðý Kontrol

            if (CoalFrequencyScrollbar.value <= 0.25)
            {
                CoalFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Az");
            }
            else if (CoalFrequencyScrollbar.value > 0.25 && CoalFrequencyScrollbar.value < 0.75)
            {
                CoalFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Normal");
            }
            else if (CoalFrequencyScrollbar.value >= 0.75)
            {
                CoalFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Çok");
            }

            //Bakýr Sýklýðý Kontrol

            if (CopperFrequencyScrollbar.value <= 0.25)
            {
                CopperFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Az");
            }
            else if (CopperFrequencyScrollbar.value > 0.25 && CopperFrequencyScrollbar.value < 0.75)
            {
                CopperFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Normal");
            }
            else if (CopperFrequencyScrollbar.value >= 0.75)
            {
                CopperFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Çok");
            }

            //Uranium Sýklýðý Kontrol

            if (UraniumFrequencyScrollbar.value <= 0.25)
            {
                UraniumFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Az");
            }
            else if (UraniumFrequencyScrollbar.value > 0.25 && UraniumFrequencyScrollbar.value < 0.75)
            {
                UraniumFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Normal");
            }
            else if (UraniumFrequencyScrollbar.value >= 0.75)
            {
                UraniumFrequencyText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Menu Settings", "Sýklýk Çok");
            }
        }
        
    }
    public void playgame()
    {
        
        
        PlayerPrefs.SetFloat("IronFrequency", IronFrequencyScrollbar.value);
        //Demir Sýklýðý PlayerPrefs
        PlayerPrefs.SetFloat("CoalFrequency", CoalFrequencyScrollbar.value);
        //Kömür Sýklýðý PlayerPRefs
        PlayerPrefs.SetFloat("CopperFrequency", CopperFrequencyScrollbar.value);
        //Bakýr Sýklýðý PlayerPRefs
        PlayerPrefs.SetFloat("UraniumFrequency", UraniumFrequencyScrollbar.value);
        //Bakýr Sýklýðý PlayerPRefs


        PlayerPrefs.SetString("totalScoreKey", input.text);
        if (PlayerPrefs.HasKey("totalScoreKey"))  //totalScoreKey anahtarýyla kaydedilmiþ bir veri var mý ?
        {


            input.text = PlayerPrefs.GetString("totalScoreKey"); // totalScoreKey anahtarýyla kaydedilmiþ veriyi getir
            inputÝnt = int.Parse(input.text);
            if (inputÝnt > 0 && inputÝnt < 181)
            {
                
                if (PlayerPrefs.GetInt("Lvl1Select") == 1)
                {
                    SceneManager.LoadScene(2);
                }
                else if (PlayerPrefs.GetInt("Lvl2Select") == 1)
                {
                    SceneManager.LoadScene(7);
                }
                else if (PlayerPrefs.GetInt("Lvl3Select") == 1)
                {
                    SceneManager.LoadScene(11);
                }
                else if (PlayerPrefs.GetInt("Lvl4Select") == 1)
                {
                    SceneManager.LoadScene(13);
                }

            }
            else
            {
                InvalidData.enabled = true;
            }
        }
    }
    public void GoHowPlay()
    {
        SceneManager.LoadScene(10);
    }
    public void GoLvlSettings()
    {
        SceneManager.LoadScene(8);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoMenuLoseorWinButton()
    {
        PlayerPrefs.SetInt("GameSave", 0);
        SceneManager.LoadScene(0);
    }
    public void GoShop()
    {
        SceneManager.LoadScene(5);
    }
    public void GoSettings()
    {
        SceneManager.LoadScene(9);
    }
    public void GoLVL1load()
    {
        if (PlayerPrefs.HasKey("GameSave"))
        {
            if (PlayerPrefs.GetInt("GameSave") == 1)
            {
                if (PlayerPrefs.GetInt("WhichLvl")==1)
                {
                    SceneManager.LoadScene(6);
                }
                if (PlayerPrefs.GetInt("WhichLvl") == 2)
                {
                    SceneManager.LoadScene(12);
                }
                if (PlayerPrefs.GetInt("WhichLvl") == 3)
                {
                    SceneManager.LoadScene(6);
                }

            }
        }
        
    }


    public void lwl2()
    {
        SceneManager.LoadScene(7);
    }
}
