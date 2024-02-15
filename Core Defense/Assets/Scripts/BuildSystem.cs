using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using SaveLoadSystem;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


#region HELP
/*
 NASIL YENÝ BÝR BUÝLD OBJESÝ EKLENÝR
 0.1-) GUI KISMINA  GÝT VE BUTTON DEÐÝÞKEN EKLE
 0.2-)EÐER DRÝLL DEÐÝLSE LÝST BUÝLDÝNGE GÝT VE DEÐÝÞKEN EKLE
 1-) PRICE KISMINI AC VE BUILD OBJESININI UCRETINI GIR
 2-) GAMEOBJECT KISMINI AC VE BUILD OBJESININ GAMEOBJECT DEGISKENINI OLUSTUR 
 3-) CANBUILD KISMINI AC VE BUILD OBJESININ CANBUILD DEGISKENINI OLUSTUR 
 4-) SELECTITEM KISMINI AC VE BUILD OBJESININ SELECT ITEM DEGISKENINI OLUSTUR 
 5-) EÐER DRÝLL DEÐÝLSE REAL BUÝLD KISMINI AC VE ÜSTTEKÝNÝ KOPYALAYIP DEÐÝÞTÝR 
 6-) EÐER DRÝLL DEÐÝLSE CERCEVE KISMINI AC VE ÜSTTEKÝNÝ KOPYALAYIP DEÐÝÞTÝR 
 7-) EÐER DRÝLL DEÐÝLSE CANCEL ÝTEM ACTÝVE KISMINI AC VE ÝF KISMINA ÝTEMÝ EKLE
 8-) DESTROY KISMINI AC VE ÜSTTEKÝNÝ KOPYALAYIP DEÐÝÞTÝR 
 9-) BUILD KISMINI AC VE ÜSTTEKÝNÝ KOPYALAYIP DEÐÝÞTÝR 
 9-) SELECT ITEM FOMKSÝYONUN AC VE SELECT ÝTEM DEÐÝÞKENÝNÝ EKLE
 10-) YENÝ BÝR FONKSÝYON AÇ VE CREATE ÝÞLEMLERÝNÝ ÜSTTEKÝNDEN KOPYALAYIP DÜZENLE
 11-) FALSE AL SELECTED ITEM FONKSIYONUNA GEL VE SELECTED DEGISKENINI EKLE
 12-)BUTTON CLEAR FONKSIYONUNA GEL VE BUTON DEGISKENINI EKLE
 13-) EÐER DRÝLL DEÐÝLSE DESTROY ALL NOT BUILD KISMINI AC VE USTTEKINI KOPYALAYIP DUZENLE



 */
#endregion


public class BuildSystem : MonoBehaviour,ISaveable
{
    
    public DontBuild DontBuild;

    string sceneName;


