using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManagerBasicTurret : MonoBehaviour
{
    public Sprite BasicTurretSkin0;
    public Sprite BasicTurretSkin1;
    public Sprite BasicTurretSkin2;
    public Sprite BasicTurretSkin3;
    public Sprite BasicTurretSkin4;
    public Sprite BasicTurretSkin5;
    public Sprite BasicTurretSkin6;
    public Sprite BasicTurretSkin7;
    public Sprite BasicTurretSkin8;
    public Sprite BasicTurretSkin9;
    public Sprite BasicTurretSkin10;
    public Sprite BasicTurretSkin11;
    public Sprite BasicTurretSkin12;
    public Sprite BasicTurretSkin13;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("BasicTurretSkin"))
        {
            float skinfloat;
            skinfloat = PlayerPrefs.GetFloat("BasicTurretSkin");
            if (skinfloat ==0)
            {
             this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin0;
            }
            if (skinfloat == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin1;
            }
            if (skinfloat == 2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin2;
            }
            if (skinfloat == 3)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin3;
            }
            if (skinfloat == 4)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin4;
            }
            if (skinfloat == 5)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin5;
            }
            if (skinfloat == 6)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin6;
            }
            if (skinfloat == 7)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin7;
            }
            if (skinfloat == 8)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin8;
            }
            if (skinfloat == 9)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin9;
            }
            if (skinfloat == 10)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin10;
            }
            if (skinfloat == 11)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin11;
            }
            if (skinfloat == 12)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin12;
            }
            if (skinfloat == 13)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BasicTurretSkin13;
            }
        }   }

    // Update is called once per frame
   
}
