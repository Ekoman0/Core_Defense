using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManagerAdvancedTurret1 : MonoBehaviour
{
    public Sprite BasicTurretSkin0;
    public Sprite BasicTurretSkin1;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("AdvancedTurretSkin"))
        {
            float skinfloat;
            skinfloat = PlayerPrefs.GetFloat("AdvancedTurretSkin");
            if (skinfloat == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin0;
            }
            if (skinfloat == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin1;
            }
           
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
