using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainMoney : MonoBehaviour
{
    private GameObject InImagIron;
    private GameObject InImagCoal;
    private GameObject InImagCopper;
    private GameObject InImagUranium;

    public bool IsCoal=false;
    public bool IsIron = false;
    public bool IsCopper = false;
    public bool IsUranium = false;


    private bool CoalDig = false;
    private bool IronDig= false;
    private bool CopperDig= false;
    private bool UraniumDig= false;

    private bool IsWoodenDrill;
    private bool IsIronDrill;
    private bool IsElectricDrill;
    private bool IsUraniumDrill;

    private float timer = 1;
    private GameObject gmmngr;
    private GameObject drill;

    public AudioSource DrillWorkAs;
 

    // Start is called before the first frame update
    void Start()
    {
        gmmngr = GameObject.FindWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsWoodenDrill == true)//eðer bu Tahta Sondajsa
        {
            if (CoalDig == true || CopperDig == true || IronDig == true|| UraniumDig ==true)
            {
                drill.GetComponent<Transform>().Rotate(0, 0, 70 * Time.deltaTime);
                if (DrillWorkAs.isPlaying == false)
                {
                    DrillWorkAs.Play();
                }
            }
            if (CoalDig == true)//eðer bu obje kömür ise
            {
                InImagCoal.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {

                    gmmngr.GetComponent<BuildSystem>().CoalBalance += 1;//kömürümüze 1 kömür daha ekle
                    timer = 1;//timer ý 1 yap
                }
            }
            if (IronDig == true)//eðer bu obje demir ise
            {
                InImagIron.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {

                    gmmngr.GetComponent<BuildSystem>().IronBalance += 2;//demirimize 2 demir daha ekle
                    timer = 1;
                }
            }
            if (CopperDig == true)//eðer bu obje demir ise
            {
                InImagCopper.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {

                    gmmngr.GetComponent<BuildSystem>().CopperBalance += 1;//bakýrýmýza 1 bakýr daha ekle

                    timer = 1;
                }
            }
            if (IsCoal == true || IsIron == true || IsCopper == true)
            {
                timer -= Time.deltaTime;
            }
        }

        else if (IsIronDrill == true)//Eðer Demir Sondaj Ýse
        {
            if (CoalDig == true || CopperDig == true || IronDig == true || UraniumDig == true)
            {
                drill.GetComponent<Transform>().Rotate(0, 0, 100 * Time.deltaTime);
                if (DrillWorkAs.isPlaying == false)
                {
                    DrillWorkAs.Play();
                }
            }
            if (CoalDig == true)//eðer bu obje kömür ise
            {
                InImagCoal.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {

                    gmmngr.GetComponent<BuildSystem>().CoalBalance += 2;//kömürümüze 2 kömür daha ekle
                    timer = 1;//timer ý 1 yap
                }
            }
            if (IronDig == true)//eðer bu obje demir ise
            {
                InImagIron.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {

                    gmmngr.GetComponent<BuildSystem>().IronBalance += 4;//demirimize 4 demir daha ekle
                    timer = 1;
                }
            }
            if (CopperDig == true)//eðer bu obje demir ise
            {
                InImagCopper.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {

                    gmmngr.GetComponent<BuildSystem>().CopperBalance += 2;//bakýrýmýza 2 bakýr daha ekle

                    timer = 1;
                }
            }
            if (IsCoal == true || IsIron == true || IsCopper == true)
            {
                timer -= Time.deltaTime;
            }
        }

        else if (IsElectricDrill == true)//eðer Elektrikli sondaj Ýse
        {
            if ((CoalDig == true || CopperDig == true || IronDig == true || UraniumDig == true) && gmmngr.GetComponent<BuildSystem>().ElectricBalance > 5)
            {
                drill.GetComponent<Transform>().Rotate(0, 0, 130 * Time.deltaTime);
                if (DrillWorkAs.isPlaying == false)
                {
                    DrillWorkAs.Play();
                }
            }
            else if ((CoalDig == true || CopperDig == true || IronDig == true || UraniumDig == true) && gmmngr.GetComponent<BuildSystem>().ElectricBalance == 5 )
            {
                drill.GetComponent<Transform>().Rotate(0, 0, 60 * Time.deltaTime);
                if (DrillWorkAs.isPlaying == false)
                {
                    DrillWorkAs.Play();
                }
            }
            if (CoalDig == true)//eðer bu obje kömür ise
            {
                InImagCoal.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance >5)
                    {
                        gmmngr.GetComponent<BuildSystem>().CoalBalance += 3;//kömürümüze 4 kömür daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 5; // 5 elektrik tüket
                        timer = 1;//timer ý 1 yap
                    }
                    
                }
            }
            if (IronDig == true)//eðer bu obje demir ise
            {
                InImagIron.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 5)
                    {
                        gmmngr.GetComponent<BuildSystem>().IronBalance += 5;//demirimize 6 demir daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 5; // 5 elektrik tüket
                        timer = 1;
                    }
                   
                }
            }
            if (CopperDig == true)//eðer bu obje demir ise
            {
                InImagCopper.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 5)
                    {
                        gmmngr.GetComponent<BuildSystem>().CopperBalance += 3;//bakýrýmýza 3 bakýr daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 5; // 5 elektrik tüket
                        timer = 1;
                    }
                    
                }
            }
            if (UraniumDig == true)//eðer bu obje demir ise
            {
                InImagUranium.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 5)
                    {
                        gmmngr.GetComponent<BuildSystem>().UraniumBalance += 1;//uranyumumuza 3 bakýr daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 5; // 5 elektrik tüket
                        timer = 1;
                    }

                }
            }
            if (IsCoal == true || IsIron == true || IsCopper == true|| IsUranium == true)
            {
                timer -= Time.deltaTime;
            }
        }


        else if (IsUraniumDrill == true)//eðer Uranium sondaj Ýse
        {
            if ((CoalDig == true || CopperDig == true || IronDig == true || UraniumDig == true) && gmmngr.GetComponent<BuildSystem>().ElectricBalance > 5)
            {
                drill.GetComponent<Transform>().Rotate(0, 0, 175 * Time.deltaTime);
                if (DrillWorkAs.isPlaying == false)
                {
                    DrillWorkAs.Play();
                }
            }
            else if ((CoalDig == true || CopperDig == true || IronDig == true || UraniumDig == true) && gmmngr.GetComponent<BuildSystem>().ElectricBalance == 5)
            {
                drill.GetComponent<Transform>().Rotate(0, 0, 80 * Time.deltaTime);
                if (DrillWorkAs.isPlaying == false)
                {
                    DrillWorkAs.Play();
                }
            }
            if (CoalDig == true)//eðer bu obje kömür ise
            {
                InImagCoal.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 9)
                    {
                        gmmngr.GetComponent<BuildSystem>().CoalBalance += 5;//kömürümüze 4 kömür daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 10; // 5 elektrik tüket
                        timer = 1;//timer ý 1 yap
                    }

                }
            }
            if (IronDig == true)//eðer bu obje demir ise
            {
                InImagIron.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 9)
                    {
                        gmmngr.GetComponent<BuildSystem>().IronBalance += 7;//demirimize 6 demir daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 10; // 5 elektrik tüket
                        timer = 1;
                    }

                }
            }
            if (CopperDig == true)//eðer bu obje demir ise
            {
                InImagCopper.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 9)
                    {
                        gmmngr.GetComponent<BuildSystem>().CopperBalance += 5;//bakýrýmýza 3 bakýr daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 10; // 5 elektrik tüket
                        timer = 1;
                    }

                }
            }
            if (UraniumDig == true)//eðer bu obje demir ise
            {
                InImagUranium.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan küçük ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 9)
                    {
                        gmmngr.GetComponent<BuildSystem>().UraniumBalance += 2;//uranyumumuza 3 bakýr daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 10; // 5 elektrik tüket
                        timer = 1;
                    }

                }
            }
            if (IsCoal == true || IsIron == true || IsCopper == true || IsUranium == true)
            {
                timer -= Time.deltaTime;
            }
        }


    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WoodenDrill" )//woodendrill objesi üstümüzdeyse
        {
            IsWoodenDrill = true;

            if (IsCoal == true)//eðer bu obje kömür ise
            {
                CoalDig = true;//kömür kazým iþlemini true yap
            }
            if (IsIron == true)
            {
                IronDig =true;
            }
            if (IsCopper == true)
            {
                CopperDig = true;
            }
            drill = collision.gameObject.transform.Find("Drill").gameObject;

            InImagIron = collision.gameObject.gameObject.transform.Find("Iron").gameObject;
            InImagCoal = collision.gameObject.gameObject.transform.Find("Coal").gameObject;
            InImagCopper = collision.gameObject.gameObject.transform.Find("Copper").gameObject;

            InImagCoal.gameObject.SetActive(false);
            InImagCopper.gameObject.SetActive(false);
            InImagIron.gameObject.SetActive(false);
        }


        if (collision.gameObject.tag == "IronDrill")
        {
            IsIronDrill = true;

            if (IsCoal == true)//eðer bu obje kömür ise
            {
                CoalDig = true;//kömür kazým iþlemini true yap
            }
            if (IsIron == true)
            {
                IronDig = true;
            }
            if (IsCopper == true)
            {
                CopperDig = true;
            }
            drill = collision.gameObject.transform.Find("Drill").gameObject;

            InImagIron = collision.gameObject.gameObject.transform.Find("Iron").gameObject;
            InImagCoal = collision.gameObject.gameObject.transform.Find("Coal").gameObject;
            InImagCopper = collision.gameObject.gameObject.transform.Find("Copper").gameObject;

            InImagCoal.gameObject.SetActive(false);
            InImagCopper.gameObject.SetActive(false);
            InImagIron.gameObject.SetActive(false);
        }


        if (collision.gameObject.tag == "ElectricDrill")
        {
            IsElectricDrill = true;

            if (IsCoal == true)//eðer bu obje kömür ise
            {
                CoalDig = true;//kömür kazým iþlemini true yap
            }
            if (IsIron == true)
            {
                IronDig = true;
            }
            if (IsCopper == true)
            {
                CopperDig = true;
            }
            if (IsUranium== true)
            {
                UraniumDig = true;
            }

            drill = collision.gameObject.transform.Find("Drill").gameObject;

            InImagIron = collision.gameObject.gameObject.transform.Find("Iron").gameObject;
            InImagCoal = collision.gameObject.gameObject.transform.Find("Coal").gameObject;
            InImagCopper = collision.gameObject.gameObject.transform.Find("Copper").gameObject;
            InImagUranium = collision.gameObject.gameObject.transform.Find("Uranium").gameObject;

            InImagCoal.gameObject.SetActive(false);
            InImagCopper.gameObject.SetActive(false);
            InImagIron.gameObject.SetActive(false);
            InImagUranium.gameObject.SetActive(false);
        }


        if (collision.gameObject.tag == "UraniumDrill")
        {
            IsUraniumDrill = true;

            if (IsCoal == true)//eðer bu obje kömür ise
            {
                CoalDig = true;//kömür kazým iþlemini true yap
            }
            if (IsIron == true)
            {
                IronDig = true;
            }
            if (IsCopper == true)
            {
                CopperDig = true;
            }
            if (IsUranium == true)
            {
                UraniumDig = true;
            }

            drill = collision.gameObject.transform.Find("Drill").gameObject;

            InImagIron = collision.gameObject.gameObject.transform.Find("Iron").gameObject;
            InImagCoal = collision.gameObject.gameObject.transform.Find("Coal").gameObject;
            InImagCopper = collision.gameObject.gameObject.transform.Find("Copper").gameObject;
            InImagUranium = collision.gameObject.gameObject.transform.Find("Uranium").gameObject;

            InImagCoal.gameObject.SetActive(false);
            InImagCopper.gameObject.SetActive(false);
            InImagIron.gameObject.SetActive(false);
            InImagUranium.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WoodenDrill" || collision.gameObject.tag == "IronDrill" || collision.gameObject.tag == "CopperDrill" || collision.gameObject.tag == "ElectricDrill" || collision.gameObject.tag == "UraniumDrill")
        {
            IsWoodenDrill = false;
            IsIronDrill = false;

            if (IsCoal == true)
            {
                CoalDig = false;
            }
            if (IsIron == true)
            {
                IronDig = false;
            }
            if (IsCopper == true)
            {
                CopperDig = false;
            }
            if (IsUranium == true)
            {
                UraniumDig = false;
            }
        }
    }
}
