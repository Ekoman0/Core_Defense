using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSkinManager : MonoBehaviour
{
    public Sprite LazerTurretSkin0;
    public Sprite LazerTurretSkin1;
    public Sprite LazerTurretSkin2;
    public Sprite LazerTurretSkin3;
    public Sprite LazerTurretSkin4;
    public Sprite LazerTurretSkin5;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("LazerTurretSkin"))
        {
            float skinfloat;
            skinfloat = PlayerPrefs.GetFloat("LazerTurretSkin");
            if (skinfloat == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LazerTurretSkin0;
            }
            if (skinfloat == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LazerTurretSkin1;
            }
            if (skinfloat == 2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LazerTurretSkin2;
            }
            if (skinfloat == 3)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LazerTurretSkin3;
            }
            if (skinfloat == 4)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LazerTurretSkin4;
            }
            if (skinfloat == 5)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LazerTurretSkin5;
            }
        }

    }
  
}
