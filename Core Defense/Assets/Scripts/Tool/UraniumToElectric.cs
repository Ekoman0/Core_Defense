using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UraniumToElectric : MonoBehaviour
{
    private float Timer = 1f;
    private GameObject GameManager;
    public GameObject Imgnotwork;
    bool isworking=false;
    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");
        
    }


    void Update()
    {
        if (isworking == false)
        {
            Imgnotwork.gameObject.SetActive(true);
        }
        if (gameObject.GetComponent<Dragger>().Isbuilded == true)
        {
            if (Timer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().UraniumBalance > 0)//e�er uranium varsa
                {
                    if (isworking == false)
                    {
                        isworking = true;
                    }     
                    Imgnotwork.gameObject.SetActive(false);
                    GameManager.GetComponent<BuildSystem>().UraniumBalance -= 1; // 1 k�m�r t�ket
                    GameManager.GetComponent<BuildSystem>().ElectricBalance += 15;//12 elektrik �ret
                    Timer = 0.5f;
                }
                else
                {
                    if (isworking == true)
                    {
                        isworking = false;
                    }
                    
                }

            }
            if (Timer > -2)
            {
                Timer -= Time.deltaTime;
            }
        }


    }
}
