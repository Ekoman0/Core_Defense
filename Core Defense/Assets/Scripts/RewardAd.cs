using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

public class RewardAd : MonoBehaviour
{
    string sceneName;
    public GameObject shop;
    public TextMeshProUGUI MoneyTMP;
    public TextMeshProUGUI CheckTMP;
    public TextMeshProUGUI CheckSkinTMP;
    float money;
    string adUnitID;
    string adUnitIDExtraLife;
    RewardedAd odullureklam;
    RewardedAd skinodullureklam;
    RewardedAd canodullureklam;

    private LocalizeStringEvent localizedStringEvent;
    // Start is called before the first frame update

    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        adUnitID = "ca-app-pub-3138384441939461/6525686769";
        adUnitIDExtraLife = "ca-app-pub-3138384441939461/4186511619";

        LoadRewardedAd();
        LoadSkinRewardedAd();
    }
    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (odullureklam != null)
        {
            odullureklam.Destroy();
            odullureklam = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(adUnitID, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                odullureklam = ad;
                CheckTMP.text = LocalizationSettings.StringDatabase.GetLocalizedString("Shop", "Reklam Ýzle");
            });
    }
    public void LoadSkinRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (skinodullureklam != null)
        {
            skinodullureklam.Destroy();
            skinodullureklam = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(adUnitID, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                skinodullureklam = ad;
                CheckSkinTMP.text = LocalizationSettings.StringDatabase.GetLocalizedString("Shop", "Reklam Ýzle");

            });
    }


    private void Update()
    {
        if (PlayerPrefs.HasKey("SkinReward"))
        {
            float a = PlayerPrefs.GetFloat("SkinReward");
            if ( a == 1)
            {
                if (shop !=null)
                {
                    shop.GetComponent<Shop>().Player13Buy();
                }
               

                PlayerPrefs.SetFloat("SkinReward", 0);
            }
        }
    }

    private void skinadloaded(object sender, EventArgs e)
    {
        CheckSkinTMP.text = LocalizationSettings.StringDatabase.GetLocalizedString("Shop", "Reklam Ýzle");
    }

    

    public void UserChoseToWatchAd()
    {
        if (odullureklam != null && odullureklam.CanShowAd())
        {
            odullureklam.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                money = PlayerPrefs.GetFloat("Money");
                money += 20;

                MoneyTMP.text = money.ToString();
                PlayerPrefs.SetFloat("Money", money);
                CheckTMP.text = " ";

            });
        }
        
    }

    public void UserChoseToWatchAdSkin()
    {
        skinodullureklam.Show((Reward reward) =>
        {
            // TODO: Reward the user.
            PlayerPrefs.SetFloat("SkinReward", 1);
            

        });
        
    }
    

    
   




    
}
