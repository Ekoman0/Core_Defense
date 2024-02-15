using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveLoadSystem;
using UnityEngine.Localization.Settings;

public class FactoryWork : MonoBehaviour, ISaveable
{
    public AudioSource FactoryWorkAs;
    //timer
    private float BulletTimer = 1f;
    private float IronBarTimer = 1f;
    private float PowderTimer = 1f;
    private float GearTimer = 1f;
    private float CopperWireTimer = 1f;
    private float CircuitBoardTimer = 1f;
    private float SteelTimer = 1f;
    private float MortarBulletTimer = 1f;
    private float AdvancedCircuitBoardTimer = 1f;


    private GameObject GameManager;
    public ParticleSystem Crafteffect;
    [Header("Page")]
    public GameObject FactoryCanvasImage;
    public GameObject LimitationCanvasImage;
    public Image FactoryNailMainPage;
    public Image FactoryMagazineMainPage;
    public Image FactoryUpPage;
    public Image FactoryToolPage;

    [Header("Make Button")]
    public Button BulletButton;
    public Button IronBarButton;
    public Button PowderButton;
    public Button GearButton;
    public Button CopperWireButton;
    public Button CircuitBoardButton;
    public Button SteelButton;
    public Button MortarBulletButton;
    public Button AdvancedCircuitBoardButton;




    [Header("Button")]
    public Button NextLimitationButton;
    public Button PreviousFactoryButton;
    public TextMeshProUGUI ObjectPrice2;

    //Selected
    [SerializeField] private bool BulletButtonSelected = false;
    private bool IronBarButtonSelected = false;
    private bool PowderButtonSelected = false;
    private bool GearButtonSelected = false;
    private bool CopperWireButtonSelected = false;
    private bool CircuitBoardButtonSelected = false;
    private bool SteelButtonSelected = false;
    private bool MortarBulletButtonSelected = false;
    private bool AdvancedCircuitBoardButtonSelected = false;


    public bool Work = false;
    private bool ÝtemSelectedWork = false;
    private bool WarningBool = false;


    [Header("Limitation")]
    public LimitationScriptableOBjects[] LimitationSCB;
    public TextMeshProUGUI ObjectPrice;
    public Image ObjectIcon;
    public TextMeshProUGUI LimitationSliderValuetxt;  
    public Slider LimitationSlider;
    public TextMeshProUGUI Warning;
    private int RandomEvents=-1;
    //limitation

    [Header("InFactoryImage")]
    public Image Bulletimginfctry;
    public Image IronBarimginfctry;
    public Image Powderimginfctry;
    public Image Gearimginfctry;
    public Image CopperWireimginfctry;
    public Image CircuitBoardimginfctry;
    public Image Steelimginfctry;
    public Image MortarBulletimginfctry;
    public Image AdvancedCircuitBoardimginfctry;

    [System.Serializable]
    struct FactoryData
    {

        public bool BulletButtonSelected;
        public bool IronBarButtonSelected;
        public bool PowderButtonSelected;
        public bool GearButtonSelected;
        public bool CopperWireButtonSelected;
        public bool CircuitBoardButtonSelected;
        public bool SteelButtonSelected;
        public bool MortarBulletButtonSelected;
        public bool AdvancedCircuitBoardButtonSelected;

        public int RandomEvents;

     
    }


    // Start is called before the first frame update

    void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");

        FactoryMagazineMainPage.gameObject.SetActive(false);

        FactoryCanvasImage.gameObject.SetActive(false);
        LimitationCanvasImage.gameObject.SetActive(false);


        


        AllInFactoryImageFalse();
        NextLimitationButtonvoid();
        LimitationSlider.value = LimitationSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (ÝtemSelectedWork == true)//eðer Makine Çalýþýyorsa Ýþlem Yap
        {
            if (WarningBool == true && Work == true)
            {
                Warning.gameObject.SetActive(false);
                WarningBool = false;
            }
            
            work();
        }
        LimitationSliderValuetxt.text = LimitationSlider.value.ToString();
        PrintLimitation();

