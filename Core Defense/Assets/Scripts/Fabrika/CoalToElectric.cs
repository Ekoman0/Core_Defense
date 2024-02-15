using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalToElectric : MonoBehaviour
{
    private float Timer=1f;
    private GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");
    }


    void Update()
    {
        if (gameObject.GetComponent<Dragger>().Isbuilded == true)
        {
            if (Timer < 0)
            {
                if (GameManager.GetComponent<BuildSystem>().CoalBalance > 0)//eðer kömürümüz varsa
                {
                    GameManager.GetComponent<BuildSystem>().CoalBalance -= 1; // 1 kömür tüket
                    GameManager.GetComponent<BuildSystem>().ElectricBalance += 5;//5 elektrik üret
                    Timer = 0.5f;
                }

            }
            if (Timer > -2)
            {
                Timer -= Time.deltaTime;
            }
        }
        
        
    }
}
