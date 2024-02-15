using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Balance : MonoBehaviour
{
    public GameObject GameManager;
    private float IronBalance;
    private float CoalBalance;
    private float CopperBalance;
    private float UraniumBalance;
    private float ElectricBalance;
    private float IronBarBalance;
    private float PowderBalance;
    private float BulletBalance;
    private float GearBalance;
    private float CopperWireBalance;
    private float CircuitBoardBalance;
    private float SteelBalance;
    private float MortarBulletBalance;
    private float AdvancedCircuitBoardBalance;

    [Header("GUI")]
    public Image BalanceOreMain;
    public Image BalanceNailMain;
    public Image BalanceMagazineMain;

    [Header("BALANCE TXT")]
    public TextMeshProUGUI IronBalancetxt;
    public TextMeshProUGUI CoalBalancetxt;
    public TextMeshProUGUI CopperBalancetxt;
    public TextMeshProUGUI UraniumBalancetxt;
    public TextMeshProUGUI ElectricBalancetxt;
    public TextMeshProUGUI IronBarBalancetxt;
    public TextMeshProUGUI PowderBalancetxt;
    public TextMeshProUGUI BulletBalancetxt;
    public TextMeshProUGUI GearBalancetxt;
    public TextMeshProUGUI CopperWireBalancetxt;
    public TextMeshProUGUI CircuitBoardBalancetxt;
    public TextMeshProUGUI SteelBalancetxt;
    public TextMeshProUGUI MortarBulletBalancetxt;
    public TextMeshProUGUI AdvancedCircuitBoardtxt;


    [Header("BUTTON")]
    public Button OpenBalanceButton;
    public Button CloseBalanceButton;
    public GameObject BalanceImage;




    // Start is called before the first frame update
    void Start()
    {
        BalanceImage.gameObject.SetActive(false);
        AllFalseBalanceMain();
        BalanceOreMain.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        IronBalance = GameManager.GetComponent<BuildSystem>().IronBalance;
        CoalBalance = GameManager.GetComponent<BuildSystem>().CoalBalance;
        CopperBalance= GameManager.GetComponent<BuildSystem>().CopperBalance;
        UraniumBalance = GameManager.GetComponent<BuildSystem>().UraniumBalance;
        ElectricBalance = GameManager.GetComponent<BuildSystem>().ElectricBalance;
        IronBarBalance = GameManager.GetComponent<BuildSystem>().IronBarBalance;
        PowderBalance = GameManager.GetComponent<BuildSystem>().PowderBalance;
        BulletBalance = GameManager.GetComponent<BuildSystem>().BulletBalance;
        GearBalance= GameManager.GetComponent<BuildSystem>().GearBalance;
        CopperWireBalance = GameManager.GetComponent<BuildSystem>().CopperWireBalance;
        CircuitBoardBalance = GameManager.GetComponent<BuildSystem>().CircuitBoardBalance;
        SteelBalance = GameManager.GetComponent<BuildSystem>().SteelBalance;
        MortarBulletBalance = GameManager.GetComponent<BuildSystem>().MortarBulletBalance;
        AdvancedCircuitBoardBalance = GameManager.GetComponent<BuildSystem>().AdvancedCircuitBoardBalance;




        if (IronBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            IronBalancetxt.text = (IronBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            IronBalancetxt.text = IronBalance.ToString();
        }

        if (CoalBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            CoalBalancetxt.text = (CoalBalance/ 1000).ToString("F1") + "k";
        }
        else
        {
            CoalBalancetxt.text =  CoalBalance.ToString();
        }

        if (CopperBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            CopperBalancetxt.text = (CopperBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            CopperBalancetxt.text = CopperBalance.ToString();
        }

        if (UraniumBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            UraniumBalancetxt.text = (UraniumBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            UraniumBalancetxt.text = UraniumBalance.ToString();
        }

        if (ElectricBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            ElectricBalancetxt.text =  (ElectricBalance/ 1000).ToString("F1") + "kW";
        }
        else
        {
            ElectricBalancetxt.text =  ElectricBalance.ToString() + "W";
        }

        if (IronBarBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            IronBarBalancetxt.text = (IronBarBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            IronBarBalancetxt.text = IronBarBalance.ToString();
        }

        if (PowderBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            PowderBalancetxt.text = (PowderBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            PowderBalancetxt.text = PowderBalance.ToString();
        }

        if (BulletBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            BulletBalancetxt.text = (BulletBalance/ 1000).ToString("F1") + "k";
        }
        else
        {
            BulletBalancetxt.text = BulletBalance.ToString();
        }

        if (GearBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            GearBalancetxt.text = (GearBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            GearBalancetxt.text = GearBalance.ToString();
        }

        if (CopperWireBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            CopperWireBalancetxt.text = (CopperWireBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            CopperWireBalancetxt.text = CopperWireBalance.ToString();
        }

        if (CircuitBoardBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            CircuitBoardBalancetxt.text = (CircuitBoardBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            CircuitBoardBalancetxt.text = CircuitBoardBalance.ToString();
        }
        if (SteelBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            SteelBalancetxt.text = (SteelBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            SteelBalancetxt.text = SteelBalance.ToString();
        }
        if (MortarBulletBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            MortarBulletBalancetxt.text = (MortarBulletBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            MortarBulletBalancetxt.text = MortarBulletBalance.ToString();
        }
        if (AdvancedCircuitBoardBalance > 1000) //eðer 1000 den büyük olusa onu 1k ya çevirmek için
        {
            AdvancedCircuitBoardtxt.text = (AdvancedCircuitBoardBalance / 1000).ToString("F1") + "k";
        }
        else
        {
            AdvancedCircuitBoardtxt.text = AdvancedCircuitBoardBalance.ToString();
        }


    }
    public void OpenBalance()
    {
        OpenBalanceButton.gameObject.SetActive(false);
        BalanceImage.gameObject.SetActive(true);

    }
    public void CloseBalance()
    {
        BalanceImage.gameObject.SetActive(false);
        OpenBalanceButton.gameObject.SetActive(true);

    }
    public void BalanceOreMainvoid()
    {
        AllFalseBalanceMain();
        BalanceOreMain.gameObject.SetActive(true);
        
    }
    public void BalanceNailMainvoid()
    {
        AllFalseBalanceMain();
        BalanceNailMain.gameObject.SetActive(true);

    }
    public void BalanceMagazineMainvoid()
    {
        AllFalseBalanceMain();
        BalanceMagazineMain.gameObject.SetActive(true);

    }
    private void AllFalseBalanceMain()
    {
        BalanceNailMain.gameObject.SetActive(false);
        BalanceOreMain.gameObject.SetActive(false);
        BalanceMagazineMain.gameObject.SetActive(false);

    }
}
