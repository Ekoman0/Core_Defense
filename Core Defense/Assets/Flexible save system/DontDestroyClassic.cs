using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyClassic : MonoBehaviour
{
    private void Awake()
    {

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("SaveManager");
        if (musicObj.Length>1)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
