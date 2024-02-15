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
                if (GameManager.GetComponent<BuildSystem>().CoalBalance > 0)//e�er k�m�r�m�z varsa
                {
                    GameManager.GetComponent<BuildSystem>().CoalBalance -= 1; // 1 k�m�r t�ket
                    GameManager.GetComponent<BuildSystem>().ElectricBalance += 5;//5 elektrik �ret
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
