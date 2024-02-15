using UnityEngine;

using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using SaveLoadSystem;

[System.Serializable]
public class Wave

{
    //aaaaaa
    public string waveName;

    [System.Serializable]
    public class aaa
    {
        public GameObject[] typeOfEnemies;
        public int noOfEnemies;
        public float spawnInterval;
        public Transform spawnPoints;
    }



    public Wave.aaa[] aaaa;






}

[RequireComponent(typeof(SaveableEntity))]
public class WaveSpawnner : MonoBehaviour,ISaveable

{
    public AudioSource SpawnEffect;

    string sceneName;
    private BuildSystem build;
 
    private float money;

    public ParticleSystem BornEffect;

    [Header("GUI")]
    public TextMeshProUGUI WaveNameUI;
    public TextMeshProUGUI WhenWaveUI;
    public TextMeshProUGUI LiveEnemisUI;
    public Button NextWaveButtonn;


    public Wave[] waves;
    
    private GameObject[] totalEnemies;


    public float NextWaveTimerFixed = 10;
    private string NextWaveTimerFixedString;
    private float NextWaveTimerVariable;

    private int WaveNameInt = 1;

    private Wave currentWave;

    private Wave.aaa currentEnemy;

    public int currentWaveNumber;
    private int currentEnemyNumber = 0;

    private float nextSpawnTime;

    private bool canSpawn = true;

    [System.Serializable]
    struct WaveData
    {
        public int currentWaveNumber;
    }
    private void Awake()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (PlayerPrefs.HasKey("totalScoreKey"))  //totalScoreKey anahtarýyla kaydedilmiþ bir veri var mý ?
        {


            NextWaveTimerFixedString = PlayerPrefs.GetString("totalScoreKey"); // totalScoreKey anahtarýyla kaydedilmiþ veriyi getir
            if (sceneName == "Tutorial")
            {
                NextWaveTimerFixed = 9999;
            }
            else
            {
                NextWaveTimerFixed = float.Parse(NextWaveTimerFixedString);
            }
           


        }
    }

    private void Start()
    {


        NextWaveTimerVariable = NextWaveTimerFixed;

    
    }
    private void Update()
    {
        bool loadscne = true;// DATA BUG
        if (loadscne == true)// DATA BUG
        {
            WaveNameInt = currentWaveNumber + 1;// DATA BUG
            WaveNameUI.text = WaveNameInt.ToString();// DATA BUG
            loadscne = false;// DATA BUG

        }// DATA BUG

        if (NextWaveTimerVariable < 0)
        {
            NextWaveTimerVariable = 0;
        }

        LiveEnemisUI.text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
        NextWaveTimerVariable -= Time.deltaTime;
        WhenWaveUI.text = NextWaveTimerVariable.ToString("0");

        

        if (currentWaveNumber < waves.Length)
        {
            currentWave = waves[currentWaveNumber];
        }


        if ((currentEnemyNumber < currentWave.aaaa.Length))
        {
            currentEnemy = currentWave.aaaa[currentEnemyNumber];
            SpawnWave();
        }
        






        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");


        if (currentEnemy.noOfEnemies == 0)

        {
            NextEnemy();


        }



        if (currentWaveNumber >= waves.Length && totalEnemies.Length == 0)
        {
            float oldmoney;
            money = currentWaveNumber;
            oldmoney = PlayerPrefs.GetFloat("Money");
            
            PlayerPrefs.SetFloat("Money", oldmoney);
            if (sceneName == "SampleScene"|| sceneName == "LVL1 LOAD")
            {
                PlayerPrefs.SetInt("Lvl1Complete", 1);
                oldmoney += money * 2;
            }
            else if (sceneName == "LVL2" || sceneName == "LVL2 LOAD")
            {
                PlayerPrefs.SetInt("Lvl2Complete", 1);
                oldmoney += money * 2;
            }
            else if (sceneName == "LVL3" || sceneName == "LVL3 LOAD")
            {
                PlayerPrefs.SetInt("Lvl3Complete", 1);
                oldmoney += money * 3;
            }
            else if (sceneName == "LVL4" || sceneName == "LVL4 LOAD")
            {
                PlayerPrefs.SetInt("Lvl4Complete", 1);
                oldmoney += money * 3;
            }

            SceneManager.LoadScene(4);
        }

        if (totalEnemies.Length <= 0)
        {
            if (NextWaveButtonn != null)
            {
                NextWaveButtonn.gameObject.SetActive(true);
            }
            
        }
        else
        {
            if (NextWaveButtonn != null)
            {
                NextWaveButtonn.gameObject.SetActive(false);
            }
            
        }
    }

    void SpawnNextWave()//yeni wave gelir

    {
        //BornEffect.Play();
        SpawnEffect.Play();
        currentWaveNumber++;
        WaveNameInt = currentWaveNumber + 1;
        WaveNameUI.text = WaveNameInt.ToString();

        canSpawn = true;

    }
    void NextEnemy()

    {

        if (currentEnemyNumber < currentWave.aaaa.Length)
        {
            currentEnemyNumber++;
            canSpawn = true;
        }
        else if (currentEnemyNumber >= currentWave.aaaa.Length)
        {


            if (NextWaveTimerVariable < 0)
            {
                currentEnemyNumber = 0;
                SpawnNextWave();
                NextWaveTimerVariable = NextWaveTimerFixed;
            }

        }



    }

    void SpawnWave()

    {

        if (canSpawn && nextSpawnTime < Time.time && NextWaveTimerVariable < 0 )
        {

            GameObject randomEnemy = currentEnemy.typeOfEnemies[Random.Range(0, currentEnemy.typeOfEnemies.Length)];

            Transform randomPoint = currentEnemy.spawnPoints;


            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);

            currentEnemy.noOfEnemies--;

            nextSpawnTime = Time.time + currentEnemy.spawnInterval;

            if (currentEnemy.noOfEnemies == 0)
            {

                canSpawn = false;
                SaveLoadSystem.SaveLoadSystem.SaveNew();



            }

        }
       

        




    }
    public void NextWaveButton()
    {

        NextWaveTimerVariable = 0;
    }


    public bool NeedsToBeSaved()
    {
        return true;
    }

    public bool NeedsReinstantiation()
    {
        return true;
    }

    public object SaveState()
    {
        return new WaveData()
        {
            currentWaveNumber = currentWaveNumber
        };
        
    }

    public void LoadState(object state)
    {
        WaveData data = (WaveData)state;

        this.currentWaveNumber = data.currentWaveNumber;
    }

    public void PostInstantiation(object state)
    {
        WaveData data = (WaveData)state;
    }

    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {
        throw new System.NotImplementedException();
    }
}