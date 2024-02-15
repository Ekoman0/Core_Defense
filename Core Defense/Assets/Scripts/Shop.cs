using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    private BuildSystem buildsys;
    private float money;
    public TextMeshProUGUI MoneyTMP;

    [Header("Parent")]
    public Image PlayerParent;
    public Image BasicTurretParent;
    public Image AdvancedTurretParent;
    public Image LazerTurretParent;

    #region LAZER TURRET
    [Header("LAZER TURRET BUY")]
    public Button LazerTurret1BuyButton;
    public Button LazerTurret2BuyButton;
    public Button LazerTurret3BuyButton;
    public Button LazerTurret4BuyButton;
    public Button LazerTurret5BuyButton;

    [Header("LAZER TURRET SELECT")]
    public Button LazerTurret0SelectButton;
    public Button LazerTurret1SelectButton;
    public Button LazerTurret2SelectButton;
    public Button LazerTurret3SelectButton;
    public Button LazerTurret4SelectButton;
    public Button LazerTurret5SelectButton;

    private int IsLazerTurret1Buyed;
    private int IsLazerTurret2Buyed;
    private int IsLazerTurret3Buyed;
    private int IsLazerTurret4Buyed;
    private int IsLazerTurret5Buyed;

    private float LazerTurret1Price = 800;
    private float LazerTurret2Price = 100;
    private float LazerTurret3Price = 150;
    private float LazerTurret4Price = 85;
    private float LazerTurret5Price = 470;
    #endregion

    #region ADVANCED TURRET
    [Header("ADVANCED TURRET BUY")]
    public Button AdvancedTurret1BuyButton;

    [Header("ADVANCED TURRET SELECT")]
    public Button AdvancedTurret0SelectButton;
    public Button AdvancedTurret1SelectButton;

    private int IsAdvancedTurret1Buyed;
    private float AdvancedTurret1Price = 800;
    #endregion


    #region BASIC TURRET



    [Header("BASIC TURRET BUY")]
    public Button BasicTurret1BuyButton;
    public Button BasicTurret2BuyButton;
    public Button BasicTurret3BuyButton;
    public Button BasicTurret4BuyButton;
    public Button BasicTurret5BuyButton;
    public Button BasicTurret6BuyButton;
    public Button BasicTurret7BuyButton;
    public Button BasicTurret8BuyButton;
    public Button BasicTurret9BuyButton;
    public Button BasicTurret10BuyButton;
    public Button BasicTurret11BuyButton;
    public Button BasicTurret12BuyButton;
    public Button BasicTurret13BuyButton;

    [Header("BASIC TURRET SELECT")]
    public Button BasicTurret0SelectButton;
    public Button BasicTurret1SelectButton;
    public Button BasicTurret2SelectButton;
    public Button BasicTurret3SelectButton;
    public Button BasicTurret4SelectButton;
    public Button BasicTurret5SelectButton;
    public Button BasicTurret6SelectButton;
    public Button BasicTurret7SelectButton;
    public Button BasicTurret8SelectButton;
    public Button BasicTurret9SelectButton;
    public Button BasicTurret10SelectButton;
    public Button BasicTurret11SelectButton;
    public Button BasicTurret12SelectButton;
    public Button BasicTurret13SelectButton;

    private int IsBasicTurret1Buyed;
    private int IsBasicTurret2Buyed;
    private int IsBasicTurret3Buyed;
    private int IsBasicTurret4Buyed;
    private int IsBasicTurret5Buyed;
    private int IsBasicTurret6Buyed;
    private int IsBasicTurret7Buyed;
    private int IsBasicTurret8Buyed;
    private int IsBasicTurret9Buyed;
    private int IsBasicTurret10Buyed;
    private int IsBasicTurret11Buyed;
    private int IsBasicTurret12Buyed;
    private int IsBasicTurret13Buyed;

    private float BasicTurret1Price = 250;
    private float BasicTurret2Price = 500;
    private float BasicTurret3Price = 400;
    private float BasicTurret4Price = 220;
    private float BasicTurret5Price = 280;
    private float BasicTurret6Price = 180;
    private float BasicTurret7Price = 330;
    private float BasicTurret8Price = 620;
    private float BasicTurret9Price = 435;
    private float BasicTurret10Price = 350;
    private float BasicTurret11Price = 333;
    private float BasicTurret12Price = 150;
    private float BasicTurret13Price = 1000;
    #endregion


    #region PLAYER VARÝABLE
    [Header("PLAYER BUY")]
    public Button Player1BuyButton;
    public Button Player2BuyButton;
    public Button Player3BuyButton;
    public Button Player4BuyButton;
    public Button Player5BuyButton;
    public Button Player6BuyButton;
    public Button Player7BuyButton;
    public Button Player8BuyButton;
    public Button Player9BuyButton;
    public Button Player10BuyButton;
    public Button Player11BuyButton;
    public Button Player12BuyButton;
    public Button Player13BuyButton;
    public Button Player14BuyButton;
    public Button Player15BuyButton;
    public Button Player16BuyButton;
    public Button Player17BuyButton;
    public Button Player18BuyButton;
    public Button Player19BuyButton;
    public Button Player20BuyButton;
    public Button Player21BuyButton;
    public Button Player22BuyButton;
    public Button Player23BuyButton;
    public Button Player24BuyButton;
    public Button Player25BuyButton;
    public Button Player26BuyButton;
    public Button Player27BuyButton;
    public Button Player28BuyButton;
    public Button Player29BuyButton;

    [Header("PLAYER SELECT")]
    public Button Player0SelectButton;
    public Button Player1SelectButton;
    public Button Player2SelectButton;
    public Button Player3SelectButton;
    public Button Player4SelectButton;
    public Button Player5SelectButton;
    public Button Player6SelectButton;
    public Button Player7SelectButton;
    public Button Player8SelectButton;
    public Button Player9SelectButton;
    public Button Player10SelectButton;
    public Button Player11SelectButton;
    public Button Player12SelectButton;
    public Button Player13SelectButton;
    public Button Player14SelectButton;
    public Button Player15SelectButton;
    public Button Player16SelectButton;
    public Button Player17SelectButton;
    public Button Player18SelectButton;
    public Button Player19SelectButton;
    public Button Player20SelectButton;
    public Button Player21SelectButton;
    public Button Player22SelectButton;
    public Button Player23SelectButton;
    public Button Player24SelectButton;
    public Button Player25SelectButton;
    public Button Player26SelectButton;
    public Button Player27SelectButton;
    public Button Player28SelectButton;
    public Button Player29SelectButton;

    private int IsPlayer1Buyed;
    private int IsPlayer2Buyed;
    private int IsPlayer3Buyed;
    private int IsPlayer4Buyed;
    private int IsPlayer5Buyed;
    private int IsPlayer6Buyed;
    private int IsPlayer7Buyed;
    private int IsPlayer8Buyed;
    private int IsPlayer9Buyed;
    private int IsPlayer10Buyed;
    private int IsPlayer11Buyed;
    private int IsPlayer12Buyed;
    private int IsPlayer13Buyed;
    private int IsPlayer14Buyed;
    private int IsPlayer15Buyed;
    private int IsPlayer16Buyed;
    private int IsPlayer17Buyed;
    private int IsPlayer18Buyed;
    private int IsPlayer19Buyed;
    private int IsPlayer20Buyed;
    private int IsPlayer21Buyed;
    private int IsPlayer22Buyed;
    private int IsPlayer23Buyed;
    private int IsPlayer24Buyed;
    private int IsPlayer25Buyed;
    private int IsPlayer26Buyed;
    private int IsPlayer27Buyed;
    private int IsPlayer28Buyed;
    private int IsPlayer29Buyed;

    private float Player1Price = 30;
    private float Player2Price = 500;
    private float Player3Price = 150;
    private float Player4Price = 200;
    private float Player5Price = 180;
    private float Player6Price = 500;
    private float Player7Price = 350;
    private float Player8Price = 600;
    private float Player9Price = 500;
    private float Player10Price = 850;
    private float Player11Price = 850;
    private float Player12Price = 500;
    private float Player13Price = 900;
    private float Player14Price = 670;
    private float Player15Price = 520;
    private float Player16Price = 380;
    private float Player17Price = 200;
    private float Player18Price = 480;
    private float Player19Price = 600;
    private float Player20Price = 400;
    private float Player21Price = 1000;
    private float Player22Price = 1500;
    private float Player23Price = 50;
    private float Player24Price = 500;
    private float Player25Price = 650;
    private float Player26Price = 130;
    private float Player27Price = 160;
    private float Player28Price = 400;
    private float Player29Price = 670;
    #endregion

    #region PARENT
    public void OpenPlayerParent()
    {
        CloseAllParent();
        PlayerParent.gameObject.SetActive(true);
    }

    public void OpenBasicTurretParent()
    {
        CloseAllParent();
        BasicTurretParent.gameObject.SetActive(true);
    }
    public void OpenAdvancedTurretParent()
    {
        CloseAllParent();
        AdvancedTurretParent.gameObject.SetActive(true);
    }
    public void OpenLazerTurretParent()
    {
        CloseAllParent();
        LazerTurretParent.gameObject.SetActive(true);
    }

    void CloseAllParent()
    {
        PlayerParent.gameObject.SetActive(false);
        BasicTurretParent.gameObject.SetActive(false);
        AdvancedTurretParent.gameObject.SetActive(false);
        LazerTurretParent.gameObject.SetActive(false);
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Money"))  
        {
            money = PlayerPrefs.GetFloat("Money");
           
            MoneyTMP.text = money.ToString();

        }
        
   


        #region Player
        if (PlayerPrefs.HasKey("IsPlayer1Buyed"))
        {
            IsPlayer1Buyed = PlayerPrefs.GetInt("IsPlayer1Buyed");
            if (IsPlayer1Buyed == 1)
            {
                Player1BuyButton.gameObject.SetActive(false);
                Player1SelectButton.gameObject.SetActive(true);
            }
        }

        if (PlayerPrefs.HasKey("IsPlayer2Buyed"))
        {
            IsPlayer2Buyed = PlayerPrefs.GetInt("IsPlayer2Buyed");
            if (IsPlayer2Buyed == 1)
            {
                Player2BuyButton.gameObject.SetActive(false);
                Player2SelectButton.gameObject.SetActive(true);
            }
        }

        if (PlayerPrefs.HasKey("IsPlayer3Buyed"))
        {
            IsPlayer3Buyed = PlayerPrefs.GetInt("IsPlayer3Buyed");
            if (IsPlayer3Buyed == 1)
            {
                Player3BuyButton.gameObject.SetActive(false);
                Player3SelectButton.gameObject.SetActive(true);
            }
        }

        if (PlayerPrefs.HasKey("IsPlayer4Buyed"))
        {
            IsPlayer4Buyed = PlayerPrefs.GetInt("IsPlayer4Buyed");
            if (IsPlayer4Buyed == 1)
            {
                Player4BuyButton.gameObject.SetActive(false);
                Player4SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer5Buyed"))
        {
            IsPlayer5Buyed = PlayerPrefs.GetInt("IsPlayer5Buyed");
            if (IsPlayer5Buyed == 1)
            {
                Player5BuyButton.gameObject.SetActive(false);
                Player5SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer6Buyed"))
        {
            IsPlayer6Buyed = PlayerPrefs.GetInt("IsPlayer6Buyed");
            if (IsPlayer6Buyed == 1)
            {
                Player6BuyButton.gameObject.SetActive(false);
                Player6SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer7Buyed"))
        {
            IsPlayer7Buyed = PlayerPrefs.GetInt("IsPlayer7Buyed");
            if (IsPlayer7Buyed == 1)
            {
                Player7BuyButton.gameObject.SetActive(false);
                Player7SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer8Buyed"))
        {
            IsPlayer8Buyed = PlayerPrefs.GetInt("IsPlayer8Buyed");
            if (IsPlayer8Buyed == 1)
            {
                Player8BuyButton.gameObject.SetActive(false);
                Player8SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer9Buyed"))
        {
            IsPlayer9Buyed = PlayerPrefs.GetInt("IsPlayer9Buyed");
            if (IsPlayer9Buyed == 1)
            {
                Player9BuyButton.gameObject.SetActive(false);
                Player9SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer10Buyed"))
        {
            IsPlayer10Buyed = PlayerPrefs.GetInt("IsPlayer10Buyed");
            if (IsPlayer10Buyed == 1)
            {
                Player10BuyButton.gameObject.SetActive(false);
                Player10SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer11Buyed"))
        {
            IsPlayer11Buyed = PlayerPrefs.GetInt("IsPlayer11Buyed");
            if (IsPlayer11Buyed == 1)
            {
                Player11BuyButton.gameObject.SetActive(false);
                Player11SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer12Buyed"))
        {
            IsPlayer12Buyed = PlayerPrefs.GetInt("IsPlayer12Buyed");
            if (IsPlayer12Buyed == 1)
            {
                Player12BuyButton.gameObject.SetActive(false);
                Player12SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer13Buyed"))
        {
            IsPlayer13Buyed = PlayerPrefs.GetInt("IsPlayer13Buyed");
            if (IsPlayer13Buyed == 1)
            {
                Player13BuyButton.gameObject.SetActive(false);
                Player13SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer14Buyed"))
        {
            IsPlayer14Buyed = PlayerPrefs.GetInt("IsPlayer14Buyed");
            if (IsPlayer14Buyed == 1)
            {
                Player14BuyButton.gameObject.SetActive(false);
                Player14SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer15Buyed"))
        {
            IsPlayer15Buyed = PlayerPrefs.GetInt("IsPlayer15Buyed");
            if (IsPlayer15Buyed == 1)
            {
                Player15BuyButton.gameObject.SetActive(false);
                Player15SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer16Buyed"))
        {
            IsPlayer16Buyed = PlayerPrefs.GetInt("IsPlayer16Buyed");
            if (IsPlayer16Buyed == 1)
            {
                Player16BuyButton.gameObject.SetActive(false);
                Player16SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer17Buyed"))
        {
            IsPlayer17Buyed = PlayerPrefs.GetInt("IsPlayer17Buyed");
            if (IsPlayer17Buyed == 1)
            {
                Player17BuyButton.gameObject.SetActive(false);
                Player17SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer18Buyed"))
        {
            IsPlayer18Buyed = PlayerPrefs.GetInt("IsPlayer18Buyed");
            if (IsPlayer18Buyed == 1)
            {
                Player18BuyButton.gameObject.SetActive(false);
                Player18SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer19Buyed"))
        {
            IsPlayer19Buyed = PlayerPrefs.GetInt("IsPlayer19Buyed");
            if (IsPlayer19Buyed == 1)
            {
                Player19BuyButton.gameObject.SetActive(false);
                Player19SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer20Buyed"))
        {
            IsPlayer20Buyed = PlayerPrefs.GetInt("IsPlayer20Buyed");
            if (IsPlayer20Buyed == 1)
            {
                Player20BuyButton.gameObject.SetActive(false);
                Player20SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer21Buyed"))
        {
            IsPlayer21Buyed = PlayerPrefs.GetInt("IsPlayer21Buyed");
            if (IsPlayer21Buyed == 1)
            {
                Player21BuyButton.gameObject.SetActive(false);
                Player21SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer22Buyed"))
        {
            IsPlayer22Buyed = PlayerPrefs.GetInt("IsPlayer22Buyed");
            if (IsPlayer22Buyed == 1)
            {
                Player22BuyButton.gameObject.SetActive(false);
                Player22SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer23Buyed"))
        {
            IsPlayer23Buyed = PlayerPrefs.GetInt("IsPlayer23Buyed");
            if (IsPlayer23Buyed == 1)
            {
                Player23BuyButton.gameObject.SetActive(false);
                Player23SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer24Buyed"))
        {
            IsPlayer24Buyed = PlayerPrefs.GetInt("IsPlayer24Buyed");
            if (IsPlayer24Buyed == 1)
            {
                Player24BuyButton.gameObject.SetActive(false);
                Player24SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer25Buyed"))
        {
            IsPlayer25Buyed = PlayerPrefs.GetInt("IsPlayer25Buyed");
            if (IsPlayer25Buyed == 1)
            {
                Player25BuyButton.gameObject.SetActive(false);
                Player25SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer26Buyed"))
        {
            IsPlayer26Buyed = PlayerPrefs.GetInt("IsPlayer26Buyed");
            if (IsPlayer26Buyed == 1)
            {
                Player26BuyButton.gameObject.SetActive(false);
                Player26SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer20Buyed"))
        {
            IsPlayer27Buyed = PlayerPrefs.GetInt("IsPlayer27Buyed");
            if (IsPlayer27Buyed == 1)
            {
                Player27BuyButton.gameObject.SetActive(false);
                Player27SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer28Buyed"))
        {
            IsPlayer28Buyed = PlayerPrefs.GetInt("IsPlayer28Buyed");
            if (IsPlayer28Buyed == 1)
            {
                Player28BuyButton.gameObject.SetActive(false);
                Player28SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsPlayer29Buyed"))
        {
            IsPlayer29Buyed = PlayerPrefs.GetInt("IsPlayer29Buyed");
            if (IsPlayer29Buyed == 1)
            {
                Player29BuyButton.gameObject.SetActive(false);
                Player29SelectButton.gameObject.SetActive(true);
            }
        }
        #endregion

        #region BASIC TURRET
        if (PlayerPrefs.HasKey("IsBasicTurret1Buyed"))
        {
            IsBasicTurret1Buyed = PlayerPrefs.GetInt("IsBasicTurret1Buyed");
            if (IsBasicTurret1Buyed == 1)
            {
                BasicTurret1BuyButton.gameObject.SetActive(false);
                BasicTurret1SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret2Buyed"))
        {
            IsBasicTurret2Buyed = PlayerPrefs.GetInt("IsBasicTurret2Buyed");
            if (IsBasicTurret2Buyed == 1)
            {
                BasicTurret2BuyButton.gameObject.SetActive(false);
                BasicTurret2SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret3Buyed"))
        {
            IsBasicTurret3Buyed = PlayerPrefs.GetInt("IsBasicTurret3Buyed");
            if (IsBasicTurret3Buyed == 1)
            {
                BasicTurret3BuyButton.gameObject.SetActive(false);
                BasicTurret3SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret4Buyed"))
        {
            IsBasicTurret4Buyed = PlayerPrefs.GetInt("IsBasicTurret4Buyed");
            if (IsBasicTurret4Buyed == 1)
            {
                BasicTurret4BuyButton.gameObject.SetActive(false);
                BasicTurret4SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret5Buyed"))
        {
            IsBasicTurret5Buyed = PlayerPrefs.GetInt("IsBasicTurret5Buyed");
            if (IsBasicTurret5Buyed == 1)
            {
                BasicTurret5BuyButton.gameObject.SetActive(false);
                BasicTurret5SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret6Buyed"))
        {
            IsBasicTurret6Buyed = PlayerPrefs.GetInt("IsBasicTurret6Buyed");
            if (IsBasicTurret6Buyed == 1)
            {
                BasicTurret6BuyButton.gameObject.SetActive(false);
                BasicTurret6SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret7Buyed"))
        {
            IsBasicTurret7Buyed = PlayerPrefs.GetInt("IsBasicTurret7Buyed");
            if (IsBasicTurret7Buyed == 1)
            {
                BasicTurret7BuyButton.gameObject.SetActive(false);
                BasicTurret7SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret8Buyed"))
        {
            IsBasicTurret8Buyed = PlayerPrefs.GetInt("IsBasicTurret8Buyed");
            if (IsBasicTurret8Buyed == 1)
            {
                BasicTurret8BuyButton.gameObject.SetActive(false);
                BasicTurret8SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret9Buyed"))
        {
            IsBasicTurret9Buyed = PlayerPrefs.GetInt("IsBasicTurret9Buyed");
            if (IsBasicTurret9Buyed == 1)
            {
                BasicTurret9BuyButton.gameObject.SetActive(false);
                BasicTurret9SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret10Buyed"))
        {
            IsBasicTurret10Buyed = PlayerPrefs.GetInt("IsBasicTurret10Buyed");
            if (IsBasicTurret10Buyed == 1)
            {
                BasicTurret10BuyButton.gameObject.SetActive(false);
                BasicTurret10SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret11Buyed"))
        {
            IsBasicTurret11Buyed = PlayerPrefs.GetInt("IsBasicTurret11Buyed");
            if (IsBasicTurret11Buyed == 1)
            {
                BasicTurret11BuyButton.gameObject.SetActive(false);
                BasicTurret11SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret12Buyed"))
        {
            IsBasicTurret12Buyed = PlayerPrefs.GetInt("IsBasicTurret12Buyed");
            if (IsBasicTurret12Buyed == 1)
            {
                BasicTurret12BuyButton.gameObject.SetActive(false);
                BasicTurret12SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsBasicTurret13Buyed"))
        {
            IsBasicTurret13Buyed = PlayerPrefs.GetInt("IsBasicTurret13Buyed");
            if (IsBasicTurret13Buyed == 1)
            {
                BasicTurret13BuyButton.gameObject.SetActive(false);
                BasicTurret13SelectButton.gameObject.SetActive(true);
            }
        }

        #endregion

        #region ADVANCED TURRET
        if (PlayerPrefs.HasKey("IsAdvancedTurret1Buyed"))
        {
            IsAdvancedTurret1Buyed = PlayerPrefs.GetInt("IsAdvancedTurret1Buyed");
            if (IsAdvancedTurret1Buyed == 1)
            {
                AdvancedTurret1BuyButton.gameObject.SetActive(false);
                AdvancedTurret1SelectButton.gameObject.SetActive(true);
            }
        }
        #endregion

        #region LAZER TURRET
        if (PlayerPrefs.HasKey("IsLazerTurret1Buyed"))
        {
            IsLazerTurret1Buyed = PlayerPrefs.GetInt("IsLazerTurret1Buyed");
            if (IsLazerTurret1Buyed == 1)
            {
                LazerTurret1BuyButton.gameObject.SetActive(false);
                LazerTurret1SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsLazerTurret2Buyed"))
        {
            IsLazerTurret2Buyed = PlayerPrefs.GetInt("IsLazerTurret2Buyed");
            if (IsLazerTurret2Buyed == 1)
            {
                LazerTurret2BuyButton.gameObject.SetActive(false);
                LazerTurret2SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsLazerTurret3Buyed"))
        {
            IsLazerTurret3Buyed = PlayerPrefs.GetInt("IsLazerTurret3Buyed");
            if (IsLazerTurret3Buyed == 1)
            {
                LazerTurret3BuyButton.gameObject.SetActive(false);
                LazerTurret3SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsLazerTurret4Buyed"))
        {
            IsLazerTurret4Buyed = PlayerPrefs.GetInt("IsLazerTurret4Buyed");
            if (IsLazerTurret4Buyed == 1)
            {
                LazerTurret4BuyButton.gameObject.SetActive(false);
                LazerTurret4SelectButton.gameObject.SetActive(true);
            }
        }
        if (PlayerPrefs.HasKey("IsLazerTurret5Buyed"))
        {
            IsLazerTurret5Buyed = PlayerPrefs.GetInt("IsLazerTurret5Buyed");
            if (IsLazerTurret5Buyed == 1)
            {
                LazerTurret5BuyButton.gameObject.SetActive(false);
                LazerTurret5SelectButton.gameObject.SetActive(true);
            }
        }
        #endregion

    }


    #region PLAYER BUY
    public void Player1Buy()
    {
        if (money > Player1Price)
        {
            money -= Player1Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer1Buyed", 1);

            Player1BuyButton.gameObject.SetActive(false);
            Player1SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player2Buy()
    {
        if (money > Player2Price)
        {
            money -= Player2Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer2Buyed", 1);

            Player2BuyButton.gameObject.SetActive(false);
            Player2SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player3Buy()
    {
        if (money > Player3Price)
        {
            money -= Player3Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer3Buyed", 1);

            Player3BuyButton.gameObject.SetActive(false);
            Player3SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player4Buy()
    {
        if (money > Player4Price)
        {
            money -= Player4Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer4Buyed", 1);

            Player4BuyButton.gameObject.SetActive(false);
            Player4SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player5Buy()
    {
        if (money > Player5Price)
        {
            money -= Player5Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer5Buyed", 1);

            Player5BuyButton.gameObject.SetActive(false);
            Player5SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player6Buy()
    {
        if (money > Player6Price)
        {
            money -= Player6Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer6Buyed", 1);

            Player6BuyButton.gameObject.SetActive(false);
            Player6SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player7Buy()
    {
        if (money > Player7Price)
        {
            money -= Player7Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer7Buyed", 1);

            Player7BuyButton.gameObject.SetActive(false);
            Player7SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player8Buy()
    {
        if (money > Player8Price)
        {
            money -= Player8Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer8Buyed", 1);

            Player8BuyButton.gameObject.SetActive(false);
            Player8SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player9Buy()
    {
        if (money > Player9Price)
        {
            money -= Player9Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer9Buyed", 1);

            Player9BuyButton.gameObject.SetActive(false);
            Player9SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player10Buy()
    {
        if (money > Player10Price)
        {
            money -= Player10Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer10Buyed", 1);

            Player10BuyButton.gameObject.SetActive(false);
            Player10SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player11Buy()
    {
        if (money > Player11Price)
        {
            money -= Player11Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer11Buyed", 1);

            Player11BuyButton.gameObject.SetActive(false);
            Player11SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player12Buy()
    {
        if (money > Player12Price)
        {
            money -= Player12Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer12Buyed", 1);

            Player12BuyButton.gameObject.SetActive(false);
            Player12SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player13Buy()
    {
        
           

            //PlayerPrefs.SetInt("IsPlayer13Buyed", 1);

            Player13BuyButton.gameObject.SetActive(false);
            Player13SelectButton.gameObject.SetActive(true);
        
    }
    public void Player14Buy()
    {
        if (money > Player14Price)
        {
            money -= Player14Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer14Buyed", 1);

            Player14BuyButton.gameObject.SetActive(false);
            Player14SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player15Buy()
    {
        if (money > Player15Price)
        {
            money -= Player15Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer15Buyed", 1);

            Player15BuyButton.gameObject.SetActive(false);
            Player15SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player16Buy()
    {
        if (money > Player16Price)
        {
            money -= Player16Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer16Buyed", 1);

            Player16BuyButton.gameObject.SetActive(false);
            Player16SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player17Buy()
    {
        if (money > Player17Price)
        {
            money -= Player17Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer17Buyed", 1);

            Player17BuyButton.gameObject.SetActive(false);
            Player17SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player18Buy()
    {
        if (money > Player18Price)
        {
            money -= Player18Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer18Buyed", 1);

            Player18BuyButton.gameObject.SetActive(false);
            Player18SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player19Buy()
    {
        if (money > Player19Price)
        {
            money -= Player19Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer19Buyed", 1);

            Player19BuyButton.gameObject.SetActive(false);
            Player19SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player20Buy()
    {
        if (money > Player20Price)
        {
            money -= Player20Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer20Buyed", 1);

            Player20BuyButton.gameObject.SetActive(false);
            Player20SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player21Buy()
    {
        if (money > Player21Price)
        {
            money -= Player21Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer21Buyed", 1);

            Player21BuyButton.gameObject.SetActive(false);
            Player21SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player22Buy()
    {
        if (money > Player22Price)
        {
            money -= Player22Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer22Buyed", 1);

            Player22BuyButton.gameObject.SetActive(false);
            Player22SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player23Buy()
    {
        if (money > Player23Price)
        {
            money -= Player23Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer23Buyed", 1);

            Player23BuyButton.gameObject.SetActive(false);
            Player23SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player24Buy()
    {
        if (money > Player24Price)
        {
            money -= Player24Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer24Buyed", 1);

            Player24BuyButton.gameObject.SetActive(false);
            Player24SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player25Buy()
    {
        if (money > Player25Price)
        {
            money -= Player25Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer25Buyed", 1);

            Player25BuyButton.gameObject.SetActive(false);
            Player25SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player26Buy()
    {
        if (money > Player26Price)
        {
            money -= Player26Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer26Buyed", 1);

            Player26BuyButton.gameObject.SetActive(false);
            Player26SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player27Buy()
    {
        if (money > Player27Price)
        {
            money -= Player27Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer27Buyed", 1);

            Player27BuyButton.gameObject.SetActive(false);
            Player27SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player28Buy()
    {
        if (money > Player28Price)
        {
            money -= Player28Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer28Buyed", 1);

            Player28BuyButton.gameObject.SetActive(false);
            Player28SelectButton.gameObject.SetActive(true);
        }
    }
    public void Player29Buy()
    {
        if (money > Player29Price)
        {
            money -= Player29Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsPlayer29Buyed", 1);

            Player29BuyButton.gameObject.SetActive(false);
            Player29SelectButton.gameObject.SetActive(true);
        }
    }

    #endregion

    #region BASÝC TURRET BUY

    public void BasicTurret1Buy()
    {
        if (money > BasicTurret1Price)
        {
            money -= BasicTurret1Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret1Buyed", 1);

            BasicTurret1BuyButton.gameObject.SetActive(false);
            BasicTurret1SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret2Buy()
    {
        if (money > BasicTurret2Price)
        {
            money -= BasicTurret2Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret2Buyed", 1);

            BasicTurret2BuyButton.gameObject.SetActive(false);
            BasicTurret2SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret3Buy()
    {
        if (money > BasicTurret3Price)
        {
            money -= BasicTurret3Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret3Buyed", 1);

            BasicTurret3BuyButton.gameObject.SetActive(false);
            BasicTurret3SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret4Buy()
    {
        if (money > BasicTurret4Price)
        {
            money -= BasicTurret4Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret4Buyed", 1);

            BasicTurret4BuyButton.gameObject.SetActive(false);
            BasicTurret4SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret5Buy()
    {
        if (money > BasicTurret5Price)
        {
            money -= BasicTurret5Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret5Buyed", 1);

            BasicTurret5BuyButton.gameObject.SetActive(false);
            BasicTurret5SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret6Buy()
    {
        if (money > BasicTurret6Price)
        {
            money -= BasicTurret6Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret6Buyed", 1);

            BasicTurret6BuyButton.gameObject.SetActive(false);
            BasicTurret6SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret7Buy()
    {
        if (money > BasicTurret7Price)
        {
            money -= BasicTurret7Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret7Buyed", 1);

            BasicTurret7BuyButton.gameObject.SetActive(false);
            BasicTurret7SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret8Buy()
    {
        if (money > BasicTurret8Price)
        {
            money -= BasicTurret8Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret8Buyed", 1);

            BasicTurret8BuyButton.gameObject.SetActive(false);
            BasicTurret8SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret9Buy()
    {
        if (money > BasicTurret9Price)
        {
            money -= BasicTurret9Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret9Buyed", 1);

            BasicTurret9BuyButton.gameObject.SetActive(false);
            BasicTurret9SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret10Buy()
    {
        if (money > BasicTurret10Price)
        {
            money -= BasicTurret10Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret10Buyed", 1);

            BasicTurret10BuyButton.gameObject.SetActive(false);
            BasicTurret10SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret11Buy()
    {
        if (money > BasicTurret11Price)
        {
            money -= BasicTurret11Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret11Buyed", 1);

            BasicTurret11BuyButton.gameObject.SetActive(false);
            BasicTurret11SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret12Buy()
    {
        if (money > BasicTurret12Price)
        {
            money -= BasicTurret12Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret12Buyed", 1);

            BasicTurret12BuyButton.gameObject.SetActive(false);
            BasicTurret12SelectButton.gameObject.SetActive(true);
        }
    }
    public void BasicTurret13Buy()
    {
        if (money > BasicTurret13Price)
        {
            money -= BasicTurret13Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsBasicTurret13Buyed", 1);

            BasicTurret13BuyButton.gameObject.SetActive(false);
            BasicTurret13SelectButton.gameObject.SetActive(true);
        }
    }


    #endregion

    #region ADVANCED TURRET BUY
    public void AdvancedTurret1Buy()
    {
        if (money > AdvancedTurret1Price)
        {
            money -= AdvancedTurret1Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsAdvancedTurret1Buyed", 1);

            AdvancedTurret1BuyButton.gameObject.SetActive(false);
            AdvancedTurret1SelectButton.gameObject.SetActive(true);
        }
    }
    #endregion

    #region LAZER TURRET BUY
    public void LazerTurret1Buy()
    {
        if (money > LazerTurret1Price)
        {
            money -= LazerTurret1Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsLazerTurret1Buyed", 1);

            LazerTurret1BuyButton.gameObject.SetActive(false);
            LazerTurret1SelectButton.gameObject.SetActive(true);
        }
    }
 
    public void LazerTurret2Buy()
    {
        if (money > LazerTurret2Price)
        {
            money -= LazerTurret2Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsLazerTurret2Buyed", 1);

            LazerTurret2BuyButton.gameObject.SetActive(false);
            LazerTurret2SelectButton.gameObject.SetActive(true);
        }
    }
    public void LazerTurret3Buy()
    {
        if (money > LazerTurret3Price)
        {
            money -= LazerTurret3Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsLazerTurret3Buyed", 1);

            LazerTurret3BuyButton.gameObject.SetActive(false);
            LazerTurret3SelectButton.gameObject.SetActive(true);
        }
    }
    public void LazerTurret4Buy()
    {
        if (money > LazerTurret4Price)
        {
            money -= LazerTurret4Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsLazerTurret4Buyed", 1);

            LazerTurret4BuyButton.gameObject.SetActive(false);
            LazerTurret4SelectButton.gameObject.SetActive(true);
        }
    }
    public void LazerTurret5Buy()
    {
        if (money > LazerTurret5Price)
        {
            money -= LazerTurret5Price;
            PlayerPrefs.SetFloat("Money", money);
            MoneyTMP.text = money.ToString();

            PlayerPrefs.SetInt("IsLazerTurret5Buyed", 1);

            LazerTurret5BuyButton.gameObject.SetActive(false);
            LazerTurret5SelectButton.gameObject.SetActive(true);
        }
    }
    #endregion




    #region PLAYER SELECT
    public void Player0Select()
    {
        PlayerButtonColorClear();
        Player0SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 0);

    }
    public void Player1Select()
    {

        PlayerButtonColorClear();
        Player1SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 1);

    }
    public void Player2Select()
    {
        PlayerButtonColorClear();
        Player2SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 2);

    }
    public void Player3Select()
    {
        PlayerButtonColorClear();
        Player3SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 3);

    }
    public void Player4Select()
    {
        PlayerButtonColorClear();
        Player4SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 4);

    }
    public void Player5Select()
    {
        PlayerButtonColorClear();
        Player5SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 5);

    }
    public void Player6Select()
    {
        PlayerButtonColorClear();
        Player6SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 6);

    }
    public void Player7Select()
    {
        PlayerButtonColorClear();
        Player7SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 7);

    }
    public void Player8Select()
    {
        PlayerButtonColorClear();
        Player8SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 8);

    }
    public void Player9Select()
    {
        PlayerButtonColorClear();
        Player9SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 9);

    }
    public void Player10Select()
    {
        PlayerButtonColorClear();
        Player10SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 10);

    }
    public void Player11Select()
    {
        PlayerButtonColorClear();
        Player11SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 11);

    }

    public void Player12Select()
    {
        PlayerButtonColorClear();
        Player12SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 12);

    }

    public void Player13Select()
    {
        PlayerButtonColorClear();
        Player13SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 13);

    }

    public void Player14Select()
    {
        PlayerButtonColorClear();
        Player14SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 14);

    }

    public void Player15Select()
    {
        PlayerButtonColorClear();
        Player15SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 15);

    }

    public void Player16Select()
    {
        PlayerButtonColorClear();
        Player16SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 16);

    }

    public void Player17Select()
    {
        PlayerButtonColorClear();
        Player17SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 17);

    }

    public void Player18Select()
    {
        PlayerButtonColorClear();
        Player18SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 18);

    }

    public void Player19Select()
    {
        PlayerButtonColorClear();
        Player19SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 19);

    }
    public void Player20Select()
    {
        PlayerButtonColorClear();
        Player20SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 20);

    }
    public void Player21Select()
    {
        PlayerButtonColorClear();
        Player21SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 21);

    }
    public void Player22Select()
    {
        PlayerButtonColorClear();
        Player22SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 22);

    }
    public void Player23Select()
    {
        PlayerButtonColorClear();
        Player23SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 23);

    }
    public void Player24Select()
    {
        PlayerButtonColorClear();
        Player24SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 24);

    }
    public void Player25Select()
    {
        PlayerButtonColorClear();
        Player25SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 25);

    }
    public void Player26Select()
    {
        PlayerButtonColorClear();
        Player26SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 26);

    }
    public void Player27Select()
    {
        PlayerButtonColorClear();
        Player27SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 27);

    }
    public void Player28Select()
    {
        PlayerButtonColorClear();
        Player28SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 28);

    }
    public void Player29Select()
    {
        PlayerButtonColorClear();
        Player29SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("PlayerSkin", 29);

    }




    #endregion

    #region BASÝC TURRET SELECT
    public void BasicTurret0Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret0SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 0);

    }
    public void BasicTurret1Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret1SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 1);

    }
    public void BasicTurret2Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret2SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 2);

    }
    public void BasicTurret3Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret3SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 3);

    }
    public void BasicTurret4Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret4SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 4);

    }
    public void BasicTurret5Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret5SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 5);

    }
    public void BasicTurret6Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret6SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 6);

    }
    public void BasicTurret7Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret7SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 7);

    }
    public void BasicTurret8Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret8SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 8);

    }
    public void BasicTurret9Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret9SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 9);

    }
    public void BasicTurret10Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret10SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 10);

    }
    public void BasicTurret11Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret11SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 11);

    }
    public void BasicTurret12Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret12SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 12);

    }
    public void BasicTurret13Select()
    {
        BasicTurretButtonColorClear();
        BasicTurret13SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("BasicTurretSkin", 13);

    }
    #endregion

    #region ADVANCED TURRET SELECT
    public void AdvancedTurret0Select()
    {
        AdvancedTurretButtonColorClear();
        AdvancedTurret0SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("AdvancedTurretSkin", 0);

    }
    public void AdvancedTurret1Select()
    {
        AdvancedTurretButtonColorClear();
        AdvancedTurret1SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("AdvancedTurretSkin", 1);

    }
    #endregion
    #region LAZER TURRET SELECT
    public void LazerTurret0Select()
    {
        LazerTurretButtonColorClear();
        LazerTurret0SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("LazerTurretSkin", 0);

    }
   
    public void LazerTurret1Select()
    {
        LazerTurretButtonColorClear();
        LazerTurret1SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("LazerTurretSkin", 1);

    }
    public void LazerTurret2Select()
    {
        LazerTurretButtonColorClear();
        LazerTurret2SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("LazerTurretSkin", 2);

    }
    public void LazerTurret3Select()
    {
        LazerTurretButtonColorClear();
        LazerTurret3SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("LazerTurretSkin", 3);

    }
    public void LazerTurret4Select()
    {
        LazerTurretButtonColorClear();
        LazerTurret4SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("LazerTurretSkin", 4);

    }
    public void LazerTurret5Select()
    {
        LazerTurretButtonColorClear();
        LazerTurret5SelectButton.GetComponent<Image>().color = new Color32(171, 131, 60, 255);

        PlayerPrefs.SetFloat("LazerTurretSkin", 5);

    }


    #endregion
    public void Paraekle()
    {
        money = PlayerPrefs.GetFloat("Money");
        money += 1000;
        PlayerPrefs.SetFloat("Money", money);
        MoneyTMP.text = money.ToString();
    }    




    void PlayerButtonColorClear()
    {
        Player0SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player1SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player2SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player3SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player4SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player5SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player6SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player7SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player8SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player9SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player10SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player11SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player12SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player13SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player14SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player15SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player16SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player17SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player18SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player19SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player20SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player21SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player22SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player23SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player24SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player25SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player26SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player27SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player28SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Player29SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
    }
    void BasicTurretButtonColorClear()
    {
        BasicTurret0SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret1SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret2SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret3SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret4SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret5SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret6SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret7SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret8SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret9SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret10SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret11SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret12SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        BasicTurret13SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);


    }
    void AdvancedTurretButtonColorClear()
    {
        AdvancedTurret0SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        AdvancedTurret1SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
    }
    void LazerTurretButtonColorClear()
    {
        LazerTurret0SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        LazerTurret1SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        LazerTurret2SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        LazerTurret3SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        LazerTurret4SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        LazerTurret5SelectButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
    }
}