    public static class MouseOverUILayerObject
    {
        public static bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.layer == 5) //5 = UI layer
                {
                    return true;
                }
            }

            return false;
        }
    }

    
    //public static BuildSystem Instance { private set; get; }
 
    //Ray2D DataPointer;
    //RaycastHit2D DataPointerHit;

    #region VARIABLE LIST BUILDING 
    public List<GameObject> ListBuildingGameObjectsWoodenDrill;
    public List<GameObject> ListBuildingGameObjectsWoodenTurret;
    public List<GameObject> ListBuildingGameObjectsHealthRegen;
    public List<GameObject> ListBuildingGameObjectsCoalToElectric;
    public List<GameObject> ListBuildingGameObjectsFactory;
    public List<GameObject> ListBuildingGameObjectsIronWall;
    public List<GameObject> ListBuildingGameObjectsElectricTurret;
    public List<GameObject> ListBuildingGameObjectsBigHealthRegen;
    public List<GameObject> ListBuildingGameObjectsAdvancedTurret;
    public List<GameObject> ListBuildingGameObjectsLaserTurret;
    public List<GameObject> ListBuildingGameObjectsMortarTurret;
    public List<GameObject> ListBuildingGameObjectsUraniumToElectric;
    public List<GameObject> ListBuildingGameObjectsAdvancedUraniumTurret;
    public List<GameObject> ListBuildingGameObjectsMortarUraniumTurret;
    public List<GameObject> ListBuildingGameObjectsLaserUraniumTurret;
    public List<GameObject> ListBuildingGameObjectsSteelWall;
    public List<GameObject> ListBuildingGameObjectsUraniumWall;

    #endregion


    private GameObject Factorymngr;
    public float grid = 0.15f;
    float xGrid = 0f, yGrid = 0f;

    public AudioSource BuildSE;

    #region VARIABLE GUI
    [Header("GUI")]
    public Image DrillsImage;
    public Image BasicMachineImage;
    public Image TurretsImage;
    public Image ElectricImage;
    public Image WallsImage;
    public Image InfoCanvas;
    public TextMeshProUGUI Irontxt;

    public Button CancelButton;
    public Button WoodenTurretButton;
    public Button WoodenDrillButton;
    public Button HealthRegenButton;
    public Button CoaltoElectricButton;
    public Button BulletMachineButton;
    public Button IronWallButton;
    public Button MoveButton;
    public Button DestroyButton;
    public Button BuildButton;
    public Button IronDrillButton;
    public Button ElectricDrillButton;
    public Button ElectricTurretButton;
    public Button BigHealthRegenButton;
    public Button AdvancedTurretButton;
    public Button LaserTurretButton;
    public Button MortarTurretButton;
    public Button UraniumToelectricButton;
    public Button AdvancedUraniumTurretButton;
    public Button MortarUraniumTurretButton;
    public Button LaserUraniumTurretButton;
    public Button SteelWallButton;
    public Button UraniumWallButton;
    public Button UraniumDrillButton;

    #endregion


    #region VARIABLE BALANCE
    [Header("BALANCE")]
    public float Money = 0;
    public float CoalBalance = 0;
    public float IronBalance = 300;
    public float CopperBalance = 0;
    public float UraniumBalance = 0;
    public float ElectricBalance = 0;
    public float PowderBalance = 0;
    public float BulletBalance = 25;
    public float IronBarBalance = 0;
    public float GearBalance = 0;
    public float CopperWireBalance = 0;
    public float CircuitBoardBalance = 0;
    public float SteelBalance = 0;
    public float MortarBulletBalance = 0;
    public float AdvancedCircuitBoardBalance = 0;
    #endregion


    #region VARIABLE PRICE
    [Header("PRÝCE")]
    public int woodenDrillPrice = 100;
    public int woodenTurretPrice = 40;
    public int HealthRegenPrice = 400;
    public int CoaltoElectricPrice = 500;
    public int FactoryPrice = 150;
    public float IronWallPrice = 50;
    public float IronDrillPrice = 100;
    public float ElectricDrillPrice = 200;
    public float ElectricTurretPrice = 300;
    public float BigHealthRegenPrice = 850;
    public float AdvancedTurretPrice = 100;
    public float LaserTurretPrice = 400;
    public float MortarTurretPrice = 400;
    public float UraniumToelectricPrice = 600;
    public float AdvancedUraniumTurretPrice = 400;
    public float MortarUraniumTurretPrice = 500;
    



    [Header("IRON BAR PRÝCE")]
    public int woodenTurretIronBarPrice = 20;
    public int IronDrillIronBarPrice = 60;
    public int ElectricDrillIronBarPrice = 90;
    public int ElectricTurretIronBarPrice = 50;
    public int AdvancedTurretIronBarPrice = 40;
    public int LaserTurretIronBarPrice = 80;
    public int MortarTurretIronBarPrice = 120;
    public int AdvancedUraniumTurretIronBarPrice = 120;
    public int MortarUraniumTurretIronBarPrice = 60;
    public int LaserUraniumTurretIronBarPrice = 80;
    



    [Header("GEAR PRÝCE")]
    public int woodenTurretGearPrice = 20;
    public int IronDrillGearPrice = 60;
    public int ElectricDrillGearPrice = 90;
    public int ElectricTurretGearPrice = 50;
    public int AdvancedTurretGearPrice = 40;
    public int LaserTurretGearPrice = 30;
    public int MortarTurretGearPrice = 30;

    [Header("COPPER WÝRE PRÝCE")]
    public int CoaltoElectricCopperWirePrice = 40;
    public int HealthRegenCopperWirePrice = 10;
    public int ElectricDrillCopperWirePrice = 30;
    public int ElectricTurretCopperWirePrice = 40;
    public int BigHealthRegenCopperWirePrice = 25;
    public int UraniumToelectricCopperWirePrice = 60;
    


    [Header("CIRCUIT BOARD PRÝCE")]
    public int CoaltoElectricCircuitBoardPrice = 20;
    public int HealthRegenCircuitBoardPrice = 5;
    public int ElectricDrillCircuitBoardPrice = 10;
    public int ElectricTurretCircuitBoardPrice = 10;
    public int BigHealthRegenCircuitBoardPrice = 15;
    public int LaserTurretCircuitBoardPrice = 15;
    public int UraniumToelectricCircuitBoardPrice = 30;
    public int LaserUraniumTurretCircuitBoardPrice = 50;
    

    [Header("STEEL PRÝCE")]
    public int LaserTurretSteelPrice = 20;
    public int MortarTurretSteelPrice = 30;
    public int UraniumToelectricSteelPrice = 50;
    public int AdvancedUraniumTurretSteelPrice = 50;
    public int MortarUraniumTurretSteelPrice = 75;
    public int LaserUraniumTurretSteelPrice = 75;
    public int SteelWallSteelPrice = 12;
    public int UraniumDrillSteelPrice = 20;

    [Header("URANIUM PRÝCE")]
    public int AdvancedUraniumTurretUraniumPrice = 50;
    public int MortarUraniumTurretUraniumPrice = 70;
    public int LaserUraniumTurretUraniumPrice = 30;
    public int UraniumWallUraniumPrice = 30;
    public int UraniumDrillUraniumPrice = 60;

    [Header("ADVANCED CIRCUIT BOARD PRÝCE")]    
    public int LaserUraniumTurretAdvancedCircuitBoardPrice = 20;
    public int UraniumDrillAdvancedCircuitBoardPrice = 35;

    #endregion


    #region VARIABLE GAMEOBJECT
    [Header("GAMEOBJECT")]
    public GameObject HealthRegen;
    public GameObject WoodenDrill;
    public GameObject WoodenTurret;
    public GameObject CoaltoElectric;
    public GameObject Factory;
    public GameObject IronWall;
    public GameObject IronDrill;
    public GameObject ElectricDrill;
    public GameObject ElectricTurret;
    public GameObject BigHealthRegen;
    public GameObject AdvancedTurret;
    public GameObject LaserTurret;
    public GameObject MortarTurret;
    public GameObject UraniumToelectric;
    public GameObject AdvancedUraniumTurret;
    public GameObject MortarUraniumTurret;
    public GameObject LaserUraniumTurret;
    public GameObject SteelWall;
    public GameObject UraniumWall;
    public GameObject UraniumDrill;
    #endregion


    #region VARIABLE CAN BUILD

    bool canBuildDrill = false;
    bool canBuildHealthRegen = false;
    bool canBuildCoaltoElectric = false;
    bool canBuildTurret = false;
    bool canBuildFactory = false;
    bool canBuildIronWall = false;
    bool canBuildIronDrill = false;
    bool canBuildElectricDrill = false;
    bool canBuildElectricTurret = false;
    bool canBuildBigHealthRegen = false;
    bool canBuildAdvancedTurret = false;
    bool canBuildLaserTurret = false;
    bool canBuildMortarTurret = false;
    bool canBuildUraniumToelectric = false;
    bool canBuildAdvancedUraniumTurret= false;
    bool canBuildMortarUraniumTurret= false;
    bool canBuildLaserUraniumTurret= false;
    bool canBuildSteelWall= false;
    bool canBuildUraniumWall= false;
    bool canBuildUraniumDrill= false;

    #endregion


    #region VARIABLE SELECT ITEM

    bool selectItemWoodenDrill = false;
    bool selectItemWoodenTurret = false;
    bool selectItemHealthRegen = false;
    bool selectItemCoaltoElectric = false;
    bool selectItemFactory = false;
    bool selectItemIronWall = false;
    bool selectItemIronDrill = false;
    bool selectItemElectricDrill = false;
    bool selectItemElectricTurret = false;
    bool selectItemBigHealthRegen = false;
    bool selectItemAdvancedTurret = false;
    bool selectItemLaserTurret = false;
    bool selectItemMortarTurret = false;
    bool selectItemUraniumToelectric = false;
    bool selectItemAdvancedUraniumTurret= false;
    bool selectItemMortarUraniumTurret= false;
    bool selectItemLaserUraniumTurret= false;
    bool selectItemSteelWall= false;
    bool selectItemUraniumWall= false;
    bool selectItemUraniumDrill= false;

    #endregion


    #region VARIABLE OTHER
    private GameObject created;
    public GameObject Iron;
    public GameObject[] clicked;
    public GameObject Player;
    public ParticleSystem PlayerBornEffect;
    private GameObject Build;

    //bool selectitem = false;
    bool Destroyitem = false;
    public static bool Moveitem = false;
    public static bool Builditem = false;

    private bool BuilditemIronWall = false;
    #endregion


    [System.Serializable]
    struct BuildData
    {
        public float CoalBalance;
        public float IronBalance;
        public float CopperBalance;
        public float UraniumBalance;
        public float ElectricBalance;
        public float PowderBalance;
        public float BulletBalance;
        public float IronBarBalance;
        public float GearBalance;
        public float CopperWireBalance;
        public float CircuitBoardBalance;
        public float SteelBalance;
        public float MortarBulletBalance;
        public float AdvancedCircuitBoardBalance;

    }

    public static BuildSystem Instance { get; private set; }
    private void Awake()
    {
        
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {

        

        #region WhichLVL
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        switch (sceneName)
        {
            case "SampleScene": PlayerPrefs.SetInt("WhichLvl", 1); break;
            case "LVL2": PlayerPrefs.SetInt("WhichLvl", 2); break;
            case "LVL3": PlayerPrefs.SetInt("WhichLvl", 3); break;
            case "LVL4": PlayerPrefs.SetInt("WhichLvl", 4); break;

            default:
                break;
        }
        #endregion




        PlayerBornEffect.Play();
        EventSystem.current.IsPointerOverGameObject(0);




        CancelButton.gameObject.SetActive(false);
        TurretsImage.gameObject.SetActive(false);
        BasicMachineImage.gameObject.SetActive(false);
        DrillsImage.gameObject.SetActive(false);
        ElectricImage.gameObject.SetActive(false);
        WallsImage.gameObject.SetActive(false);

        //Irontxt.text = IronBalance.ToString();

    }

    // Update is called once per frame
    void Update()

    {
        Debug.Log("Hi",this);
        
        #region REAL BUÝLD
        // -------------------------------REAL BUÝLD----------------------------

        //WOODEN DRÝLL
        if (Builditem == true)
        {


            // WOODEN TURRET
            if (ListBuildingGameObjectsWoodenTurret != null)
            {
                if (ListBuildingGameObjectsWoodenTurret.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsWoodenTurret.Count; i++)
                    {
                        if (ListBuildingGameObjectsWoodenTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > woodenTurretPrice && IronBarBalance > woodenTurretIronBarPrice && GearBalance > woodenTurretGearPrice)
                            {
                                IronBalance -= woodenTurretPrice;
                                IronBarBalance -= woodenTurretIronBarPrice;
                                GearBalance -= woodenTurretGearPrice;

                                ListBuildingGameObjectsWoodenTurret[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);//turretýn floor ve guný görünür yapar
                                ListBuildingGameObjectsWoodenTurret[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                                ListBuildingGameObjectsWoodenTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar

                                ListBuildingGameObjectsWoodenTurret[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsWoodenTurret[i].gameObject.GetComponent<Dragger>().Isbuilded = true;//real builded true olur

                                ListBuildingGameObjectsWoodenTurret.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }

            // HEALTHREGEN
            if (ListBuildingGameObjectsHealthRegen != null)
            {
                if (ListBuildingGameObjectsHealthRegen.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsHealthRegen.Count; i++)
                    {
                        if (ListBuildingGameObjectsHealthRegen[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > HealthRegenPrice && CopperWireBalance > HealthRegenCopperWirePrice && CircuitBoardBalance > HealthRegenCircuitBoardPrice)
                            {
                                IronBalance -= HealthRegenPrice;
                                CopperWireBalance -= HealthRegenCopperWirePrice;
                                CircuitBoardBalance -= HealthRegenCircuitBoardPrice;

                                ListBuildingGameObjectsHealthRegen[i].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

                                ListBuildingGameObjectsHealthRegen[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi true yapar

                                ListBuildingGameObjectsHealthRegen[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsHealthRegen[i].gameObject.GetComponent<Dragger>().Isbuilded = true;

                                //-----DATA-----
                                //DataSelectObject = ListBuildingGameObjectsHealthRegen[i].gameObject;
                                //-----DATA-----

                                ListBuildingGameObjectsHealthRegen.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }

            // COALTOELECTRÝC
            if (ListBuildingGameObjectsCoalToElectric != null)
            {
                if (ListBuildingGameObjectsCoalToElectric.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsCoalToElectric.Count; i++)
                    {
                        if (ListBuildingGameObjectsCoalToElectric[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > CoaltoElectricPrice && CopperWireBalance > CoaltoElectricCopperWirePrice && CircuitBoardBalance > CoaltoElectricCircuitBoardPrice)
                            {
                                IronBalance -= CoaltoElectricPrice;
                                CopperWireBalance -= CoaltoElectricCopperWirePrice;
                                CircuitBoardBalance -= CoaltoElectricCircuitBoardPrice;

                                ListBuildingGameObjectsCoalToElectric[i].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

                                ListBuildingGameObjectsCoalToElectric[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi true yapar

                                ListBuildingGameObjectsCoalToElectric[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsCoalToElectric[i].gameObject.GetComponent<Dragger>().Isbuilded = true;

                                ListBuildingGameObjectsCoalToElectric.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }

            // FACTORY
            if (ListBuildingGameObjectsFactory != null)
            {
                if (ListBuildingGameObjectsFactory.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsFactory.Count; i++)
                    {
                        if (ListBuildingGameObjectsFactory[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > FactoryPrice)
                            {
                                IronBalance -= FactoryPrice;
                                ListBuildingGameObjectsFactory[i].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);



                                ListBuildingGameObjectsFactory[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi true yapar

                                ListBuildingGameObjectsFactory[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsFactory[i].gameObject.GetComponent<Dragger>().Isbuilded = true;

                                ListBuildingGameObjectsFactory.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }
            // IRONWALL
            if (ListBuildingGameObjectsIronWall != null)
            {


                for (int i = 0; i < ListBuildingGameObjectsIronWall.Count; i++)
                {

                    if (ListBuildingGameObjectsIronWall[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        if (IronBalance > IronWallPrice)
                        {
                            IronBalance -= IronWallPrice;
                            ListBuildingGameObjectsIronWall[i].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                            ListBuildingGameObjectsIronWall[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi true yapar

                            ListBuildingGameObjectsIronWall[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                            ListBuildingGameObjectsIronWall[i].gameObject.GetComponent<Dragger>().Isbuilded = true;

                            ListBuildingGameObjectsIronWall.RemoveAt(i);

                            i--;



                        }
                    }
                }



            }

            // ELECTRIC TURRET
            if (ListBuildingGameObjectsElectricTurret != null)
            {
                if (ListBuildingGameObjectsElectricTurret.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsElectricTurret.Count; i++)
                    {
                        if (ListBuildingGameObjectsElectricTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > ElectricTurretPrice && IronBarBalance > ElectricTurretIronBarPrice && GearBalance > ElectricTurretGearPrice && CopperWireBalance > ElectricTurretCopperWirePrice && CircuitBoardBalance > ElectricTurretCircuitBoardPrice)
                            {
                                IronBalance -= ElectricTurretPrice;
                                IronBarBalance -= ElectricTurretIronBarPrice;
                                GearBalance -= ElectricTurretGearPrice;
                                CopperWireBalance -= ElectricTurretCopperWirePrice;
                                CircuitBoardBalance-= ElectricTurretCircuitBoardPrice;

                                ListBuildingGameObjectsElectricTurret[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);//turretýn floor ve guný görünür yapar
                                ListBuildingGameObjectsElectricTurret[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                                ListBuildingGameObjectsElectricTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar

                                ListBuildingGameObjectsElectricTurret[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsElectricTurret[i].gameObject.GetComponent<Dragger>().Isbuilded = true;//real builded true olur

                                ListBuildingGameObjectsElectricTurret.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }

            // BIG HEALTH REGEN
            if (ListBuildingGameObjectsBigHealthRegen != null)
            {
                if (ListBuildingGameObjectsBigHealthRegen.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsBigHealthRegen.Count; i++)
                    {
                        if (ListBuildingGameObjectsBigHealthRegen[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > BigHealthRegenPrice && CopperWireBalance > BigHealthRegenCopperWirePrice && CircuitBoardBalance > BigHealthRegenCircuitBoardPrice)
                            {
                                IronBalance -= BigHealthRegenPrice;                               
                                CopperWireBalance -= BigHealthRegenCopperWirePrice;
                                CircuitBoardBalance -= BigHealthRegenCircuitBoardPrice;

                                ListBuildingGameObjectsBigHealthRegen[i].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                                ListBuildingGameObjectsBigHealthRegen[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar

                                ListBuildingGameObjectsBigHealthRegen[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsBigHealthRegen[i].gameObject.GetComponent<Dragger>().Isbuilded = true;//real builded true olur

                                ListBuildingGameObjectsBigHealthRegen.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }
            // ADVANCED TURRET
            if (ListBuildingGameObjectsAdvancedTurret != null)
            {
                if (ListBuildingGameObjectsAdvancedTurret.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsAdvancedTurret.Count; i++)
                    {
                        if (ListBuildingGameObjectsAdvancedTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > AdvancedTurretPrice && IronBarBalance > AdvancedTurretIronBarPrice && GearBalance > AdvancedTurretGearPrice)
                            {
                                IronBalance -= AdvancedTurretPrice;
                                IronBarBalance -= AdvancedTurretIronBarPrice;
                                GearBalance -= AdvancedTurretGearPrice;

                                ListBuildingGameObjectsAdvancedTurret[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);//turretýn floor ve guný görünür yapar
                                ListBuildingGameObjectsAdvancedTurret[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                                ListBuildingGameObjectsAdvancedTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar

                                ListBuildingGameObjectsAdvancedTurret[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsAdvancedTurret[i].gameObject.GetComponent<Dragger>().Isbuilded = true;//real builded true olur

                                ListBuildingGameObjectsAdvancedTurret.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }

            // LASER TURRET
            if (ListBuildingGameObjectsLaserTurret != null)
            {
                if (ListBuildingGameObjectsLaserTurret.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsLaserTurret.Count; i++)
                    {
                        if (ListBuildingGameObjectsLaserTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > LaserTurretPrice && IronBarBalance > LaserTurretIronBarPrice && GearBalance > LaserTurretGearPrice && SteelBalance > LaserTurretSteelPrice && CircuitBoardBalance > LaserTurretCircuitBoardPrice)
                            {
                                IronBalance -= LaserTurretPrice;
                                IronBarBalance -= LaserTurretIronBarPrice;
                                GearBalance -= LaserTurretGearPrice;
                                SteelBalance -= LaserTurretSteelPrice;
                                CircuitBoardBalance -= LaserTurretCircuitBoardPrice;

                                ListBuildingGameObjectsLaserTurret[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);//turretýn floor ve guný görünür yapar
                                ListBuildingGameObjectsLaserTurret[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                                ListBuildingGameObjectsLaserTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar

                                ListBuildingGameObjectsLaserTurret[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsLaserTurret[i].gameObject.GetComponent<Dragger>().Isbuilded = true;//real builded true olur

                                ListBuildingGameObjectsLaserTurret.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }
            // Mortar TURRET
            if (ListBuildingGameObjectsMortarTurret != null)
            {
                if (ListBuildingGameObjectsMortarTurret.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsMortarTurret.Count; i++)
                    {
                        if (ListBuildingGameObjectsMortarTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > MortarTurretPrice && IronBarBalance > MortarTurretIronBarPrice && GearBalance > MortarTurretGearPrice && SteelBalance > MortarTurretSteelPrice )
                            {
                                IronBalance -= MortarTurretPrice;
                                IronBarBalance -= MortarTurretIronBarPrice;
                                GearBalance -= MortarTurretGearPrice;
                                SteelBalance -= MortarTurretSteelPrice;
                               

                                ListBuildingGameObjectsMortarTurret[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);//turretýn floor ve guný görünür yapar
                                ListBuildingGameObjectsMortarTurret[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                                ListBuildingGameObjectsMortarTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar

                                ListBuildingGameObjectsMortarTurret[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsMortarTurret[i].gameObject.GetComponent<Dragger>().Isbuilded = true;//real builded true olur

                                ListBuildingGameObjectsMortarTurret.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }
            // URANIUM TO ELECTRIC
            if (ListBuildingGameObjectsUraniumToElectric != null)
            {
                if (ListBuildingGameObjectsUraniumToElectric.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsUraniumToElectric.Count; i++)
                    {
                        if (ListBuildingGameObjectsUraniumToElectric[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > UraniumToelectricPrice && CopperWireBalance > UraniumToelectricCopperWirePrice && CircuitBoardBalance > UraniumToelectricCircuitBoardPrice && SteelBalance > UraniumToelectricSteelPrice)
                            {
                                IronBalance -= UraniumToelectricPrice;
                                CopperWireBalance -= UraniumToelectricCopperWirePrice;
                                CircuitBoardBalance -= UraniumToelectricCircuitBoardPrice;
                                SteelBalance -= UraniumToelectricSteelPrice;

                                ListBuildingGameObjectsUraniumToElectric[i].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);



                                ListBuildingGameObjectsUraniumToElectric[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi true yapar

                                ListBuildingGameObjectsUraniumToElectric[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsUraniumToElectric[i].gameObject.GetComponent<Dragger>().Isbuilded = true;

                                ListBuildingGameObjectsUraniumToElectric.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }
            // ADVANCED URANIUM TURRET
            if (ListBuildingGameObjectsAdvancedUraniumTurret != null)
            {
                if (ListBuildingGameObjectsAdvancedUraniumTurret.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsAdvancedUraniumTurret.Count; i++)
                    {
                        if (ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > AdvancedUraniumTurretPrice && IronBarBalance > AdvancedUraniumTurretIronBarPrice && UraniumBalance> AdvancedUraniumTurretUraniumPrice&& SteelBalance > AdvancedUraniumTurretSteelPrice)
                            {
                                IronBalance -= AdvancedUraniumTurretPrice;
                                IronBarBalance -= AdvancedUraniumTurretIronBarPrice;
                                UraniumBalance -= AdvancedUraniumTurretUraniumPrice;
                                SteelBalance -= AdvancedUraniumTurretSteelPrice;


                                ListBuildingGameObjectsAdvancedUraniumTurret[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);//turretýn floor ve guný görünür yapar
                                ListBuildingGameObjectsAdvancedUraniumTurret[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                                ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar

                                ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.GetComponent<Dragger>().Isbuilded = true;//real builded true olur

                                ListBuildingGameObjectsAdvancedUraniumTurret.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }
            // ADVANCED URANIUM TURRET
            if (ListBuildingGameObjectsMortarUraniumTurret != null)
            {
                if (ListBuildingGameObjectsMortarUraniumTurret.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsMortarUraniumTurret.Count; i++)
                    {
                        if (ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBalance > MortarUraniumTurretPrice && IronBarBalance > MortarUraniumTurretIronBarPrice && UraniumBalance > MortarUraniumTurretUraniumPrice && SteelBalance > MortarUraniumTurretSteelPrice)
                            {
                                IronBalance -= MortarUraniumTurretPrice;
                                IronBarBalance -= MortarUraniumTurretIronBarPrice;
                                UraniumBalance -= MortarUraniumTurretUraniumPrice;
                                SteelBalance -= MortarUraniumTurretSteelPrice;


                                ListBuildingGameObjectsMortarUraniumTurret[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);//turretýn floor ve guný görünür yapar
                                ListBuildingGameObjectsMortarUraniumTurret[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                                ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar

                                ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.GetComponent<Dragger>().Isbuilded = true;//real builded true olur

                                ListBuildingGameObjectsMortarUraniumTurret.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }
            // ADVANCED URANIUM TURRET
            if (ListBuildingGameObjectsLaserUraniumTurret != null)
            {
                if (ListBuildingGameObjectsLaserUraniumTurret.Count > 0)
                {


                    for (int i = 0; i < ListBuildingGameObjectsLaserUraniumTurret.Count; i++)
                    {
                        if (ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                        {

                            if (IronBarBalance > LaserUraniumTurretIronBarPrice && UraniumBalance > LaserUraniumTurretUraniumPrice && SteelBalance > LaserUraniumTurretSteelPrice && CircuitBoardBalance > LaserUraniumTurretCircuitBoardPrice && AdvancedCircuitBoardBalance > LaserUraniumTurretAdvancedCircuitBoardPrice)
                            {
                                
                                IronBarBalance -= LaserUraniumTurretIronBarPrice;
                                CircuitBoardBalance -= LaserUraniumTurretCircuitBoardPrice;
                                UraniumBalance -= LaserUraniumTurretUraniumPrice;
                                SteelBalance -= LaserUraniumTurretSteelPrice;
                                AdvancedCircuitBoardBalance -= LaserUraniumTurretAdvancedCircuitBoardPrice;


                                ListBuildingGameObjectsLaserUraniumTurret[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);//turretýn floor ve guný görünür yapar
                                ListBuildingGameObjectsLaserUraniumTurret[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                                ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar

                                ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                                ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.GetComponent<Dragger>().Isbuilded = true;//real builded true olur

                                ListBuildingGameObjectsLaserUraniumTurret.RemoveAt(i);

                                i--;
                            }
                        }


                    }

                }
            }
            // Steel WALL
            if (ListBuildingGameObjectsSteelWall != null)
            {


                for (int i = 0; i < ListBuildingGameObjectsSteelWall.Count; i++)
                {

                    if (ListBuildingGameObjectsSteelWall[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        if (SteelBalance > SteelWallSteelPrice)
                        {
                            SteelBalance -= SteelWallSteelPrice;
                            ListBuildingGameObjectsSteelWall[i].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                            ListBuildingGameObjectsSteelWall[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi true yapar

                            ListBuildingGameObjectsSteelWall[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                            ListBuildingGameObjectsSteelWall[i].gameObject.GetComponent<Dragger>().Isbuilded = true;

                            ListBuildingGameObjectsSteelWall.RemoveAt(i);

                            i--;



                        }
                    }
                }



            }
            // URANIUM WALL
            if (ListBuildingGameObjectsUraniumWall != null)
            {


                for (int i = 0; i < ListBuildingGameObjectsUraniumWall.Count; i++)
                {

                    if (ListBuildingGameObjectsUraniumWall[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        if (UraniumBalance > UraniumWallUraniumPrice)
                        {
                            UraniumBalance -= UraniumWallUraniumPrice;
                            ListBuildingGameObjectsUraniumWall[i].gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);


                            ListBuildingGameObjectsUraniumWall[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi true yapar

                            ListBuildingGameObjectsUraniumWall[i].gameObject.GetComponent<BuildCloses>().enabled = true;//build closes scriptini true yapar

                            ListBuildingGameObjectsUraniumWall[i].gameObject.GetComponent<Dragger>().Isbuilded = true;

                            ListBuildingGameObjectsUraniumWall.RemoveAt(i);

                            i--;



                        }
                    }
                }



            }


            Builditem = false;
        }
       

        #endregion


        #region CERCEVE
        //---------------------------------------------------ÇERÇEVE DEÐÝÞTÝRME-----------------------------------------------



        //Wooden Turret
        if (ListBuildingGameObjectsWoodenTurret != null)
        {
            if (ListBuildingGameObjectsWoodenTurret.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsWoodenTurret.Count; i++)
                {
                    if (ListBuildingGameObjectsWoodenTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsWoodenTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsWoodenTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsWoodenTurret[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsWoodenTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsWoodenTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }


        //HEALTH REGEN
        if (ListBuildingGameObjectsHealthRegen != null)
        {
            if (ListBuildingGameObjectsHealthRegen.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsHealthRegen.Count; i++)
                {
                    if (ListBuildingGameObjectsHealthRegen[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsHealthRegen[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsHealthRegen[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsHealthRegen[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsHealthRegen[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsHealthRegen[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //COAL TO ELECTRÝC
        if (ListBuildingGameObjectsCoalToElectric != null)
        {
            if (ListBuildingGameObjectsCoalToElectric.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsCoalToElectric.Count; i++)
                {
                    if (ListBuildingGameObjectsCoalToElectric[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsCoalToElectric[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsCoalToElectric[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsCoalToElectric[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsCoalToElectric[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsCoalToElectric[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //FACTORY
        if (ListBuildingGameObjectsFactory != null)
        {
            if (ListBuildingGameObjectsFactory.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsFactory.Count; i++)
                {
                    if (ListBuildingGameObjectsFactory[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsFactory[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsFactory[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsFactory[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsFactory[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsFactory[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //IRONWALL
        if (ListBuildingGameObjectsIronWall != null)
        {
            if (ListBuildingGameObjectsIronWall.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsIronWall.Count; i++)
                {
                    if (ListBuildingGameObjectsIronWall[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsIronWall[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsIronWall[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsIronWall[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsIronWall[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsIronWall[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //ELECTRÝC TURRET
        if (ListBuildingGameObjectsElectricTurret != null)
        {
            if (ListBuildingGameObjectsElectricTurret.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsElectricTurret.Count; i++)
                {
                    if (ListBuildingGameObjectsElectricTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsElectricTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsElectricTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsElectricTurret[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsElectricTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsElectricTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }

        //BÝG HEALTH REGEN
        if (ListBuildingGameObjectsBigHealthRegen != null)
        {
            if (ListBuildingGameObjectsBigHealthRegen.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsBigHealthRegen.Count; i++)
                {
                    if (ListBuildingGameObjectsBigHealthRegen[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsBigHealthRegen[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsBigHealthRegen[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsBigHealthRegen[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsBigHealthRegen[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsBigHealthRegen[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //ADVANCED TURRET
        if (ListBuildingGameObjectsAdvancedTurret != null)
        {
            if (ListBuildingGameObjectsAdvancedTurret.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsAdvancedTurret.Count; i++)
                {
                    if (ListBuildingGameObjectsAdvancedTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsAdvancedTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsAdvancedTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsAdvancedTurret[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsAdvancedTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsAdvancedTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //LASER TURRET
        if (ListBuildingGameObjectsLaserTurret != null)
        {
            if (ListBuildingGameObjectsLaserTurret.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsLaserTurret.Count; i++)
                {
                    if (ListBuildingGameObjectsLaserTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsLaserTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsLaserTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsLaserTurret[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsLaserTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsLaserTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //Mortar TURRET
        if (ListBuildingGameObjectsMortarTurret != null)
        {
            if (ListBuildingGameObjectsMortarTurret.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsMortarTurret.Count; i++)
                {
                    if (ListBuildingGameObjectsMortarTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsMortarTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsMortarTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsMortarTurret[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsMortarTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsMortarTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //URANIUM TO ELECTRIC
        if (ListBuildingGameObjectsUraniumToElectric != null)
        {
            if (ListBuildingGameObjectsUraniumToElectric.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsUraniumToElectric.Count; i++)
                {
                    if (ListBuildingGameObjectsUraniumToElectric[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsUraniumToElectric[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsUraniumToElectric[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsUraniumToElectric[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsUraniumToElectric[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsUraniumToElectric[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //ADVANCED URANIUM TURRET
        if (ListBuildingGameObjectsAdvancedUraniumTurret != null)
        {
            if (ListBuildingGameObjectsAdvancedUraniumTurret.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsAdvancedUraniumTurret.Count; i++)
                {
                    if (ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //MORTAR URANIUM TURRET
        if (ListBuildingGameObjectsMortarUraniumTurret != null)
        {
            if (ListBuildingGameObjectsMortarUraniumTurret.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsMortarUraniumTurret.Count; i++)
                {
                    if (ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsMortarUraniumTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //LASER URANIUM TURRET
        if (ListBuildingGameObjectsLaserUraniumTurret != null)
        {
            if (ListBuildingGameObjectsLaserUraniumTurret.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsLaserUraniumTurret.Count; i++)
                {
                    if (ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsLaserUraniumTurret[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //STEELWALL
        if (ListBuildingGameObjectsSteelWall != null)
        {
            if (ListBuildingGameObjectsSteelWall.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsSteelWall.Count; i++)
                {
                    if (ListBuildingGameObjectsSteelWall[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsSteelWall[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsSteelWall[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsSteelWall[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsSteelWall[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsSteelWall[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        //URANIUM WALL
        if (ListBuildingGameObjectsUraniumWall != null)
        {
            if (ListBuildingGameObjectsUraniumWall.Count > 0)
            {


                for (int i = 0; i < ListBuildingGameObjectsUraniumWall.Count; i++)
                {
                    if (ListBuildingGameObjectsUraniumWall[i].gameObject.GetComponent<Dragger>().blocked == false)
                    {
                        ListBuildingGameObjectsUraniumWall[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);//kýrmýzý cerceveyi false yapar
                        ListBuildingGameObjectsUraniumWall[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);//sarý cerceveyi true yapar

                    }
                    else if (ListBuildingGameObjectsUraniumWall[i].gameObject.GetComponent<Dragger>().blocked == true)
                    {
                        ListBuildingGameObjectsUraniumWall[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);//sarý cerceveyi false yapar
                        ListBuildingGameObjectsUraniumWall[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);//kýrmýzý cerceveyi true yapar

                    }

                }
            }
        }
        #endregion


        #region CANCEL ITEM ACTIVE
        //---------------------------------------------------CANCEL ÝTEM ACTÝVE  -----------------------------------------------

        if (ListBuildingGameObjectsCoalToElectric != null || ListBuildingGameObjectsFactory != null || ListBuildingGameObjectsHealthRegen != null || ListBuildingGameObjectsIronWall != null || ListBuildingGameObjectsWoodenTurret != null || ListBuildingGameObjectsElectricTurret != null || ListBuildingGameObjectsBigHealthRegen != null || ListBuildingGameObjectsAdvancedTurret != null || ListBuildingGameObjectsLaserTurret!= null || ListBuildingGameObjectsMortarTurret!= null || ListBuildingGameObjectsUraniumToElectric != null || ListBuildingGameObjectsAdvancedUraniumTurret != null || ListBuildingGameObjectsMortarUraniumTurret != null || ListBuildingGameObjectsLaserUraniumTurret != null || ListBuildingGameObjectsSteelWall!= null || ListBuildingGameObjectsUraniumWall!= null)
        {
            if (ListBuildingGameObjectsCoalToElectric.Count > 0 || ListBuildingGameObjectsFactory.Count > 0 || ListBuildingGameObjectsHealthRegen.Count > 0 || ListBuildingGameObjectsIronWall.Count > 0 || ListBuildingGameObjectsWoodenTurret.Count > 0 || ListBuildingGameObjectsElectricTurret.Count > 0 || ListBuildingGameObjectsBigHealthRegen.Count > 0 || ListBuildingGameObjectsAdvancedTurret.Count > 0 || ListBuildingGameObjectsLaserTurret.Count > 0 || ListBuildingGameObjectsMortarTurret.Count > 0 || ListBuildingGameObjectsUraniumToElectric.Count > 0 || ListBuildingGameObjectsAdvancedUraniumTurret.Count > 0 || ListBuildingGameObjectsMortarUraniumTurret.Count > 0 || ListBuildingGameObjectsLaserUraniumTurret.Count > 0 || ListBuildingGameObjectsSteelWall.Count > 0 || ListBuildingGameObjectsUraniumWall.Count > 0)
            {
                CancelButton.gameObject.SetActive(true);
                MoveButton.gameObject.SetActive(true);
                BuildButton.gameObject.SetActive(true);
                DestroyButton.gameObject.SetActive(false);
            }
            else
            {
                MoveButton.gameObject.SetActive(false);
                BuildButton.gameObject.SetActive(false);
                DestroyButton.gameObject.SetActive(true);
            }
        }
        #endregion


        Irontxt.text = IronBalance.ToString();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = -10;
        
        
        RaycastHit2D hit = Physics2D.Linecast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward));
        //Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), hit.point,Color.green);
        


        #region FACTORY CANVAS
        if (hit.collider != null)
        {

            if (hit.collider.tag == "Factory")
            {
                Factorymngr = hit.collider.gameObject;
                if (Factorymngr.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == false && !MouseOverUILayerObject.IsPointerOverUIObject())
                    {

                        if (Factorymngr.GetComponent<FactoryWork>().Work == true)
                        {
                            Factorymngr.GetComponent<FactoryWork>().LimitationCanvasImage.gameObject.SetActive(true);
                        }
                        else
                        {
                            Factorymngr.GetComponent<FactoryWork>().FactoryCanvasImage.gameObject.SetActive(true);
                        }

                    }
                }


            }
        }
            #endregion


        #region DESTROY
            //--------------DESTROY---------------
            if (hit.collider.tag == "WoodenDrill")//destroy
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += 20;
                }
                canBuildDrill = false;
            }
            if (hit.collider.tag == "IronDrill")//destroy
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += IronDrillPrice / 2;
                    IronBarBalance += IronDrillIronBarPrice / 2;
                    GearBalance += IronDrillGearPrice / 2;
                }
                canBuildIronDrill = false;
            }

            if (hit.collider.tag == "ElectricDrill")//destroy
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += ElectricDrillPrice / 2;
                    IronBarBalance += ElectricDrillIronBarPrice / 2;
                    GearBalance += ElectricDrillGearPrice / 2;
                }
                canBuildElectricDrill = false;
            }
        if (hit.collider.tag == "UraniumDrill")//destroy
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
            {
                Destroy(hit.collider.gameObject);
                SteelBalance += UraniumDrillSteelPrice/ 2;
                UraniumBalance+= UraniumDrillUraniumPrice/ 2;
                AdvancedCircuitBoardBalance += UraniumDrillAdvancedCircuitBoardPrice/ 2;
            }
            canBuildUraniumDrill = false;
        }

        if (hit.collider.tag == "Turret1")//destroy
            {
                if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {

                    if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                    {
                        Destroy(hit.collider.gameObject);
                        IronBalance += woodenTurretPrice / 2;
                        IronBarBalance += woodenTurretIronBarPrice / 2;
                        GearBalance += woodenTurretGearPrice / 2;
                    }
                    canBuildTurret = false;
                }
                else
                {

                    if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                    {
                        int aa = ListBuildingGameObjectsWoodenTurret.FindIndex(d => d == hit.collider.gameObject);
                        ListBuildingGameObjectsWoodenTurret.RemoveAt(aa);
                        Destroy(hit.collider.gameObject);

                    }
                    canBuildTurret = false;
                }

            }


            if (hit.collider.tag == "RegenHealthMachine")//destroy
            {
                if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                    {
                        Destroy(hit.collider.gameObject);
                        IronBalance += HealthRegenPrice / 2;
                        CopperWireBalance += HealthRegenCopperWirePrice / 2;
                        CircuitBoardBalance += HealthRegenCircuitBoardPrice / 2;
                    }
                    canBuildHealthRegen = false;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                    {
                        int aa = ListBuildingGameObjectsHealthRegen.FindIndex(d => d == hit.collider.gameObject);
                        ListBuildingGameObjectsHealthRegen.RemoveAt(aa);
                        Destroy(hit.collider.gameObject);

                    }
                    canBuildHealthRegen = false;
                }

            }

            if (hit.collider.tag == "CoalToElectric")//destroy
            {
                if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                    {
                        Destroy(hit.collider.gameObject);
                        IronBalance += CoaltoElectricPrice / 2;
                        CopperWireBalance += CoaltoElectricCopperWirePrice / 2;
                        CircuitBoardBalance += CoaltoElectricCircuitBoardPrice / 2;
                    }
                    canBuildCoaltoElectric = false;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                    {
                        int aa = ListBuildingGameObjectsCoalToElectric.FindIndex(d => d == hit.collider.gameObject);
                        ListBuildingGameObjectsCoalToElectric.RemoveAt(aa);
                        Destroy(hit.collider.gameObject);

                    }
                    canBuildCoaltoElectric = false;
                }

            }

            if (hit.collider.tag == "Factory")//destroy
            {
                if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                    {
                        Destroy(hit.collider.gameObject);
                        IronBalance += FactoryPrice / 2;
                    }
                    canBuildFactory = false;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                    {
                        int aa = ListBuildingGameObjectsFactory.FindIndex(d => d == hit.collider.gameObject);
                        ListBuildingGameObjectsFactory.RemoveAt(aa);
                        Destroy(hit.collider.gameObject);

                    }
                    canBuildFactory = false;
                }
            }


            if (hit.collider.tag == "IronWall")//destroy
            {
                if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                    {
                        Destroy(hit.collider.gameObject);
                        IronBalance += IronWallPrice / 2;
                    }
                    canBuildIronWall = false;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                    {
                        int aa = ListBuildingGameObjectsIronWall.FindIndex(d => d == hit.collider.gameObject);
                        ListBuildingGameObjectsIronWall.RemoveAt(aa);
                        Destroy(hit.collider.gameObject);

                    }
                    canBuildIronWall = false;
                }

            }

             if (hit.collider.tag == "ElectricTurret")//ELECTRÝC TURRET
            {
                if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                    {
                        Destroy(hit.collider.gameObject);
                        IronBalance += ElectricTurretPrice / 2;
                        IronBarBalance += ElectricTurretIronBarPrice / 2;
                        GearBalance += ElectricTurretGearPrice / 2;
                        CopperWireBalance += ElectricTurretCopperWirePrice / 2;
                        CircuitBoardBalance += ElectricTurretCircuitBoardPrice / 2;
                }
                    canBuildElectricTurret = false;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                    {
                        int aa = ListBuildingGameObjectsElectricTurret.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsElectricTurret.RemoveAt(aa);
                        Destroy(hit.collider.gameObject);

                    }
                canBuildElectricTurret = false;
                }

            }

             if (hit.collider.tag == "BigHealthRegen")//BIG HEALTH REGEN
            {
                if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                    {
                        Destroy(hit.collider.gameObject);
                        IronBalance += BigHealthRegenPrice / 2;                        
                        CopperWireBalance += BigHealthRegenCopperWirePrice / 2;
                        CircuitBoardBalance += BigHealthRegenCircuitBoardPrice / 2;
                }
                    canBuildBigHealthRegen = false;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                    {
                        int aa = ListBuildingGameObjectsBigHealthRegen.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsBigHealthRegen.RemoveAt(aa);
                        Destroy(hit.collider.gameObject);

                    }
                canBuildBigHealthRegen = false;
                }

            }

        if (hit.collider.tag == "AdvancedTurret")//ADVANCED TURRET
        {
            if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += AdvancedTurretPrice / 2;
                    IronBarBalance += AdvancedTurretIronBarPrice / 2;
                    GearBalance+= AdvancedTurretGearPrice / 2;
                }
                canBuildAdvancedTurret = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                {
                    int aa = ListBuildingGameObjectsAdvancedTurret.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsAdvancedTurret.RemoveAt(aa);
                    Destroy(hit.collider.gameObject);

                }
                canBuildAdvancedTurret = false;
            }

        }


        if (hit.collider.tag == "LaserTurret")//LASER TURRET
        {
            if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject) ;
                    IronBalance += LaserTurretPrice / 2;
                    IronBarBalance += LaserTurretIronBarPrice / 2;
                    GearBalance += LaserTurretGearPrice / 2;
                    CircuitBoardBalance += LaserTurretCircuitBoardPrice / 2;
                    SteelBalance += LaserTurretSteelPrice /2;
                }
                canBuildLaserTurret = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                {
                    int aa = ListBuildingGameObjectsLaserTurret.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsLaserTurret.RemoveAt(aa);
                    Destroy(hit.collider.gameObject);

                }
                canBuildLaserTurret = false;
            }

        }

        if (hit.collider.tag == "MortarTurret")//Mortar TURRET
        {
            if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += MortarTurretPrice / 2;
                    IronBarBalance += MortarTurretIronBarPrice / 2;
                    GearBalance += MortarTurretGearPrice / 2;;
                    SteelBalance += MortarTurretSteelPrice/ 2;
                }
                canBuildMortarTurret = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                {
                    int aa = ListBuildingGameObjectsMortarTurret.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsMortarTurret.RemoveAt(aa);
                    Destroy(hit.collider.gameObject);

                }
                canBuildMortarTurret = false;
            }

        }

        if (hit.collider.tag == "UraniumToElectric")//BIG HEALTH REGEN
        {
            if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += UraniumToelectricPrice / 2;
                    CopperWireBalance += UraniumToelectricCopperWirePrice / 2;
                    CircuitBoardBalance += UraniumToelectricCircuitBoardPrice / 2;
                    SteelBalance += UraniumToelectricSteelPrice / 2;
                }
                canBuildUraniumToelectric = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                {
                    int aa = ListBuildingGameObjectsUraniumToElectric.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsUraniumToElectric.RemoveAt(aa);
                    Destroy(hit.collider.gameObject);

                }
                canBuildUraniumToelectric = false;
            }

        }

        if (hit.collider.tag == "AdvancedUraniumTurret")//BIG HEALTH REGEN
        {
            if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += AdvancedUraniumTurretPrice / 2;
                    IronBarBalance += AdvancedUraniumTurretIronBarPrice / 2;
                    SteelBalance += AdvancedUraniumTurretSteelPrice / 2;
                    UraniumBalance += AdvancedUraniumTurretUraniumPrice / 2;
                }
                canBuildAdvancedUraniumTurret = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                {
                    int aa = ListBuildingGameObjectsAdvancedUraniumTurret.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsAdvancedUraniumTurret.RemoveAt(aa);
                    Destroy(hit.collider.gameObject);

                }
                canBuildAdvancedUraniumTurret = false;
            }

        }

        if (hit.collider.tag == "MortarUraniumTurret")//BIG HEALTH REGEN
        {
            if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += MortarUraniumTurretPrice / 2;
                    IronBarBalance += MortarUraniumTurretIronBarPrice/ 2;
                    SteelBalance += MortarUraniumTurretSteelPrice/ 2;
                    UraniumBalance += MortarUraniumTurretUraniumPrice / 2;
                }
                canBuildMortarUraniumTurret = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                {
                    int aa = ListBuildingGameObjectsMortarUraniumTurret.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsMortarUraniumTurret.RemoveAt(aa);
                    Destroy(hit.collider.gameObject);

                }
                canBuildMortarUraniumTurret = false;
            }

        }
        if (hit.collider.tag == "LaserUraniumTurret")//BIG HEALTH REGEN
        {
            if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);
                   
                    IronBarBalance += LaserUraniumTurretIronBarPrice / 2;
                    CircuitBoardBalance += LaserUraniumTurretCircuitBoardPrice / 2;
                    SteelBalance += LaserUraniumTurretSteelPrice / 2;
                    UraniumBalance += LaserUraniumTurretUraniumPrice / 2;
                    AdvancedCircuitBoardBalance += LaserUraniumTurretAdvancedCircuitBoardPrice / 2;
                }
                canBuildLaserUraniumTurret = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                {
                    int aa = ListBuildingGameObjectsLaserUraniumTurret.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsLaserUraniumTurret.RemoveAt(aa);
                    Destroy(hit.collider.gameObject);

                }
                canBuildLaserUraniumTurret = false;
            }

        }
        if (hit.collider.tag == "SteelWall")//BIG HEALTH REGEN
        {
            if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);

                    SteelBalance += SteelWallSteelPrice/ 2;
                    
                }
                canBuildSteelWall = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                {
                    int aa = ListBuildingGameObjectsSteelWall.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsSteelWall.RemoveAt(aa);
                    Destroy(hit.collider.gameObject);

                }
                canBuildSteelWall = false;
            }

        }
        if (hit.collider.tag == "UraniumWall")//BIG HEALTH REGEN
        {
            if (hit.collider.gameObject.GetComponent<Dragger>().Isbuilded == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Destroyitem == true)
                {
                    Destroy(hit.collider.gameObject);

                    UraniumBalance += UraniumWallUraniumPrice/ 2;

                }
                canBuildUraniumWall = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Moveitem == false)
                {
                    int aa = ListBuildingGameObjectsUraniumWall.FindIndex(d => d == hit.collider.gameObject);
                    ListBuildingGameObjectsUraniumWall.RemoveAt(aa);
                    Destroy(hit.collider.gameObject);

                }
                canBuildUraniumWall = false;
            }

        }
        #endregion


        #region BUILD
        //------------BUÝLD-----------------

        //drill nerelerde buildlenebilir
        if (hit.collider.tag == "Iron" || hit.collider.tag == "Coal" || hit.collider.tag == "Copper")
            {
                canBuildDrill = true;
                canBuildIronDrill = true;
                canBuildElectricDrill = true;
                canBuildUraniumDrill= true;
        }
            else if (hit.collider.tag == "Uranium") 
            {
            canBuildElectricDrill = true;
            canBuildUraniumDrill = true;
        }

            else if (hit.collider.tag == "WoodenDrill")
            {
            canBuildIronDrill = true;
            canBuildElectricDrill = true;
            canBuildUraniumDrill= true;
            }

            else if (hit.collider.tag == "IronDrill")
            {
            canBuildElectricDrill = true;
            canBuildUraniumDrill= true;
            }
            else if (hit.collider.tag == "ElectricDrill")
            {            
            canBuildUraniumDrill= true;
            }
            else
            {
                canBuildDrill = false;
                canBuildIronDrill = false;
                canBuildElectricDrill = false;
                canBuildUraniumDrill= false;
            }



        //Turret nerelerde buildlenebilir
            if (hit.collider.tag == "Floor")
            {
            
                canBuildTurret = true;
            }
            else
            {
                canBuildTurret = false;
            }
            //Can Yenileyici nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildHealthRegen = true;
            }
            else
            {
                canBuildHealthRegen = false;
            }
            //Coal to Electric nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildCoaltoElectric = true;
            }
            else
            {
                canBuildCoaltoElectric = false;
            }

            //MErmi Makinesi nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildFactory = true;
            }
            else
            {
                canBuildFactory = false;
            }
            //Demir Duvar nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildIronWall = true;
            }
            else
            {
                canBuildIronWall = false;
            }
             //ELEKTRÝK TURRET nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildElectricTurret = true;
            }
            else
            {
                canBuildElectricTurret = false;
            }
            //BIG HEALTH REGEN nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildBigHealthRegen = true;
            }
            else
            {
            canBuildBigHealthRegen = false;
            }
            //ADVANCED TURRET nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildAdvancedTurret = true;
            }
            else
            {
            canBuildAdvancedTurret = false;
            }
            //LASER TURRET nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildLaserTurret = true;
            }
            else
            {
                canBuildLaserTurret = false;
            }
             //LASER TURRET nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildMortarTurret = true;
            }
            else
            {
            canBuildMortarTurret = false;
            }
             //Uranium To Electric nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildUraniumToelectric = true;
            }
            else
            {
                canBuildUraniumToelectric = false;
            }
            //ADVANCED URAÝNUM TURRET nerede inþa edilebilir
            if (hit.collider.tag == "Floor")
            {
                canBuildAdvancedUraniumTurret = true;
                canBuildMortarUraniumTurret = true;
                canBuildLaserUraniumTurret = true;
            canBuildSteelWall = true;
            canBuildUraniumWall = true;
            }
            else
            {
                 canBuildAdvancedUraniumTurret = false;
                 canBuildMortarUraniumTurret = false;
                 canBuildLaserUraniumTurret = false;
                 canBuildSteelWall = false;
                 canBuildUraniumWall= false;
            }
           


        

        // Wooden Drill  inþa etmek Ýçin

        if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildDrill == true && !MouseOverUILayerObject.IsPointerOverUIObject() && selectItemWoodenDrill == true && woodenDrillPrice <= IronBalance)// WoodenDrill build etmek Ýçin
        {

            IronBalance -= woodenDrillPrice;

            BuildSE.Play();
            Build = Instantiate(created, transform.position, transform.rotation);

            //clicked = GameObject.FindGameObjectsWithTag("Iron");
            float hitx = Mathf.Round(worldPos.x);
            float hity = Mathf.Round(worldPos.y);
            //Build.transform.position = new Vector3(hitx,hity,-1f);            
            FindClosestOre();
        }
        // Wooden Turret  inþa etmek Ýçin
       
        if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildTurret == true && selectItemWoodenTurret == true )// WoodenTurretbuild etmek Ýçin
        {
            Debug.Log(DontBuild.dragnobuild + name, gameObject);
           
                if (woodenTurretPrice <= IronBalance && woodenTurretIronBarPrice <= IronBarBalance && woodenTurretGearPrice <= GearBalance)
                {
                    if (!MouseOverUILayerObject.IsPointerOverUIObject()) // UI a týklamýyorsa
                    {
                        if (DontBuild.dragnobuild == false)
                        {
                        BuildSE.Play();
                        Build = Instantiate(created, transform.position, transform.rotation);

                        Build.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                        Build.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);


                        Build.transform.GetChild(0).gameObject.SetActive(false);
                        Build.transform.GetChild(1).gameObject.SetActive(false);


                        //-----------
                        float reciprocalgrid = 1f / grid;
                        xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid + 0.15f;
                        yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid - 0.15f;
                        Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);

                        ListBuildingGameObjectsWoodenTurret.Add(Build.gameObject);
                         }
                    }
                }
           
           



        }
        // Can Yenileyici inþa etmek Ýçin

        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildHealthRegen == true && selectItemHealthRegen == true && HealthRegenPrice <= IronBalance && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {

            if (!MouseOverUILayerObject.IsPointerOverUIObject())
            {
                if (HealthRegenPrice <= IronBalance && CoaltoElectricCircuitBoardPrice <= CircuitBoardBalance && CoaltoElectricCopperWirePrice <= CopperWireBalance)
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);

                    Build.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);

                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid + 0.15f;
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid - 0.15f;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsHealthRegen.Add(Build.gameObject);
                }


            }


        }
        // Kömürden Elektriðe inþa etmek Ýçin

        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildCoaltoElectric == true && selectItemCoaltoElectric == true && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {

            if (!MouseOverUILayerObject.IsPointerOverUIObject())
            {
                if (CoaltoElectricPrice <= IronBalance && CoaltoElectricCircuitBoardPrice <= CircuitBoardBalance && CoaltoElectricCopperWirePrice <= CopperWireBalance)
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);

                    Build.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);

                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid + 0.15f;
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid - 0.15f;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsCoalToElectric.Add(Build.gameObject);
                }


            }


        }
        // FActory inþa etmek Ýçin

        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildFactory == true && selectItemFactory == true && FactoryPrice <= IronBalance && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {

            if (!MouseOverUILayerObject.IsPointerOverUIObject())
            {

                BuildSE.Play();
                Build = Instantiate(created, transform.position, transform.rotation);

                Build.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                Build.transform.GetChild(0).gameObject.SetActive(false);
                Build.transform.GetChild(1).gameObject.SetActive(false);
                //-----------
                float reciprocalgrid = 1f / grid;
                xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid;
                yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid;
                Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                ListBuildingGameObjectsFactory.Add(Build.gameObject);
            }


        }



        // Iron Wall  inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildIronWall == true && selectItemIronWall == true && IronWallPrice <= IronBalance && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {


            if (!MouseOverUILayerObject.IsPointerOverUIObject())
            {
                BuildSE.Play();
                Build = Instantiate(created, transform.position, transform.rotation);

                Build.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                Build.transform.GetChild(0).gameObject.SetActive(false);
                Build.transform.GetChild(1).gameObject.SetActive(false);




                //-----------
                float reciprocalgrid = 1f / grid;
                xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid + 0.15f;
                yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid - 0.15f;
                Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                ListBuildingGameObjectsIronWall.Add(Build.gameObject);

                //AstarPath.active.Scan();
            }




        }

        // Iron Drill  inþa etmek Ýçin

        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildIronDrill == true && !MouseOverUILayerObject.IsPointerOverUIObject() && selectItemIronDrill == true)// IronDrill build etmek Ýçin
        {
            if (IronBalance > IronDrillPrice && IronBarBalance > IronDrillIronBarPrice && GearBalance > IronDrillGearPrice)
            {
                if (hit.collider.tag == "WoodenDrill")
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += woodenDrillPrice / 2;
                }
                IronBalance -= IronDrillPrice;
                IronBarBalance -= IronDrillIronBarPrice;
                GearBalance -= IronDrillGearPrice;

                BuildSE.Play();
                Build = Instantiate(created, transform.position, transform.rotation);

                //clicked = GameObject.FindGameObjectsWithTag("Iron");
                float hitx = Mathf.Round(worldPos.x);
                float hity = Mathf.Round(worldPos.y);
                //Build.transform.position = new Vector3(hitx,hity,-1f);            
                FindClosestOre();
            }

        }

        // Electric Drill  inþa etmek Ýçin

        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildElectricDrill == true && !MouseOverUILayerObject.IsPointerOverUIObject() && selectItemElectricDrill == true)// IronDrill build etmek Ýçin
        {
            if (IronBalance > ElectricDrillPrice && IronBarBalance > ElectricDrillIronBarPrice && GearBalance > ElectricDrillGearPrice && CopperWireBalance > ElectricDrillCopperWirePrice && CircuitBoardBalance > ElectricDrillCircuitBoardPrice)
            {
                if (hit.collider.tag == "WoodenDrill")
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += woodenDrillPrice / 2;
                }
                else if (hit.collider.tag == "IronDrill")
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += IronDrillPrice / 2;
                    IronBalance += IronDrillGearPrice / 2;
                    IronBalance += IronDrillIronBarPrice / 2;
                }
                IronBalance -= ElectricDrillPrice;
                IronBarBalance -= ElectricDrillIronBarPrice;
                GearBalance -= ElectricDrillGearPrice;
                CopperWireBalance -= ElectricDrillCopperWirePrice;
                CircuitBoardBalance -= ElectricDrillCircuitBoardPrice;

                BuildSE.Play();
                Build = Instantiate(created, transform.position, transform.rotation);

                //clicked = GameObject.FindGameObjectsWithTag("Iron");
                float hitx = Mathf.Round(worldPos.x);
                float hity = Mathf.Round(worldPos.y);
                //Build.transform.position = new Vector3(hitx,hity,-1f);            
                FindClosestOre();
            }

        }

        // Electric Turret inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildElectricTurret == true && selectItemElectricTurret == true  && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {
            if (IronBalance > ElectricTurretPrice && IronBarBalance >ElectricTurretIronBarPrice && GearBalance>ElectricTurretGearPrice && CopperWireBalance > ElectricTurretCopperWirePrice && CircuitBoardBalance > ElectricTurretCircuitBoardPrice)
            {
                if (!MouseOverUILayerObject.IsPointerOverUIObject())
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);

                    Build.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);




                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid;//30 px deðilse bu kodu kullan
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsElectricTurret.Add(Build.gameObject);

                    //AstarPath.active.Scan();
                }

            }

        }

        // Big Health Regen inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildBigHealthRegen == true && selectItemBigHealthRegen == true && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {
            if (IronBalance > BigHealthRegenPrice && CopperWireBalance > BigHealthRegenCopperWirePrice&&  CircuitBoardBalance > BigHealthRegenCircuitBoardPrice)
            {
                if (!MouseOverUILayerObject.IsPointerOverUIObject())
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);

                    Build.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);




                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid;//30 px deðilse bu kodu kullan
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsBigHealthRegen.Add(Build.gameObject);

                    //AstarPath.active.Scan();
                }

            }

        }

        // Advanced Turret inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildAdvancedTurret == true && selectItemAdvancedTurret == true && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {
            if (IronBalance > AdvancedTurretPrice && IronBarBalance > AdvancedTurretIronBarPrice && GearBalance > AdvancedTurretGearPrice)
            {
                if (!MouseOverUILayerObject.IsPointerOverUIObject())
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);


                    Build.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);


                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);




                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid;
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsAdvancedTurret.Add(Build.gameObject);

                    //AstarPath.active.Scan();
                }

            }

        }

        // LASER Turret inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildLaserTurret == true && selectItemLaserTurret == true && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {
            if (IronBalance > LaserTurretPrice && IronBarBalance > LaserTurretIronBarPrice && GearBalance > LaserTurretGearPrice && SteelBalance > LaserTurretSteelPrice && CircuitBoardBalance > LaserTurretCircuitBoardPrice)
            {
                if (!MouseOverUILayerObject.IsPointerOverUIObject())
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);


                    Build.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);


                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);




                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid + 0.15f;
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid - 0.15f;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsLaserTurret.Add(Build.gameObject);

                    //AstarPath.active.Scan();
                }

            }

        }


        // Mortar Turret inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildMortarTurret == true && selectItemMortarTurret == true && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {
            if (IronBalance > MortarTurretPrice && IronBarBalance > MortarTurretIronBarPrice && GearBalance > MortarTurretGearPrice && SteelBalance > MortarTurretSteelPrice)
            {
                if (!MouseOverUILayerObject.IsPointerOverUIObject())
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);


                    Build.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);


                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);




                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid;
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsMortarTurret.Add(Build.gameObject);

                    //AstarPath.active.Scan();
                }

            }

        }

        // URANIUM TO ELECTRIC inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildUraniumToelectric == true && selectItemUraniumToelectric== true && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {
            if (IronBalance > UraniumToelectricPrice && CopperWireBalance > UraniumToelectricCopperWirePrice && CircuitBoardBalance > UraniumToelectricCircuitBoardPrice && SteelBalance > UraniumToelectricSteelPrice)
            {
                if (!MouseOverUILayerObject.IsPointerOverUIObject())
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);

                    Build.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);




                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid;//30 px deðilse bu kodu kullan
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsUraniumToElectric.Add(Build.gameObject);

                    //AstarPath.active.Scan();
                }

            }

        }
        // ADVANCED URANÝUM Turret inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildAdvancedUraniumTurret == true && selectItemAdvancedUraniumTurret == true && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {
            if (IronBalance > AdvancedUraniumTurretPrice && IronBarBalance > AdvancedUraniumTurretIronBarPrice && UraniumBalance > AdvancedUraniumTurretUraniumPrice && SteelBalance > AdvancedUraniumTurretSteelPrice)
            {
                if (!MouseOverUILayerObject.IsPointerOverUIObject())
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);


                    Build.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);


                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);




                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid;
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsAdvancedUraniumTurret.Add(Build.gameObject);

                    //AstarPath.active.Scan();
                }

            }

        }
        // MORTAR URANÝUM Turret inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildMortarUraniumTurret == true && selectItemMortarUraniumTurret == true && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {
            if (IronBalance > MortarUraniumTurretPrice && IronBarBalance > MortarUraniumTurretIronBarPrice && UraniumBalance > MortarUraniumTurretUraniumPrice && SteelBalance > MortarUraniumTurretSteelPrice)
            {
                if (!MouseOverUILayerObject.IsPointerOverUIObject())
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);


                    Build.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);


                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);




                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid;
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsMortarUraniumTurret.Add(Build.gameObject);

                    //AstarPath.active.Scan();
                }

            }

        }
        // LASER URANÝUM Turret inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildLaserUraniumTurret == true && selectItemLaserUraniumTurret == true && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {
            if (IronBarBalance > LaserUraniumTurretIronBarPrice && UraniumBalance > LaserUraniumTurretUraniumPrice && SteelBalance > LaserUraniumTurretSteelPrice && CircuitBoardBalance > LaserUraniumTurretCircuitBoardPrice && AdvancedCircuitBoardBalance > LaserUraniumTurretAdvancedCircuitBoardPrice)
            {
                if (!MouseOverUILayerObject.IsPointerOverUIObject())
                {
                    BuildSE.Play();
                    Build = Instantiate(created, transform.position, transform.rotation);


                    Build.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                    Build.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);


                    Build.transform.GetChild(0).gameObject.SetActive(false);
                    Build.transform.GetChild(1).gameObject.SetActive(false);




                    //-----------
                    float reciprocalgrid = 1f / grid;
                    xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid;
                    yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid;
                    Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                    ListBuildingGameObjectsLaserUraniumTurret.Add(Build.gameObject);

                    //AstarPath.active.Scan();
                }

            }

        }
        // Steel Wall  inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildSteelWall == true && selectItemSteelWall== true && SteelWallSteelPrice<= SteelBalance && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {


            if (!MouseOverUILayerObject.IsPointerOverUIObject())
            {
                BuildSE.Play();
                Build = Instantiate(created, transform.position, transform.rotation);

                Build.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                Build.transform.GetChild(0).gameObject.SetActive(false);
                Build.transform.GetChild(1).gameObject.SetActive(false);




                //-----------
                float reciprocalgrid = 1f / grid;
                xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid + 0.15f;
                yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid - 0.15f;
                Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                ListBuildingGameObjectsSteelWall.Add(Build.gameObject);

                //AstarPath.active.Scan();
            }




        }
        // URANIUM Wall  inþa etmek Ýçin
        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildUraniumWall == true && selectItemUraniumWall == true && UraniumWallUraniumPrice <= UraniumBalance && DontBuild.dragnobuild == false)// WoodenTurretbuild etmek Ýçin
        {


            if (!MouseOverUILayerObject.IsPointerOverUIObject())
            {
                BuildSE.Play();
                Build = Instantiate(created, transform.position, transform.rotation);

                Build.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                Build.transform.GetChild(0).gameObject.SetActive(false);
                Build.transform.GetChild(1).gameObject.SetActive(false);




                //-----------
                float reciprocalgrid = 1f / grid;
                xGrid = Mathf.Round(worldPos.x * reciprocalgrid) / reciprocalgrid + 0.15f;
                yGrid = Mathf.Round(worldPos.y * reciprocalgrid) / reciprocalgrid - 0.15f;
                Build.transform.position = new Vector3(xGrid, yGrid, transform.position.z);
                ListBuildingGameObjectsUraniumWall.Add(Build.gameObject);

                //AstarPath.active.Scan();
            }




        }
        // Uranium Drill  inþa etmek Ýçin

        else if (Input.GetKeyUp(KeyCode.Mouse0) && canBuildUraniumDrill == true && !MouseOverUILayerObject.IsPointerOverUIObject() && selectItemUraniumDrill == true)// IronDrill build etmek Ýçin
        {
            if (SteelBalance > UraniumDrillSteelPrice&& UraniumBalance> UraniumDrillUraniumPrice&& AdvancedCircuitBoardBalance> UraniumDrillAdvancedCircuitBoardPrice)
            {
                if (hit.collider.tag == "WoodenDrill")
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += woodenDrillPrice / 2;
                }
                else if (hit.collider.tag == "IronDrill")
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += IronDrillPrice / 2;
                    IronBalance += IronDrillGearPrice / 2;
                    IronBalance += IronDrillIronBarPrice / 2;
                }
                else if (hit.collider.tag == "ElectricDrill")
                {
                    Destroy(hit.collider.gameObject);
                    IronBalance += ElectricDrillPrice/2;
                    IronBarBalance += ElectricDrillIronBarPrice/2;
                    GearBalance += ElectricDrillGearPrice/2;
                    CopperWireBalance += ElectricDrillCopperWirePrice/2;
                    CircuitBoardBalance += ElectricDrillCircuitBoardPrice/2;
                }
                SteelBalance -= UraniumDrillSteelPrice;
                UraniumBalance -= UraniumDrillUraniumPrice;
                AdvancedCircuitBoardBalance -= UraniumDrillAdvancedCircuitBoardPrice;
                

                BuildSE.Play();
                Build = Instantiate(created, transform.position, transform.rotation);

                //clicked = GameObject.FindGameObjectsWithTag("Iron");
                float hitx = Mathf.Round(worldPos.x);
                float hity = Mathf.Round(worldPos.y);
                //Build.transform.position = new Vector3(hitx,hity,-1f);            
                FindClosestOre();
            }

        }
        #endregion



    }

    void FindClosestOre()
    {
        float distanceToClosestOre = Mathf.Infinity;
        Ore ClosestOre = null;
        Ore[] allOre = GameObject.FindObjectsOfType<Ore>();
        
        RaycastHit2D hit = Physics2D.Linecast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward));
        foreach (Ore currentOre in allOre)
        {
            float distanceToOre = (currentOre.transform.position - hit.transform.position).sqrMagnitude;
            if (distanceToOre < distanceToClosestOre)
            {
                distanceToClosestOre = distanceToOre;
                ClosestOre = currentOre;
            }
           
        }
        Build.transform.position = new Vector3(ClosestOre.transform.position.x, ClosestOre.transform.position.y, -1f);
        
    }

    private void SelectItem()
    {
        CancelButton.gameObject.SetActive(true);
        //selectitem = true;
        Destroyitem = false;
        Moveitem = false;
        selectItemFactory = false;
        selectItemCoaltoElectric = false;
        selectItemHealthRegen = false;
        selectItemIronWall = false;
        selectItemWoodenDrill = false;
        selectItemWoodenTurret = false;
        selectItemIronDrill = false;
        selectItemElectricDrill = false;
        selectItemElectricTurret = false;
        selectItemBigHealthRegen = false;
        selectItemAdvancedTurret = false;
        selectItemLaserTurret = false;
        selectItemMortarTurret = false;
        selectItemUraniumToelectric = false;
        selectItemAdvancedUraniumTurret = false;
        selectItemMortarUraniumTurret = false;
        selectItemLaserUraniumTurret = false;
        selectItemSteelWall= false;
        selectItemUraniumWall= false;
        selectItemUraniumDrill= false;
    }


    #region CREATE VOÝD
    public void CreateTurret() // turret Ýnþa Eder
    {
        
        ButtonColorClear();
        WoodenTurretButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = WoodenTurret;
        SelectItem();
        selectItemWoodenTurret = true;
    }

    public void CreateDril()//Drill inþa eder
    {
        ButtonColorClear();
        WoodenDrillButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = WoodenDrill;


        SelectItem();
        selectItemWoodenDrill = true;
    }

    public void CreateHealthRegen()//CAn Yenileyici inþa eder
    {
        ButtonColorClear();
        HealthRegenButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = HealthRegen;

        SelectItem();
        selectItemHealthRegen = true;
    }

    public void CreateCoalToElectric()//CAn Yenileyici inþa eder
    {
        ButtonColorClear();
        CoaltoElectricButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = CoaltoElectric;

        SelectItem();
        selectItemCoaltoElectric = true;
    }

    public void CreateBulletMachine()//Mermi Yapýcý inþa eder
    {
        ButtonColorClear();
        BulletMachineButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = Factory;

        SelectItem();
        selectItemFactory = true;
    }

    public void CreateIronWall()// Demir Duvar inþa eder
    {
        ButtonColorClear();
        IronWallButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = IronWall;

        SelectItem();
        selectItemIronWall = true;
    }

    public void CreateIronDrill()// Demir Sondaj inþa eder
    {
        ButtonColorClear();
        IronDrillButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = IronDrill;

        SelectItem();
        selectItemIronDrill = true;
    }

    public void CreateElectricDrill()// ELEKTRÝKLÝ Sondaj inþa eder
    {
        ButtonColorClear();
        ElectricDrillButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = ElectricDrill;

        SelectItem();
        selectItemElectricDrill = true;
    }

    public void CreateElectricTurret()// Electric Turret inþa eder
    {
        ButtonColorClear();
        ElectricTurretButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = ElectricTurret;

        SelectItem();
        selectItemElectricTurret = true;
    }

    public void CreateBigHealthRegen()// Electric Turret inþa eder
    {
        ButtonColorClear();
        BigHealthRegenButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = BigHealthRegen;

        SelectItem();
        selectItemBigHealthRegen = true;
    }

    public void CreateAdvancedTurret()// Electric Turret inþa eder
    {
        ButtonColorClear();
        AdvancedTurretButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = AdvancedTurret;

        SelectItem();
        selectItemAdvancedTurret = true;
    }

    public void CreateLaserTurret()// Laser Turret inþa eder
    {
        ButtonColorClear();
        LaserTurretButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = LaserTurret;

        SelectItem();
        selectItemLaserTurret = true;
    }

    public void CreateMortarTurret()// Laser Turret inþa eder
    {
        ButtonColorClear();
        MortarTurretButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = MortarTurret;

        SelectItem();
        selectItemMortarTurret = true;
    }

    public void CreateUraniumToElectricTurret()// Laser Turret inþa eder
    {
        ButtonColorClear();
        UraniumToelectricButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = UraniumToelectric;

        SelectItem();
        selectItemUraniumToelectric = true;
    }

    public void CreateAdvancedUraniumTurret()// ADVANCED URANIUM Turret inþa eder
    {
        ButtonColorClear();
        AdvancedUraniumTurretButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = AdvancedUraniumTurret;

        SelectItem();
        selectItemAdvancedUraniumTurret = true;
    }

    public void CreateMortarUraniumTurret()// ADVANCED URANIUM Turret inþa eder
    {
        ButtonColorClear();
        MortarUraniumTurretButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = MortarUraniumTurret;

        SelectItem();
        selectItemMortarUraniumTurret = true;
    }

    public void CreateLaserUraniumTurret()// ADVANCED URANIUM Turret inþa eder
    {
        ButtonColorClear();
        LaserUraniumTurretButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = LaserUraniumTurret;

        SelectItem();
        selectItemLaserUraniumTurret = true;
    }

    public void CreateSteelWall()// ADVANCED URANIUM Turret inþa eder
    {
        ButtonColorClear();
        SteelWallButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = SteelWall;

        SelectItem();
        selectItemSteelWall = true;
    }
    public void CreateUraniumWall()// ADVANCED URANIUM Turret inþa eder
    {
        ButtonColorClear();
        UraniumWallButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = UraniumWall;

        SelectItem();
        selectItemUraniumWall = true;
    }
    public void CreatUraniumDrill()// ELEKTRÝKLÝ Sondaj inþa eder
    {
        ButtonColorClear();
        UraniumDrillButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        //-------Yukarýsý Renk Kýsmý---------
        created = UraniumDrill;

        SelectItem();
        selectItemUraniumDrill = true;
    }

    #endregion


    public void CancelItem()
    {
        CancelButton.gameObject.SetActive(false);
        
        falseAllSelectedÝtem();
        Destroyitem = false;
        Moveitem = false;
        
        InfoCanvas.gameObject.SetActive(false);
        ButtonColorClear();
        DestroyAllnotBuildedObject();


    }

    public void CancelBuildsPage()//Solda açýlan sekmelerin hepsini kapatýr
    {
        CancelButton.gameObject.SetActive(false);
        BasicMachineImage.gameObject.SetActive(false);
        DrillsImage.gameObject.SetActive(false);
        TurretsImage.gameObject.SetActive(false);
        ElectricImage.gameObject.SetActive(false);
        WallsImage.gameObject.SetActive(false);
    }

    public void DestroyItem()//yoketme itemini seçer
    {
        ButtonColorClear();
        DestroyButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        CancelButton.gameObject.SetActive(true);
        //selectitem = false;
        falseAllSelectedÝtem();
        Destroyitem = true;
        Moveitem = false;

    }

    public void MoveItem()//Taþýma itemini seçer
    {
        if (Moveitem == false)
        {
            ButtonColorClear();
            MoveButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
            CancelButton.gameObject.SetActive(true);
            //selectitem = false;
            falseAllSelectedÝtem();
            Destroyitem = false;
            Moveitem = true;
        }
        else
        {
            ButtonColorClear();
            Moveitem = false;
        }
        
    }

    public void BuildItem()//Taþýma itemini seçer
    {

        ButtonColorClear();       
        
        //selectitem = false;
        falseAllSelectedÝtem();
        Destroyitem = false;
        Moveitem = false;
        Builditem = true;
    }


    #region PAGES
    public void DrillsPage()//solda sondajlar sayfasýný açar
    {
        CancelBuildsPage();
        DrillsImage.gameObject.SetActive(true);

    }

    public void BasicMachinePage()//solda Basit MAkineler sayfasýný açar
    {
        CancelBuildsPage();
        BasicMachineImage.gameObject.SetActive(true);

    }

    public void TurretsPage()//solda turret sayfasýný açar
    {

        CancelBuildsPage();
        TurretsImage.gameObject.SetActive(true);

    }

    public void ElectricsPage()//solda turret sayfasýný açar
    {

        CancelBuildsPage();
        ElectricImage.gameObject.SetActive(true);

    }

    public void WallsPage()//solda turret sayfasýný açar
    {

        CancelBuildsPage();
        WallsImage.gameObject.SetActive(true);

    }
    #endregion


    private void falseAllSelectedÝtem()//önceden build etmek için seçtiðimiz objeleri seçilmemiþ hale getirir.
    {
        selectItemWoodenDrill = false;
        selectItemWoodenTurret = false;
        selectItemHealthRegen = false;
        selectItemCoaltoElectric= false;
        selectItemFactory= false;
        selectItemIronWall= false;
        selectItemIronDrill= false;
        selectItemElectricDrill= false;
        selectItemElectricTurret= false;
        selectItemBigHealthRegen= false;
        selectItemAdvancedTurret= false;
        selectItemLaserTurret= false;
        selectItemMortarTurret= false;
        selectItemUraniumToelectric= false;
        selectItemAdvancedUraniumTurret= false;
        selectItemMortarUraniumTurret= false;
        selectItemLaserUraniumTurret= false;
        selectItemSteelWall= false;
        selectItemUraniumWall= false;
        selectItemUraniumDrill= false;


    }

    private void ButtonColorClear()//bütün butonlarýn rengini beyaz yapar
    {
        CancelButton.GetComponent<Image>().color = new Color32(0, 0, 0, 152);
        WoodenTurretButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        WoodenDrillButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        CoaltoElectricButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        HealthRegenButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        BulletMachineButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        IronWallButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        IronDrillButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        ElectricDrillButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        ElectricTurretButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        BigHealthRegenButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        AdvancedTurretButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        LaserTurretButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        MortarTurretButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        UraniumToelectricButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        AdvancedUraniumTurretButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        MortarUraniumTurretButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        LaserUraniumTurretButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        SteelWallButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        UraniumWallButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        UraniumDrillButton.GetComponent<Image>().color = new Color32(53, 53, 53, 255);


        MoveButton.GetComponent<Image>().color = new Color32(0, 0, 0, 152);
        DestroyButton.GetComponent<Image>().color = new Color32(0, 0, 0, 152);

    }

    private void DestroyAllnotBuildedObject()//bütün real build yapýlmamýþ yapýlarý siler
    {
        for (int i = 0; i < ListBuildingGameObjectsWoodenTurret.Count; i++)
        {
            Destroy(ListBuildingGameObjectsWoodenTurret[i].gameObject);
            ListBuildingGameObjectsWoodenTurret.RemoveAt(i);
            
            i--;
        }

        for (int i = 0; i < ListBuildingGameObjectsHealthRegen.Count; i++)
        {
            Destroy(ListBuildingGameObjectsHealthRegen[i].gameObject);
            ListBuildingGameObjectsHealthRegen.RemoveAt(i);
            i--;
        }

        for (int i = 0; i < ListBuildingGameObjectsCoalToElectric.Count; i++)
        {
            Destroy(ListBuildingGameObjectsCoalToElectric[i].gameObject);
            ListBuildingGameObjectsCoalToElectric.RemoveAt(i);
            i--;
        }

        for (int i = 0; i < ListBuildingGameObjectsFactory.Count; i++)
        {
            Destroy(ListBuildingGameObjectsFactory[i].gameObject);
            ListBuildingGameObjectsFactory.RemoveAt(i);
            i--;
        }

        for (int i = 0; i < ListBuildingGameObjectsIronWall.Count; i++)
        {
            Destroy(ListBuildingGameObjectsIronWall[i].gameObject);
            ListBuildingGameObjectsIronWall.RemoveAt(i);
            i--;
        }

        for (int i = 0; i < ListBuildingGameObjectsElectricTurret.Count; i++)
        {
            Destroy(ListBuildingGameObjectsElectricTurret[i].gameObject);
            ListBuildingGameObjectsElectricTurret.RemoveAt(i);
            i--;
        }

        for (int i = 0; i < ListBuildingGameObjectsBigHealthRegen.Count; i++)
        {
            Destroy(ListBuildingGameObjectsBigHealthRegen[i].gameObject);
            ListBuildingGameObjectsBigHealthRegen.RemoveAt(i);
            i--;
        }

        for (int i = 0; i < ListBuildingGameObjectsAdvancedTurret.Count; i++)
        {
            Destroy(ListBuildingGameObjectsAdvancedTurret[i].gameObject);
            ListBuildingGameObjectsAdvancedTurret.RemoveAt(i);
            i--;
        }

        for (int i = 0; i < ListBuildingGameObjectsLaserTurret.Count; i++)
        {
            Destroy(ListBuildingGameObjectsLaserTurret[i].gameObject);
            ListBuildingGameObjectsLaserTurret.RemoveAt(i);
            i--;
        }

        for (int i = 0; i < ListBuildingGameObjectsMortarTurret.Count; i++)
        {
            Destroy(ListBuildingGameObjectsMortarTurret[i].gameObject);
            ListBuildingGameObjectsMortarTurret.RemoveAt(i);
            i--;
        }
        for (int i = 0; i < ListBuildingGameObjectsUraniumToElectric.Count; i++)
        {
            Destroy(ListBuildingGameObjectsUraniumToElectric[i].gameObject);
            ListBuildingGameObjectsUraniumToElectric.RemoveAt(i);
            i--;
        }
        for (int i = 0; i < ListBuildingGameObjectsAdvancedUraniumTurret.Count; i++)
        {
            Destroy(ListBuildingGameObjectsAdvancedUraniumTurret[i].gameObject);
            ListBuildingGameObjectsAdvancedUraniumTurret.RemoveAt(i);
            i--;
        }
        for (int i = 0; i < ListBuildingGameObjectsMortarUraniumTurret.Count; i++)
        {
            Destroy(ListBuildingGameObjectsMortarUraniumTurret[i].gameObject);
            ListBuildingGameObjectsMortarUraniumTurret.RemoveAt(i);
            i--;
        }
        for (int i = 0; i < ListBuildingGameObjectsLaserUraniumTurret.Count; i++)
        {
            Destroy(ListBuildingGameObjectsLaserUraniumTurret[i].gameObject);
            ListBuildingGameObjectsLaserUraniumTurret.RemoveAt(i);
            i--;
        }
        for (int i = 0; i < ListBuildingGameObjectsSteelWall.Count; i++)
        {
            Destroy(ListBuildingGameObjectsSteelWall[i].gameObject);
            ListBuildingGameObjectsSteelWall.RemoveAt(i);
            i--;
        }
        for (int i = 0; i < ListBuildingGameObjectsUraniumWall.Count; i++)
        {
            Destroy(ListBuildingGameObjectsUraniumWall[i].gameObject);
            ListBuildingGameObjectsUraniumWall.RemoveAt(i);
            i--;
        }


    }


    #region SAVE SYSTEM
    public bool NeedsToBeSaved()
    {
        return true;
    }

    public bool NeedsReinstantiation()
    {
        return true;
    }

    public object SaveState()
    {
        return new BuildData()
        {
            CoalBalance = CoalBalance,
            IronBalance = IronBalance,
            CopperBalance = CopperBalance,
            UraniumBalance = UraniumBalance,
            ElectricBalance = ElectricBalance,
            PowderBalance = PowderBalance,
            BulletBalance = BulletBalance,
            IronBarBalance = IronBarBalance,
            GearBalance = GearBalance,
            CopperWireBalance = CopperWireBalance,
            CircuitBoardBalance = CircuitBoardBalance,
            SteelBalance = SteelBalance,
            MortarBulletBalance = MortarBulletBalance,
             AdvancedCircuitBoardBalance= AdvancedCircuitBoardBalance
        };
    }

    public void LoadState(object state)
    {
        BuildData data = (BuildData)state;
        this.CoalBalance = data.CoalBalance;
        this.IronBalance = data.IronBalance;
        this.CopperBalance = data.CopperBalance;
        this.UraniumBalance = data.UraniumBalance;
        this.ElectricBalance = data.ElectricBalance;
        this.PowderBalance = data.PowderBalance;
        this.BulletBalance = data.BulletBalance;
        this.IronBarBalance = data.IronBarBalance;
        this.GearBalance = data.GearBalance;
        this.CopperWireBalance = data.CopperWireBalance;
        this.CircuitBoardBalance = data.CircuitBoardBalance;
        this.SteelBalance = data.SteelBalance;
        this.MortarBulletBalance = data.MortarBulletBalance;
        this.AdvancedCircuitBoardBalance = data.AdvancedCircuitBoardBalance;

    }

    public void PostInstantiation(object state)
    {
        BuildData data = (BuildData)state;
    }

    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {
        throw new System.NotImplementedException();
    }
    #endregion

}
