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
        if (PlayerPrefs.HasKey("IronFrequency"))  //totalScoreKey anahtar�yla kaydedilmi� bir veri var m� ?
        {
            
            IronFrequency = PlayerPrefs.GetFloat("IronFrequency"); // totalScoreKey anahtar�yla kaydedilmi� veriyi getir           
        }
        if (PlayerPrefs.HasKey("CoalFrequency"))  //totalScoreKey anahtar�yla kaydedilmi� bir veri var m� ?
        {

            CoalFrequency = PlayerPrefs.GetFloat("CoalFrequency"); // totalScoreKey anahtar�yla kaydedilmi� veriyi getir           
        }
        if (PlayerPrefs.HasKey("CopperFrequency"))  //totalScoreKey anahtar�yla kaydedilmi� bir veri var m� ?
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

 
        else if (IronFrequency > 0.25 && IronFrequency < 0.75) //E�er Oyuncu Demir S�kl���nda Normali Se�tiyse % tane ore olu�tur
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
        //Demir S�kl�k Kontrol

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
        else if (CoalFrequency > 0.25 && CoalFrequency < 0.75) //E�er Oyuncu K�m�r S�kl���nda Normali Se�tiyse 3 tane ore olu�tur
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
        // k�m�r s�kl�k kontrol

        if (CopperFrequency <= 0.25)
        {
            for (int i = 1; i > 0; i--)
            {
                int SpawnPointRandom = Random.Range(0, SpawnPoints.Count);
                Instantiate(CopperOre, SpawnPoints[SpawnPointRandom].transform.position, Quaternion.identity);
                
                SpawnPoints.RemoveAt(SpawnPointRandom);
            }
        }
        else if (CopperFrequency > 0.25 && CopperFrequency < 0.75) //E�er Oyuncu K�m�r S�kl���nda Normali Se�tiyse 3 tane ore olu�tur
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
        else if (UraniumFrequency > 0.25 && UraniumFrequency < 0.75) //E�er Oyuncu K�m�r S�kl���nda Normali Se�tiyse 3 tane ore olu�tur
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
