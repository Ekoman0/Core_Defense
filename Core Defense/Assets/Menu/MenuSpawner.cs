using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    public List<GameObject> spawnposition = new List<GameObject>();
    public List<GameObject> Spawnobject = new List<GameObject>();
    float timer = 1;
    void Start()
    {
        PlayerPrefs.SetInt("CanHakki", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer<0)
        {
            spawn();
            timer = Random.Range(0, 3);
        }
        timer -= Time.deltaTime;
        
    }
    void spawn()
    {

        int a;
        a = Random.Range(0, spawnposition.Count);
        int b;
        b = Random.Range(0, Spawnobject.Count);


        Instantiate(Spawnobject[b], spawnposition[a].transform.position, Quaternion.identity);
    }
}
