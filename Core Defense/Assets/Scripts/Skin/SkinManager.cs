using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [Header("Player")]
    public bool IsPlayer;
    public Sprite PlayerSkin0;
    public Sprite PlayerSkin1;
    public Sprite PlayerSkin2;
    public Sprite PlayerSkin3;
    public Sprite PlayerSkin4;
    public Sprite PlayerSkin5;
    public Sprite PlayerSkin6;
    public Sprite PlayerSkin7;
    public Sprite PlayerSkin8;
    public Sprite PlayerSkin9;
    public Sprite PlayerSkin10;
    public Sprite PlayerSkin11;
    public Sprite PlayerSkin12;
    public Sprite PlayerSkin13;
    public Sprite PlayerSkin14;
    public Sprite PlayerSkin15;
    public Sprite PlayerSkin16;
    public Sprite PlayerSkin17;
    public Sprite PlayerSkin18;
    public Sprite PlayerSkin19;
    public Sprite PlayerSkin20;
    public Sprite PlayerSkin21;
    public Sprite PlayerSkin22;
    public Sprite PlayerSkin23;
    public Sprite PlayerSkin24;
    public Sprite PlayerSkin25;
    public Sprite PlayerSkin26;
    public Sprite PlayerSkin27;
    public Sprite PlayerSkin28;
    public Sprite PlayerSkin29;
    void Start()
    {
        if (IsPlayer)
        {
            if (PlayerPrefs.HasKey("PlayerSkin"))
            {
                float skinfloat;
                skinfloat = PlayerPrefs.GetFloat("PlayerSkin");

                if (skinfloat ==0)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin0;
                }
                if (skinfloat == 1)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin1;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 2)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin2;
                    PlayerPrefs.SetInt("PlayerDamage", 13);
                }
                if (skinfloat == 3)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin3;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 4)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin4;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 5)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin5;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 6)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin6;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 7)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin7;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 8)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin8;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 9)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin9;
                }
                if (skinfloat == 10)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin10;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 11)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin11;
                }
                if (skinfloat == 12)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin12;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 13)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin13;
                    PlayerPrefs.SetInt("PlayerDamage", 15);
                }
                if (skinfloat == 14)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin14;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 15)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin15;
                }
                if (skinfloat == 16)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin16;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 17)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin17;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 18)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin18;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 19)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin19;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 20)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin20;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 21)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin21;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                    PlayerPrefs.SetInt("PlayerDamage", 15);
                }
                if (skinfloat == 22)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin22;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                    PlayerPrefs.SetInt("PlayerDamage",20);
                }
                if (skinfloat == 23)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin23;
                }
                if (skinfloat == 24)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin24;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 25)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin25;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 26)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin26;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 27)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin27;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 28)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin28;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }
                if (skinfloat == 29)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerSkin29;
                    this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                }



            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
