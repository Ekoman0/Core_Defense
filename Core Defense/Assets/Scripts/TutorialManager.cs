using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    public GameObject[] popups;
    public GameObject GameManager;
    public GameObject WaveManager;
    private int popupindex =0;
    private GameObject turret;

    public Button TurretPageButton;


    [Header("Popups4")]
    public Button DrillPageButton;
    [Header("Popups5")]
    public Button BasicDrillButton;
    [Header("Popups7")]
    public Button BalanceButton;
    [Header("Popups8")]
    public Button MachinePageButton;
    [Header("Popups9")]
    public Button FactoryButton;

    private void Start()
    {
        WaveManager.GetComponent<WaveSpawnner>().NextWaveTimerFixed = 9999;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        RaycastHit2D hit = Physics2D.Linecast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward));
        for (int i = 0; i < popups.Length; i++)
        {
            if (i == popupindex)
            {
                popups[i].SetActive(true);
            }
            else
            {
                popups[i].SetActive(false);
            }
        }

        if (popupindex == 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                popupindex++;
            }
        }
        else if (popupindex == 1)
        {
            if (Input.GetMouseButtonUp(0))
            {
                popupindex++;
            }
        }
        else if (popupindex == 2)
        {
            if (Input.GetMouseButtonUp(0))
            {
                popupindex++;
            }
        }
        else if (popupindex == 3)
        {
            DrillPageButton.onClick.AddListener(popupindex3);
        }
        else if (popupindex == 4)
        {
            BasicDrillButton.onClick.AddListener(popupindex4);
        }
        else if (popupindex == 5)
        {
            if (hit.collider.tag == "Iron")
            {
                popupindex++;
            }
        }
        else if (popupindex == 6)
        {
            BalanceButton.onClick.AddListener(popupindex6);
        }
        else if (popupindex == 7)
        {
            MachinePageButton.gameObject.SetActive(true);
            MachinePageButton.onClick.AddListener(popupindex7);
        }
        else if (popupindex == 8)
        {
            FactoryButton.onClick.AddListener(popupindex8);
        }
        else if (popupindex == 9)
        {
            if (GameManager.gameObject.GetComponent<BuildSystem>().IronBarBalance>2000)
            {
                popupindex++;
            }
        }
        else if (popupindex == 10)
        {
            if (GameManager.gameObject.GetComponent<BuildSystem>().GearBalance > 2000)
            {
                popupindex++;
            }
        }
        else if (popupindex == 11)
        {
            TurretPageButton.gameObject.SetActive(true);
            turret = GameObject.FindGameObjectWithTag("Turret1");
            if (turret != null)
            {
                if (turret.GetComponent<Dragger>().Isbuilded == true)
                {
                    popupindex++;
                }
            }
            
        }
        else if (popupindex == 12)
        {
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene(0);
            }

        }
    }

    public void popupindex3()
    {
        if (popupindex == 3)
        {
            popupindex++;
        }
        
    }
    public void popupindex4()
    {
        if (popupindex == 4)
        {
            popupindex++;
        }

    }
    public void popupindex6()
    {
        if (popupindex == 6)
        {
            popupindex++;
        }

    }
    public void popupindex7()
    {
        if (popupindex == 7)
        {
            popupindex++;
        }

    }
    public void popupindex8()
    {
        if (popupindex == 8)
        {
            popupindex++;
        }

    }
    
    
}


