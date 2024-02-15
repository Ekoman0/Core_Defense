using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private BuildSystem build;
    private  WaveSpawnner spwnr;
    private float money;
    private float oldmoney;

    // Start is called before the first frame update
    void Start()
    {
        build = this.gameObject.GetComponent<BuildSystem>();
        spwnr = GameObject.Find("WaveSpawnner").GetComponent<WaveSpawnner>();

        Application.targetFrameRate = 50;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (GameObject.Find("CORE") == null)
        {
            money = spwnr.currentWaveNumber;
            oldmoney = PlayerPrefs.GetFloat("Money");
            if (money >0 && money < 5)
            {
                oldmoney += money;
            }
            else if(money >=5 && money < 10)
            {
                oldmoney += money + 5;
            }
            else if (money >= 10 && money < 15)
            {
                oldmoney += money + 10;
            }
            else if (money >= 5 && money < 50)
            {
                oldmoney += money + 15;
            }

            
            PlayerPrefs.SetFloat("Money", oldmoney);
            SceneManager.LoadScene(3);
        }
    }
}
