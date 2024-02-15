using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class InfoCard : MonoBehaviour
{
    private string k="k";
    private string ýronbark="k";
    private string geark="k";
    private string wirek="k";
    private string boardk="k";
    private string steelk="k";
    private string uraniumk="k";
    private string advancedboardk="k";

    private string f1 = "F1";
    private string ýronbarf1 = "F1";
    private string gearf1 = "F1";
    private string wiref1 = "F1";
    private string boardf1 = "F1";
    private string steelf1 = "F1";
    private string uraniumf1 = "F1";
    private string advancedboardf1 = "F1";
    // Start is called before the first frame update
    private float IronBalance;
    private float IronBarBalance;
    private float GearBalance;
    private float CopperWireBalance;
    private float CircuitBoardBalance;
    private float SteelBalance;
    private float UraniumBalance;
    private float AdvancedCircuitBoardBalance;

    string IronTranslate;
    string IronBarTranslate;
    string GearTranslate;
    string CopperWireTranslate;
    string CircuitBoardTranslate;
    string SteelTranslate;
    string UraniumTranslate;
    string AdvancedCircuitBoardTranslate;

    public InfoScriptableObject[] card;
    private int RandomEvents;
    public TextMeshProUGUI ObjectName;
    public TextMeshProUGUI ObjectPrice;
    public Image ObjectIcon;
    public Image ElectricIcon;
    public GameObject BuildSystem;

    public LocalizedString nameKey;


    public void Translate()
    {
        IronTranslate = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", "Demir");
        IronBarTranslate = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", "Demir Çubuk");
        GearTranslate = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", "Diþli Çark");
        CopperWireTranslate = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", "Bakýr Tel");
        CircuitBoardTranslate = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", "Devre Kartý");
        SteelTranslate = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", "Çelik");
        UraniumTranslate = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", "Uranyum");
        AdvancedCircuitBoardTranslate = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", "Geliþmiþ Devre Kartý");
    }
    public void Show()
    {
       
        ObjectName.text = LocalizationSettings.StringDatabase.GetLocalizedString("Lvl1", card[RandomEvents].ObjectName);     
        ObjectIcon.sprite = card[RandomEvents].ObjectIcon;
        BuildSystem.GetComponent<BuildSystem>().InfoCanvas.gameObject.SetActive(true);
        if (card[RandomEvents].iselectricy == true)
        {
            ElectricIcon.enabled = true;
        }
        else
        {
            ElectricIcon.enabled = false;
            
        }
    }


   
    private void Awake()
    {
        Translate();
    }
    private void Start()
    {
        BuildSystem.GetComponent<BuildSystem>().InfoCanvas.gameObject.SetActive(false);
    }
    private void Update()
    {
        IronBalance = BuildSystem.GetComponent<BuildSystem>().IronBalance;
        IronBarBalance = BuildSystem.GetComponent<BuildSystem>().IronBarBalance;
        GearBalance = BuildSystem.GetComponent<BuildSystem>().GearBalance;
        CopperWireBalance = BuildSystem.GetComponent<BuildSystem>().CopperWireBalance;
        CircuitBoardBalance = BuildSystem.GetComponent<BuildSystem>().CircuitBoardBalance;
        SteelBalance = BuildSystem.GetComponent<BuildSystem>().SteelBalance;
        UraniumBalance = BuildSystem.GetComponent<BuildSystem>().UraniumBalance;
        AdvancedCircuitBoardBalance = BuildSystem.GetComponent<BuildSystem>().AdvancedCircuitBoardBalance;

        if (IronBalance > 1000)
        {
            IronBalance = IronBalance / 1000;
            k = "k";
            f1 = "F1";
        }
        else
        {
            k = "";
            f1 = "F0";
        }

        if (IronBarBalance >1000)
        {
            IronBarBalance = IronBarBalance / 1000;
            ýronbark = "k";
            ýronbarf1 = "F1";
        }
        else
        {
            ýronbark = "";
            ýronbarf1 = "F0";
        }

        if (GearBalance > 1000)
        {
            GearBalance = GearBalance / 1000;
            geark = "k";
            gearf1 = "F1";
        }
        else
        {
            geark = "";
            gearf1 = "F0";
        }

        if (CopperWireBalance > 1000)
        {
            CopperWireBalance = CopperWireBalance / 1000;
            wirek = "k";
            wiref1 = "F1";
        }
        else
        {
            wirek = "";
            wiref1 = "F0";
        }

        if (CircuitBoardBalance > 1000)
        {
            CircuitBoardBalance = CircuitBoardBalance / 1000;
            boardk = "k";
            boardf1 = "F1";
        }
        else
        {
            boardk = "";
            boardf1 = "F0";
        }

        if (SteelBalance > 1000)
        {
            SteelBalance = SteelBalance / 1000;
            steelk = "k";
            steelf1 = "F1";
        }
        else
        {
            steelk = "";
            steelf1 = "F0";
        }

        if (UraniumBalance > 1000)
        {
            UraniumBalance = UraniumBalance / 1000;
            uraniumk = "k";
            uraniumf1= "F1";
        }
        else
        {
            uraniumk = "";
            uraniumf1 = "F0";
        }

        if (AdvancedCircuitBoardBalance > 1000)
        {
            AdvancedCircuitBoardBalance = AdvancedCircuitBoardBalance / 1000;
            advancedboardk = "k";
            advancedboardf1 = "F1";
        }
        else
        {
            advancedboardk = "";
            advancedboardf1 = "F0";
        }


        //--------------------ENVANTERDEKÝ PARAMIZI ANLIK OLARAK YAZDIRIR VE OBJELERÝN FÝYATINI DA YAZDIRIR---------------------
        //WOODEN DRÝLL
        if (RandomEvents == 0)
        {
            
            ObjectPrice.text = IronTranslate +" "+ IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().woodenDrillPrice.ToString();
        
        }
        
        //WOODEN TURRET

        else if (RandomEvents == 1)
        {
            
            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().woodenTurretPrice.ToString() + " | " + IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark + " / " + BuildSystem.GetComponent<BuildSystem>().woodenTurretIronBarPrice.ToString() + " | " + GearTranslate + " " + GearBalance.ToString(gearf1) + geark + " / " + BuildSystem.GetComponent<BuildSystem>().woodenTurretGearPrice.ToString();
        
        }


        //HEALTH  REGEN
        else if (RandomEvents == 2)
        {
          
            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().HealthRegenPrice.ToString() + " | " + CopperWireTranslate + " " + CopperWireBalance.ToString(wiref1) + wirek + " / " + BuildSystem.GetComponent<BuildSystem>().HealthRegenCopperWirePrice.ToString() + " | " + CircuitBoardTranslate + " " + CircuitBoardBalance.ToString(boardf1) + boardk + " / " + BuildSystem.GetComponent<BuildSystem>().HealthRegenCircuitBoardPrice.ToString();
        }
        
        //COAL TO ELECTRÝC
        else if (RandomEvents == 3)
        {
            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().CoaltoElectricPrice.ToString() + " | " + CopperWireTranslate + " " + CopperWireBalance.ToString(wiref1) +wirek + " / " + BuildSystem.GetComponent<BuildSystem>().CoaltoElectricCopperWirePrice.ToString() + " | " + CircuitBoardTranslate + " " + CircuitBoardBalance.ToString(boardf1) + boardk + " / " + BuildSystem.GetComponent<BuildSystem>().CoaltoElectricCircuitBoardPrice.ToString();
        }
        //Factory
        else if (RandomEvents == 4)
        {
           
            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().FactoryPrice.ToString();
        }
        //IRON WALL
        else if (RandomEvents == 5)
        {
           
            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().IronWallPrice.ToString();
        }

        //IRON DRILL
        else if (RandomEvents == 6)
        {
           
            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k +" / " + BuildSystem.GetComponent<BuildSystem>().IronDrillPrice.ToString() + " | " + IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark + " / " + BuildSystem.GetComponent<BuildSystem>().IronDrillIronBarPrice.ToString() + " | " + GearTranslate + " " + GearBalance.ToString(gearf1) + geark + " / " + BuildSystem.GetComponent<BuildSystem>().IronDrillGearPrice.ToString();

        }

        //ELECTRIC DRILL
        else if (RandomEvents == 7)
        {
           
            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k+ " / " + BuildSystem.GetComponent<BuildSystem>().ElectricDrillPrice.ToString() + " | " + IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark+ " / " + BuildSystem.GetComponent<BuildSystem>().ElectricDrillIronBarPrice.ToString() + " | " + GearTranslate + " " + GearBalance.ToString(gearf1) + geark + " / " + BuildSystem.GetComponent<BuildSystem>().ElectricDrillGearPrice.ToString() + " | " + CopperWireTranslate + " " + CopperWireBalance .ToString(wiref1) + wirek + " / " + BuildSystem.GetComponent<BuildSystem>().ElectricDrillCopperWirePrice.ToString() + " | " + CircuitBoardTranslate + " " + CircuitBoardBalance.ToString(boardf1) + boardk + " / " + BuildSystem.GetComponent<BuildSystem>().ElectricDrillCircuitBoardPrice.ToString();
        }


        //ELECTRIC TURRET
        else if (RandomEvents == 8)
        {
           
            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().ElectricTurretPrice.ToString() + " | " + IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark+ " / " + BuildSystem.GetComponent<BuildSystem>().ElectricTurretIronBarPrice.ToString() + " | " + GearTranslate + " " + GearBalance.ToString(gearf1) + geark + " / " + BuildSystem.GetComponent<BuildSystem>().ElectricTurretGearPrice.ToString() + " | " + CopperWireTranslate + " " + CopperWireBalance.ToString(wiref1) + wirek+ " / " + BuildSystem.GetComponent<BuildSystem>().ElectricTurretCopperWirePrice.ToString() + " | " + CircuitBoardTranslate + " " + CircuitBoardBalance.ToString(boardf1) + boardk + " / " + BuildSystem.GetComponent<BuildSystem>().ElectricTurretCircuitBoardPrice.ToString();

        }

        //BÝG HEALTH REGEN
        else if (RandomEvents == 9)
        {
            
            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().BigHealthRegenPrice.ToString() + " | " + "Bakýr Tel " + CopperWireBalance.ToString(wiref1) + wirek + " / " + BuildSystem.GetComponent<BuildSystem>().BigHealthRegenCopperWirePrice.ToString() + " | " + CircuitBoardTranslate + " " + CircuitBoardBalance.ToString(boardf1) + boardk + " / " + BuildSystem.GetComponent<BuildSystem>().BigHealthRegenCircuitBoardPrice.ToString();

        }
        //ADVANCED TURRET
        else if (RandomEvents == 10)
        {

            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().AdvancedTurretPrice.ToString() + " | " + IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark + " / " + BuildSystem.GetComponent<BuildSystem>().AdvancedTurretIronBarPrice.ToString() + " | " + GearTranslate + " " + GearBalance.ToString(gearf1) + geark + " / " + BuildSystem.GetComponent<BuildSystem>().AdvancedTurretGearPrice.ToString();

        }
        //LASER TURRET
        else if (RandomEvents == 11)
        {

            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().LaserTurretPrice.ToString() + " | " + IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark + " / " + BuildSystem.GetComponent<BuildSystem>().LaserTurretIronBarPrice.ToString() + " | " + GearTranslate + " " + GearBalance.ToString(gearf1) + geark + " / " + BuildSystem.GetComponent<BuildSystem>().LaserTurretGearPrice.ToString() + " | " + CircuitBoardTranslate + " " + CircuitBoardBalance.ToString(boardf1) + boardk + " / " + BuildSystem.GetComponent<BuildSystem>().LaserTurretCircuitBoardPrice.ToString() + " | " + SteelTranslate + " " + SteelBalance.ToString(steelf1) + steelk + " / " + BuildSystem.GetComponent<BuildSystem>().LaserTurretSteelPrice.ToString();

        }
        //Mortar TURRET
        else if (RandomEvents == 12)
        {

            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().MortarTurretPrice.ToString() + " | " + IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark + " / " + BuildSystem.GetComponent<BuildSystem>().MortarTurretIronBarPrice.ToString() + " | " + GearTranslate + " " + GearBalance.ToString(gearf1) + geark + " / " + BuildSystem.GetComponent<BuildSystem>().MortarTurretGearPrice.ToString() + " | "  + SteelTranslate + " " + SteelBalance.ToString(steelf1) + steelk + " / " + BuildSystem.GetComponent<BuildSystem>().MortarTurretSteelPrice.ToString();

        }
        //URANIUM TO ELECTRIC
        else if (RandomEvents == 13)
        {

            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().UraniumToelectricPrice.ToString()  +" | " + CopperWireTranslate + " " + CopperWireBalance.ToString(wiref1) + wirek + " / " + BuildSystem.GetComponent<BuildSystem>().UraniumToelectricCopperWirePrice.ToString()  +" | " + CircuitBoardTranslate + " " + CircuitBoardBalance.ToString(boardf1) + boardk + " / " + BuildSystem.GetComponent<BuildSystem>().UraniumToelectricCircuitBoardPrice.ToString() +" | " + SteelTranslate + " " + SteelBalance.ToString(steelf1) + steelk + " / " + BuildSystem.GetComponent<BuildSystem>().UraniumToelectricSteelPrice.ToString();

        }
        //ADVANCED URANIUM TURRET
        else if (RandomEvents == 14)
        {

            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().AdvancedUraniumTurretPrice.ToString() + " | " + IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark + " / " + BuildSystem.GetComponent<BuildSystem>().AdvancedUraniumTurretIronBarPrice.ToString() + " | " + SteelTranslate + " " + SteelBalance.ToString(steelf1) + steelk + " / " + BuildSystem.GetComponent<BuildSystem>().AdvancedUraniumTurretSteelPrice.ToString() + " | " + UraniumTranslate + " " + UraniumBalance.ToString(uraniumf1) + uraniumk + " / " + BuildSystem.GetComponent<BuildSystem>().AdvancedUraniumTurretUraniumPrice.ToString();

        }
        //MORTAR URANIUM TURRET
        else if (RandomEvents == 15)
        {

            ObjectPrice.text = IronTranslate + " " + IronBalance.ToString(f1) + k + " / " + BuildSystem.GetComponent<BuildSystem>().MortarUraniumTurretPrice.ToString() + " | " + IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark + " / " + BuildSystem.GetComponent<BuildSystem>().MortarUraniumTurretIronBarPrice.ToString() + " | " + SteelTranslate + " " + SteelBalance.ToString(steelf1) + steelk + " / " + BuildSystem.GetComponent<BuildSystem>().MortarUraniumTurretSteelPrice.ToString() + " | " + UraniumTranslate + " " + UraniumBalance.ToString(uraniumf1) + uraniumk + " / " + BuildSystem.GetComponent<BuildSystem>().AdvancedUraniumTurretUraniumPrice.ToString();

        }
        //MORTAR URANIUM TURRET
        else if (RandomEvents == 16)
        {

            ObjectPrice.text = IronBarTranslate + " " + IronBarBalance.ToString(ýronbarf1) + ýronbark+ " / " + BuildSystem.GetComponent<BuildSystem>().LaserUraniumTurretIronBarPrice.ToString() + " | " + CircuitBoardTranslate + " " + CircuitBoardBalance.ToString(boardf1) + boardk+ " / " + BuildSystem.GetComponent<BuildSystem>().LaserUraniumTurretCircuitBoardPrice.ToString() + " | " + SteelTranslate + " " + SteelBalance.ToString(steelf1) + steelk + " / " + BuildSystem.GetComponent<BuildSystem>().LaserUraniumTurretSteelPrice.ToString() + " | " + UraniumTranslate + " " + UraniumBalance.ToString(uraniumf1) + uraniumk + " / " + BuildSystem.GetComponent<BuildSystem>().LaserUraniumTurretUraniumPrice.ToString() + " | " + AdvancedCircuitBoardTranslate + " " + AdvancedCircuitBoardBalance.ToString(advancedboardf1) +advancedboardk+ " / " + BuildSystem.GetComponent<BuildSystem>().LaserUraniumTurretAdvancedCircuitBoardPrice.ToString();

        }
        //Steel Wall
        else if (RandomEvents == 17)
        {

            ObjectPrice.text = SteelTranslate + " " + SteelBalance.ToString(steelf1) + steelk + " / " + BuildSystem.GetComponent<BuildSystem>().SteelWallSteelPrice.ToString() ;

        }
        //Uranium Wall
        else if (RandomEvents == 18)
        {

            ObjectPrice.text = UraniumTranslate + " " + UraniumBalance.ToString(uraniumf1) + uraniumk + " / " + BuildSystem.GetComponent<BuildSystem>().UraniumWallUraniumPrice.ToString();

        }
        //Uranium DRÝLL
        else if (RandomEvents == 19)
        {

            ObjectPrice.text = SteelTranslate + " " + SteelBalance.ToString(steelf1) + steelk + " / " + BuildSystem.GetComponent<BuildSystem>().UraniumDrillSteelPrice.ToString() + " | " +  UraniumTranslate + " " + UraniumBalance.ToString(uraniumf1) + uraniumk + " / " + BuildSystem.GetComponent<BuildSystem>().UraniumDrillUraniumPrice.ToString() + " | " + AdvancedCircuitBoardTranslate + " " + AdvancedCircuitBoardBalance.ToString(advancedboardf1) + advancedboardk + " / " + BuildSystem.GetComponent<BuildSystem>().UraniumDrillAdvancedCircuitBoardPrice.ToString();

        }

    }
    public void WoodenDrill()
    {
        RandomEvents = 0;
        
        Show();
    }
    public void WoodenTurret()
    {
        RandomEvents = 1;
        
        Show();
    }
    public void HealthRegen()
    {
        RandomEvents = 2;

        Show();
    }
    public void CoaltoElectric()
    {
        RandomEvents = 3;

        Show();
    }
    public void BulletMachine()
    {
        RandomEvents = 4;

        Show();
    }
    public void IronWall()
    {
        RandomEvents = 5;

        Show();
    }
    public void IronDrill()
    {
        RandomEvents = 6;

        Show();
    }
    public void ElectricDrill()
    {
        RandomEvents = 7;

        Show();
    }
    public void ElectricTurret()
    {
        RandomEvents = 8;

        Show();
    }
    public void BigHealthRegen()
    {
        RandomEvents = 9;

        Show();
    }
    public void AdvancedTurret()
    {
        RandomEvents = 10;

        Show();
    }
    public void LaserTurret()
    {
        RandomEvents = 11;

        Show();
    }
    public void MortarTurret()
    {
        RandomEvents = 12;

        Show();
    }
    public void UraniumToElectric()
    {
        RandomEvents = 13;

        Show();
    }
    public void AdvancedUraniumTurret()
    {
        RandomEvents = 14;

        Show();
    }
    public void MortarUraniumTurret()
    {
        RandomEvents = 15;

        Show();
    }
    public void LaserUraniumTurret()
    {
        RandomEvents = 16;

        Show();
    }
    public void SteelWall()
    {
        RandomEvents = 17;

        Show();
    }
    public void UraniumWall()
    {
        RandomEvents = 18;

        Show();
    }
    public void UraniumDrill()
    {
        RandomEvents = 19;

        Show();
    }





}
