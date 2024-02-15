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
        if (IsWoodenDrill == true)//e�er bu Tahta Sondajsa
        {
            if (CoalDig == true || CopperDig == true || IronDig == true|| UraniumDig ==true)
            {
                drill.GetComponent<Transform>().Rotate(0, 0, 70 * Time.deltaTime);
                if (DrillWorkAs.isPlaying == false)
                {
                    DrillWorkAs.Play();
                }
            }
            if (CoalDig == true)//e�er bu obje k�m�r ise
            {
                InImagCoal.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {

                    gmmngr.GetComponent<BuildSystem>().CoalBalance += 1;//k�m�r�m�ze 1 k�m�r daha ekle
                    timer = 1;//timer � 1 yap
                }
            }
            if (IronDig == true)//e�er bu obje demir ise
            {
                InImagIron.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {

                    gmmngr.GetComponent<BuildSystem>().IronBalance += 2;//demirimize 2 demir daha ekle
                    timer = 1;
                }
            }
            if (CopperDig == true)//e�er bu obje demir ise
            {
                InImagCopper.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {

                    gmmngr.GetComponent<BuildSystem>().CopperBalance += 1;//bak�r�m�za 1 bak�r daha ekle

                    timer = 1;
                }
            }
            if (IsCoal == true || IsIron == true || IsCopper == true)
            {
                timer -= Time.deltaTime;
            }
        }

        else if (IsIronDrill == true)//E�er Demir Sondaj �se
        {
            if (CoalDig == true || CopperDig == true || IronDig == true || UraniumDig == true)
            {
                drill.GetComponent<Transform>().Rotate(0, 0, 100 * Time.deltaTime);
                if (DrillWorkAs.isPlaying == false)
                {
                    DrillWorkAs.Play();
                }
            }
            if (CoalDig == true)//e�er bu obje k�m�r ise
            {
                InImagCoal.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {

                    gmmngr.GetComponent<BuildSystem>().CoalBalance += 2;//k�m�r�m�ze 2 k�m�r daha ekle
                    timer = 1;//timer � 1 yap
                }
            }
            if (IronDig == true)//e�er bu obje demir ise
            {
                InImagIron.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {

                    gmmngr.GetComponent<BuildSystem>().IronBalance += 4;//demirimize 4 demir daha ekle
                    timer = 1;
                }
            }
            if (CopperDig == true)//e�er bu obje demir ise
            {
                InImagCopper.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {

                    gmmngr.GetComponent<BuildSystem>().CopperBalance += 2;//bak�r�m�za 2 bak�r daha ekle

                    timer = 1;
                }
            }
            if (IsCoal == true || IsIron == true || IsCopper == true)
            {
                timer -= Time.deltaTime;
            }
        }

        else if (IsElectricDrill == true)//e�er Elektrikli sondaj �se
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
            if (CoalDig == true)//e�er bu obje k�m�r ise
            {
                InImagCoal.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance >5)
                    {
                        gmmngr.GetComponent<BuildSystem>().CoalBalance += 3;//k�m�r�m�ze 4 k�m�r daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 5; // 5 elektrik t�ket
                        timer = 1;//timer � 1 yap
                    }
                    
                }
            }
            if (IronDig == true)//e�er bu obje demir ise
            {
                InImagIron.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 5)
                    {
                        gmmngr.GetComponent<BuildSystem>().IronBalance += 5;//demirimize 6 demir daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 5; // 5 elektrik t�ket
                        timer = 1;
                    }
                   
                }
            }
            if (CopperDig == true)//e�er bu obje demir ise
            {
                InImagCopper.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 5)
                    {
                        gmmngr.GetComponent<BuildSystem>().CopperBalance += 3;//bak�r�m�za 3 bak�r daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 5; // 5 elektrik t�ket
                        timer = 1;
                    }
                    
                }
            }
            if (UraniumDig == true)//e�er bu obje demir ise
            {
                InImagUranium.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 5)
                    {
                        gmmngr.GetComponent<BuildSystem>().UraniumBalance += 1;//uranyumumuza 3 bak�r daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 5; // 5 elektrik t�ket
                        timer = 1;
                    }

                }
            }
            if (IsCoal == true || IsIron == true || IsCopper == true|| IsUranium == true)
            {
                timer -= Time.deltaTime;
            }
        }


        else if (IsUraniumDrill == true)//e�er Uranium sondaj �se
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
            if (CoalDig == true)//e�er bu obje k�m�r ise
            {
                InImagCoal.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 9)
                    {
                        gmmngr.GetComponent<BuildSystem>().CoalBalance += 5;//k�m�r�m�ze 4 k�m�r daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 10; // 5 elektrik t�ket
                        timer = 1;//timer � 1 yap
                    }

                }
            }
            if (IronDig == true)//e�er bu obje demir ise
            {
                InImagIron.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 9)
                    {
                        gmmngr.GetComponent<BuildSystem>().IronBalance += 7;//demirimize 6 demir daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 10; // 5 elektrik t�ket
                        timer = 1;
                    }

                }
            }
            if (CopperDig == true)//e�er bu obje demir ise
            {
                InImagCopper.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 9)
                    {
                        gmmngr.GetComponent<BuildSystem>().CopperBalance += 5;//bak�r�m�za 3 bak�r daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 10; // 5 elektrik t�ket
                        timer = 1;
                    }

                }
            }
            if (UraniumDig == true)//e�er bu obje demir ise
            {
                InImagUranium.gameObject.SetActive(true);
                if (timer < 0)//timer 0 dan k���k ise
                {
                    if (gmmngr.GetComponent<BuildSystem>().ElectricBalance > 9)
                    {
                        gmmngr.GetComponent<BuildSystem>().UraniumBalance += 2;//uranyumumuza 3 bak�r daha ekle
                        gmmngr.GetComponent<BuildSystem>().ElectricBalance -= 10; // 5 elektrik t�ket
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
        if (collision.gameObject.tag == "WoodenDrill" )//woodendrill objesi �st�m�zdeyse
        {
            IsWoodenDrill = true;

            if (IsCoal == true)//e�er bu obje k�m�r ise
            {
                CoalDig = true;//k�m�r kaz�m i�lemini true yap
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

            if (IsCoal == true)//e�er bu obje k�m�r ise
            {
                CoalDig = true;//k�m�r kaz�m i�lemini true yap
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

            if (IsCoal == true)//e�er bu obje k�m�r ise
            {
                CoalDig = true;//k�m�r kaz�m i�lemini true yap
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

            if (IsCoal == true)//e�er bu obje k�m�r ise
            {
                CoalDig = true;//k�m�r kaz�m i�lemini true yap
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
