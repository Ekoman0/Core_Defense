using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOreSpawn : MonoBehaviour
    
{
  



    public GameObject IronOre;
    public GameObject CoalOre;
    public GameObject CopperOre;
    public GameObject UraniumOre;



    public List<GameObject> SpawnPoints;
    public List<GameObject> NewObject;
    //public GameObject[] SpawnPoints;
    private float IronFrequency;
    private float CoalFrequency;
    private float CopperFrequency;
    private float UraniumFrequency;



    //private int SpawnPointRandom;

    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.HasKey("IronFrequency"))  //totalScoreKey anahtarýyla kaydedilmiþ bir veri var mý ?
        {
            
            IronFrequency = PlayerPrefs.GetFloat("IronFrequency"); // totalScoreKey anahtarýyla kaydedilmiþ veriyi getir           
        }
        if (PlayerPrefs.HasKey("CoalFrequency"))  //totalScoreKey anahtarýyla kaydedilmiþ bir veri var mý ?
        {

            CoalFrequency = PlayerPrefs.GetFloat("CoalFrequency"); // totalScoreKey anahtarýyla kaydedilmiþ veriyi getir           
        }
        if (PlayerPrefs.HasKey("CopperFrequency"))  //totalScoreKey anahtarýyla kaydedilmiþ bir veri var mý ?
        {

            CopperFrequency = PlayerPrefs.GetFloat("CopperFrequency"); 
        }
        if (PlayerPrefs.HasKey("UraniumFrequency"))  
        {

            UraniumFrequency = PlayerPrefs.GetFloat("UraniumFrequency"); 
        }


        if (IronFrequency <= 0.25)
        {
            for (int i = 3; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(IronOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                //Destroy(SpawnPoints[SpawnPointRandom]);
                SpawnPoints.RemoveAt(SpawnPointRandom);

            }
        }

 
        else if (IronFrequency > 0.25 && IronFrequency < 0.75) //Eðer Oyuncu Demir Sýklýðýnda Normali Seçtiyse % tane ore oluþtur
        {
            for (int i = 5; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(IronOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                //Destroy(SpawnPoints[SpawnPointRandom]);
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }

        else if (IronFrequency >= 0.75)
        {
            for (int i = 7; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(IronOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                //Destroy(SpawnPoints[SpawnPointRandom]);
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        //Demir Sýklýk Kontrol

        if (CoalFrequency <= 0.25)
        {
            for (int i = 1; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(CoalOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                //Destroy(SpawnPoints[SpawnPointRandom]);
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        else if (CoalFrequency > 0.25 && CoalFrequency < 0.75) //Eðer Oyuncu Kömür Sýklýðýnda Normali Seçtiyse 3 tane ore oluþtur
        {
            for (int i = 3; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(CoalOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                //Destroy(SpawnPoints[SpawnPointRandom]);
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        else if (CoalFrequency >= 0.75)
        {
            for (int i = 5; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(CoalOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);                
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        // kömür sýklýk kontrol

        if (CopperFrequency <= 0.25)
        {
            for (int i = 1; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(CopperOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        else if (CopperFrequency > 0.25 && CopperFrequency < 0.75) //Eðer Oyuncu Kömür Sýklýðýnda Normali Seçtiyse 3 tane ore oluþtur
        {
            for (int i = 2; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(CopperOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);                
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        else if (CopperFrequency >= 0.75)
        {
            for (int i = 3; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(CopperOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        //BAKIR SIKLIK

        if (UraniumFrequency <= 0.25)
        {
            for (int i = 1; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(UraniumOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);

                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        else if (UraniumFrequency > 0.25 && UraniumFrequency < 0.75) //Eðer Oyuncu Kömür Sýklýðýnda Normali Seçtiyse 3 tane ore oluþtur
        {
            for (int i = 2; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(UraniumOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        else if (UraniumFrequency >= 0.75)
        {
            for (int i = 3; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(UraniumOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }






    }

}