        if (Work == false && WarningBool == false)
        {
            
            Warning.gameObject.SetActive(true);
            WarningBool = true;
        }
        
    }

    public void CloseFactory()
    {
        FactoryCanvasImage.gameObject.SetActive(false);
    }
    public void CloseLimitation()
    {
        LimitationCanvasImage.gameObject.SetActive(false);
    }

    void CloseAllMainPage()
    {
        FactoryMagazineMainPage.gameObject.SetActive(false);
        FactoryNailMainPage.gameObject.SetActive(false);

    }
    public void OpenMagazineMainPage()
    {
        CloseAllMainPage();
        FactoryMagazineMainPage.gameObject.SetActive(true);
    }
    public void OpenNailMainPage()
    {
        CloseAllMainPage();
        FactoryNailMainPage.gameObject.SetActive(true);
    }


    public void BulletÝtem()
    {
        ButtonColorClear();
        BulletButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        // yukarýsý renk kýsmý
        AllSelectdedFalse();
        BulletButtonSelected = true;
        RandomEvents = 0;
        //yukarýsý Selected
        

    }
    public void IronBarÝtem()
    {
        ButtonColorClear();
        IronBarButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        // yukarýsý renk kýsmý
        AllSelectdedFalse();
        IronBarButtonSelected = true;
        RandomEvents = 1;
        //yukarýsý Selected
        


    }
    public void PowderÝtem()
    {
        ButtonColorClear();
        PowderButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        // yukarýsý renk kýsmý
        AllSelectdedFalse();
        PowderButtonSelected = true;
        RandomEvents = 2;
        //yukarýsý Selected
        


    }
    public void GearÝtem()
    {
        ButtonColorClear();
        GearButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        // yukarýsý renk kýsmý
        AllSelectdedFalse();
        GearButtonSelected = true;
        RandomEvents = 3;
        //yukarýsý Selected



    }
    public void CopperWireÝtem()
    {
        ButtonColorClear();
        CopperWireButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        // yukarýsý renk kýsmý
        AllSelectdedFalse();
        CopperWireButtonSelected = true;
        RandomEvents = 4;
        //yukarýsý Selected



    }

    public void CircuitBoardÝtem()
    {
        ButtonColorClear();
        CircuitBoardButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        // yukarýsý renk kýsmý
        AllSelectdedFalse();
        CircuitBoardButtonSelected = true;
        RandomEvents = 5;
        //yukarýsý Selected
    }

    public void SteelÝtem()
    {
        ButtonColorClear();
        SteelButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        // yukarýsý renk kýsmý
        AllSelectdedFalse();
        SteelButtonSelected = true;
        RandomEvents = 6;
        //yukarýsý Selected
    }

    public void MortarBulletÝtem()
    {
        ButtonColorClear();
        MortarBulletButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        // yukarýsý renk kýsmý
        AllSelectdedFalse();
        MortarBulletButtonSelected = true;
        RandomEvents = 7;
        //yukarýsý Selected
    }
    public void AdvancedCircuitBoardÝtem()
    {
        ButtonColorClear();
        AdvancedCircuitBoardButton.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
        // yukarýsý renk kýsmý
        AllSelectdedFalse();
        AdvancedCircuitBoardButtonSelected = true;
        RandomEvents = 8;
        //yukarýsý Selected
    }


    //Yukarýsý Mainde Seçilenler




    public void NextLimitationButtonvoid()
    {
        if (BulletButtonSelected == true)
        {
            FactoryCanvasImage.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("GameSave") == 0 || !PlayerPrefs.HasKey("GameSave"))// DATA Bugý Çözmek Ýçin 
            {
                LimitationCanvasImage.gameObject.SetActive(true);
            }
            
            ÝtemSelectedWork = true;

            AllInFactoryImageFalse();
            Bulletimginfctry.gameObject.SetActive(true);
            //yukarýsý Factorynin icindeki resim

        }
        if (IronBarButtonSelected == true)
        {
            FactoryCanvasImage.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("GameSave") == 0 || !PlayerPrefs.HasKey("GameSave"))// DATA Bugý Çözmek Ýçin 
            {
                LimitationCanvasImage.gameObject.SetActive(true);
            }
            ÝtemSelectedWork = true;

            AllInFactoryImageFalse();
            IronBarimginfctry.gameObject.SetActive(true);
            //yukarýsý Factorynin icindeki resim

        }
        if (PowderButtonSelected == true)
        {
            FactoryCanvasImage.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("GameSave") == 0 || !PlayerPrefs.HasKey("GameSave"))// DATA Bugý Çözmek Ýçin 
            {
                LimitationCanvasImage.gameObject.SetActive(true);
            }
            ÝtemSelectedWork = true;

            AllInFactoryImageFalse();
            Powderimginfctry.gameObject.SetActive(true);
            //yukarýsý Factorynin icindeki resim
        }
        if (GearButtonSelected == true)
        {
            FactoryCanvasImage.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("GameSave") == 0 || !PlayerPrefs.HasKey("GameSave"))// DATA Bugý Çözmek Ýçin 
            {
                LimitationCanvasImage.gameObject.SetActive(true);
            }
            ÝtemSelectedWork = true;

            AllInFactoryImageFalse();
            Gearimginfctry.gameObject.SetActive(true);
            //yukarýsý Factorynin icindeki resim
        }
        if (CopperWireButtonSelected == true)
        {
            FactoryCanvasImage.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("GameSave") == 0 || !PlayerPrefs.HasKey("GameSave"))// DATA Bugý Çözmek Ýçin 
            {
                LimitationCanvasImage.gameObject.SetActive(true);
            }
            ÝtemSelectedWork = true;
            //yukarýya dokunma

            AllInFactoryImageFalse();
            CopperWireimginfctry.gameObject.SetActive(true);
            //yukarýsý Factorynin icindeki resim
        }
        if (CircuitBoardButtonSelected == true)
        {
            FactoryCanvasImage.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("GameSave") == 0 || !PlayerPrefs.HasKey("GameSave"))// DATA Bugý Çözmek Ýçin 
            {
                LimitationCanvasImage.gameObject.SetActive(true);
            }
            ÝtemSelectedWork = true;
            //yukarýya dokunma

            AllInFactoryImageFalse();
            CircuitBoardimginfctry.gameObject.SetActive(true);
            //yukarýsý Factorynin icindeki resim
        }
        if (SteelButtonSelected == true)
        {
            FactoryCanvasImage.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("GameSave") == 0 || !PlayerPrefs.HasKey("GameSave"))// DATA Bugý Çözmek Ýçin 
            {
                LimitationCanvasImage.gameObject.SetActive(true);
            }
            ÝtemSelectedWork = true;
            //yukarýya dokunma

            AllInFactoryImageFalse();
            Steelimginfctry.gameObject.SetActive(true);
            //yukarýsý Factorynin icindeki resim
        }
        if (MortarBulletButtonSelected == true)
        {
            FactoryCanvasImage.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("GameSave") == 0 || !PlayerPrefs.HasKey("GameSave"))// DATA Bugý Çözmek Ýçin 
            {
                LimitationCanvasImage.gameObject.SetActive(true);
            }
            ÝtemSelectedWork = true;
            //yukarýya dokunma

            AllInFactoryImageFalse();
            MortarBulletimginfctry.gameObject.SetActive(true);
            //yukarýsý Factorynin icindeki resim
        }
        if (AdvancedCircuitBoardButtonSelected == true)
        {
            FactoryCanvasImage.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("GameSave") == 0 || !PlayerPrefs.HasKey("GameSave"))// DATA Bugý Çözmek Ýçin 
            {
                LimitationCanvasImage.gameObject.SetActive(true);
            }
            ÝtemSelectedWork = true;
            //yukarýya dokunma

            AllInFactoryImageFalse();
            AdvancedCircuitBoardimginfctry.gameObject.SetActive(true);
            //yukarýsý Factorynin icindeki resim
        }
    }
    public void PreviousLimitationButtonvoid()
    {
        LimitationCanvasImage.gameObject.SetActive(false);
        FactoryCanvasImage.gameObject.SetActive(true);

    }

    private void ButtonColorClear()//bütün butonlarýn rengini beyaz yapar
    {
        BulletButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        IronBarButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        PowderButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        GearButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        CopperWireButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        CircuitBoardButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        SteelButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        MortarBulletButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        AdvancedCircuitBoardButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);



    }
    private void AllSelectdedFalse()//bütün butonlarýn seçilmesini false yapar
    {
        BulletButtonSelected = false;
        IronBarButtonSelected = false;
        PowderButtonSelected= false;
        GearButtonSelected= false;
        CopperWireButtonSelected = false;
        CircuitBoardButtonSelected= false;
        SteelButtonSelected= false;
        MortarBulletButtonSelected= false;
        AdvancedCircuitBoardButtonSelected= false;

    }

    private void PrintLimitation()//Limitation Sayfasýna SCB yi yazar
    {
        if (RandomEvents >-1)
        {
            ObjectPrice.text = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", LimitationSCB[RandomEvents].ObjectPrice); 
            ObjectPrice2.text = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", LimitationSCB[RandomEvents].ObjectPrice);

            ObjectIcon.sprite = LimitationSCB[RandomEvents].ObjectIcon;

        }

    }
    private void AllInFactoryImageFalse()//bütün butonlarýn seçilmesini false yapar
    {
        Bulletimginfctry.gameObject.SetActive(false);
        IronBarimginfctry.gameObject.SetActive(false);
        Powderimginfctry.gameObject.SetActive(false);
        Gearimginfctry.gameObject.SetActive(false);
        CopperWireimginfctry.gameObject.SetActive(false);
        CircuitBoardimginfctry.gameObject.SetActive(false);
        Steelimginfctry.gameObject.SetActive(false);
        MortarBulletimginfctry.gameObject.SetActive(false);
        AdvancedCircuitBoardimginfctry.gameObject.SetActive(false);



    }
    private void work() // makine Çalýþýyor
    {
        if (RandomEvents == 0 && ÝtemSelectedWork == true) 
        {
            if (BulletTimer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().BulletBalance < LimitationSlider.value )//maks mermiden azsa üretsin
                {
                    if (GameManager.GetComponent<BuildSystem>().IronBalance > 0 && GameManager.GetComponent<BuildSystem>().PowderBalance > 0)//eðer Demirimiz varsa ve barut varsa
                    {
                        GameManager.GetComponent<BuildSystem>().IronBalance -= 1; // 1 Demir tüket
                        GameManager.GetComponent<BuildSystem>().PowderBalance -= 1; // 1 Barut tüket

                        GameManager.GetComponent<BuildSystem>().BulletBalance += 3;//1 Mermi üret
                        Crafteffect.Play();
                        BulletTimer = 1f;
                        Work = true;
                        if (FactoryWorkAs.isPlaying == false)
                        {
                            FactoryWorkAs.Play();
                        }
                    }
                    else
                    {
                        Work = false;
                    }
                }


            }
            if (BulletTimer > -2)
            {
                BulletTimer -= Time.deltaTime;
            }
        }
        //BULLET

        if (RandomEvents == 1 && ÝtemSelectedWork == true)
        {
            if (IronBarTimer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().IronBarBalance < LimitationSlider.value)//maks mermiden azsa üretsin
                {
                    if (GameManager.GetComponent<BuildSystem>().IronBalance > 0)//eðer Demirimiz varsa
                    {
                        GameManager.GetComponent<BuildSystem>().IronBalance -= 1; // 1 Demir tüket
                        GameManager.GetComponent<BuildSystem>().IronBarBalance += 2;//2 Demir Çubuküret
                        Crafteffect.Play();
                        IronBarTimer = 1f;
                        Work = true;
                        if (FactoryWorkAs.isPlaying == false)
                        {
                            FactoryWorkAs.Play();
                        }
                    }
                    else
                    {
                        Work = false;
                    }
                }


            }
            if (IronBarTimer > -2)
            {
                IronBarTimer -= Time.deltaTime;
            }
        }

        //IRONBAR

        if (RandomEvents == 2 && ÝtemSelectedWork == true)
        {
            if (PowderTimer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().PowderBalance < LimitationSlider.value)//maks mermiden azsa üretsin
                {
                    if (GameManager.GetComponent<BuildSystem>().CoalBalance > 0)//eðer Demirimiz varsa
                    {
                        GameManager.GetComponent<BuildSystem>().CoalBalance -= 1; // 1 k tömür üket
                        GameManager.GetComponent<BuildSystem>().PowderBalance += 5;//5 barut üret
                        Crafteffect.Play();
                        PowderTimer = 1f;
                        Work = true;
                        if (FactoryWorkAs.isPlaying == false)
                        {
                            FactoryWorkAs.Play();
                        }
                    }
                    else
                    {
                        Work = false;
                    }
                }


            }
            if (PowderTimer > -2)
            {
                PowderTimer -= Time.deltaTime;
            }
        }
        //POWDER
        if (RandomEvents == 3 && ÝtemSelectedWork == true)
        {
            if (GearTimer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().GearBalance < LimitationSlider.value)//maks mermiden azsa üretsin
                {
                    if (GameManager.GetComponent<BuildSystem>().IronBalance > 0)//eðer Demirimiz varsa
                    {
                        GameManager.GetComponent<BuildSystem>().IronBalance -= 2; //2 Demir tüket
                        GameManager.GetComponent<BuildSystem>().GearBalance += 1;//1 Çarklý üret
                        Crafteffect.Play();
                        GearTimer = 1f;
                        Work = true;
                        if (FactoryWorkAs.isPlaying == false)
                        {
                            FactoryWorkAs.Play();
                        }
                    }
                    else
                    {
                        Work = false;
                    }
                }


            }
            if (GearTimer > -2)
            {
                GearTimer -= Time.deltaTime;
            }
        }
        //GEAR

        if (RandomEvents == 4 && ÝtemSelectedWork == true)
        {
            if (CopperWireTimer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().CopperWireBalance < LimitationSlider.value)//maks mermiden azsa üretsin
                {
                    if (GameManager.GetComponent<BuildSystem>().CopperBalance > 0)//eðer Demirimiz varsa
                    {
                        GameManager.GetComponent<BuildSystem>().CopperBalance -= 1; //1 Bakýr tüket
                        GameManager.GetComponent<BuildSystem>().CopperWireBalance += 2;//2 Bakýr Tel üret
                        Crafteffect.Play();
                        CopperWireTimer = 1f;
                        Work = true;
                        if (FactoryWorkAs.isPlaying == false)
                        {
                            FactoryWorkAs.Play();
                        }
                    }
                    else
                    {
                        Work = false;
                    }
                }
                
                
            }
            if (CopperWireTimer > -2)
            {
                CopperWireTimer -= Time.deltaTime;
            }
            
        }
        //CopperWire

        if (RandomEvents == 5 && ÝtemSelectedWork == true)
        {
            if (CircuitBoardTimer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().CircuitBoardBalance < LimitationSlider.value)//maks mermiden azsa üretsin
                {
                    if (GameManager.GetComponent<BuildSystem>().CopperWireBalance > 2 && GameManager.GetComponent<BuildSystem>().IronBalance > 0)//eðer Demirimiz varsa
                    {
                        GameManager.GetComponent<BuildSystem>().CopperWireBalance -= 3; //3 Bakýr Tel tüket
                        GameManager.GetComponent<BuildSystem>().IronBalance -= 1; //1 demir tüket
                        GameManager.GetComponent<BuildSystem>().CircuitBoardBalance += 1;//1 Devre Kartý üret
                        Crafteffect.Play();
                        CircuitBoardTimer = 4f;
                        Work = true;
                        if (FactoryWorkAs.isPlaying == false)
                        {
                            FactoryWorkAs.Play();
                        }
                    }
                    else
                    {
                        Work = false;
                    }
                }


            }
            if (CircuitBoardTimer > -2)
            {
                CircuitBoardTimer -= Time.deltaTime;
            }
        }
        //CopperWire

        if (RandomEvents == 6 && ÝtemSelectedWork == true)
        {
            if (SteelTimer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().SteelBalance < LimitationSlider.value)//maks mermiden azsa üretsin
                {
                    if (GameManager.GetComponent<BuildSystem>().IronBalance > 4)//eðer Demirimiz varsa
                    {
                        
                        GameManager.GetComponent<BuildSystem>().IronBalance -= 5; //5 demir tüket
                        GameManager.GetComponent<BuildSystem>().SteelBalance += 1;//1 Steel üret
                        Crafteffect.Play();
                        SteelTimer = 4f;
                        Work = true;
                        if (FactoryWorkAs.isPlaying == false)
                        {
                            FactoryWorkAs.Play();
                        }
                    }
                    else
                    {
                        Work = false;
                    }
                }


            }
            if (SteelTimer > -2)
            {
                SteelTimer -= Time.deltaTime;
            }
        }
        //CopperWire

        if (RandomEvents == 7 && ÝtemSelectedWork == true)
        {
            if (MortarBulletTimer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().MortarBulletBalance < LimitationSlider.value)//maks mermiden azsa üretsin
                {
                    if (GameManager.GetComponent<BuildSystem>().PowderBalance > 1 && GameManager.GetComponent<BuildSystem>().SteelBalance > 0)//eðer Demirimiz varsa
                    {

                        GameManager.GetComponent<BuildSystem>().PowderBalance -= 2; //2 barut tüket
                        GameManager.GetComponent<BuildSystem>().SteelBalance -= 1; //1 çelik tüket
                        GameManager.GetComponent<BuildSystem>().MortarBulletBalance += 1;//1 Steel üret
                        Crafteffect.Play();
                        MortarBulletTimer = 1f;
                        Work = true;
                        if (FactoryWorkAs.isPlaying == false)
                        {
                            FactoryWorkAs.Play();
                        }
                    }
                    else
                    {
                        Work = false;
                    }
                }


            }
            if (MortarBulletTimer > -2)
            {
                MortarBulletTimer -= Time.deltaTime;
            }
        }
        //MortarBullet

        if (RandomEvents == 8 && ÝtemSelectedWork == true)
        {
            if (AdvancedCircuitBoardTimer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().AdvancedCircuitBoardBalance < LimitationSlider.value)//maks mermiden azsa üretsin
                {
                    if (GameManager.GetComponent<BuildSystem>().CircuitBoardBalance > 0 && GameManager.GetComponent<BuildSystem>().UraniumBalance > 1)//eðer Demirimiz varsa
                    {

                        GameManager.GetComponent<BuildSystem>().CircuitBoardBalance -= 1; //2 barut tüket
                        GameManager.GetComponent<BuildSystem>().UraniumBalance -= 2; //1 çelik tüket
                        GameManager.GetComponent<BuildSystem>().AdvancedCircuitBoardBalance += 1;//1 Steel üret
                        Crafteffect.Play();
                        AdvancedCircuitBoardTimer = 1f;
                        Work = true;
                        if (FactoryWorkAs.isPlaying == false)
                        {
                            FactoryWorkAs.Play();
                        }
                    }
                    else
                    {
                        Work = false;
                    }
                }


            }
            if (AdvancedCircuitBoardTimer > -2)
            {
                AdvancedCircuitBoardTimer -= Time.deltaTime;
            }
        }
        //MortarBullet
    }

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
        return new FactoryData()
        {
            BulletButtonSelected = BulletButtonSelected,
            IronBarButtonSelected = IronBarButtonSelected,
            PowderButtonSelected = PowderButtonSelected,
            GearButtonSelected = GearButtonSelected,
            CopperWireButtonSelected = CopperWireButtonSelected,
            CircuitBoardButtonSelected = CircuitBoardButtonSelected,
            SteelButtonSelected = SteelButtonSelected,
            MortarBulletButtonSelected = MortarBulletButtonSelected,
            AdvancedCircuitBoardButtonSelected = AdvancedCircuitBoardButtonSelected,

            RandomEvents = RandomEvents

            
        };

    }

    public void LoadState(object state)
    {
      FactoryData data=(FactoryData)state;
        this.BulletButtonSelected = data.BulletButtonSelected;
        this.IronBarButtonSelected = data.IronBarButtonSelected;
        this.PowderButtonSelected = data.PowderButtonSelected;
        this.GearButtonSelected = data.GearButtonSelected;
        this.CopperWireButtonSelected = data.CopperWireButtonSelected;
        this.CircuitBoardButtonSelected = data.CircuitBoardButtonSelected;
        this.SteelButtonSelected = data.SteelButtonSelected;
        this.MortarBulletButtonSelected = data.MortarBulletButtonSelected;
        this.AdvancedCircuitBoardButtonSelected = data.AdvancedCircuitBoardButtonSelected;

        this.RandomEvents = data.RandomEvents;


    }

    public void PostInstantiation(object state)
    {
        FactoryData data = (FactoryData)state;
    }

    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {
        throw new System.NotImplementedException();
    }
}
