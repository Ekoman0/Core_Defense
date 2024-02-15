using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
      

        
        

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MenuMusic");
        if (musicObj.Length>1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        
        if (sceneName == "SampleScene" || sceneName =="LVL1 LOAD" || sceneName == "LVL2" || sceneName == "LVL3" || sceneName == "LVL4")
        {
            Destroy(this.gameObject);
        }
    }
}
