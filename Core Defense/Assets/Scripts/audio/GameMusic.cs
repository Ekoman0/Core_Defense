using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioClip music1;
    public AudioClip music2;
    public AudioSource audsrc;
    private int music=1;
    private float timer=5;

    private void Update()
    {
        if (audsrc.isPlaying == false)
        {
            timer -= Time.deltaTime;
            if (timer <0)
            {
                ChangeMusic();
                audsrc.Play();
                timer = 5;
            }
           
        }
    }
    void ChangeMusic()
    {
        if (music ==0)
        {
            audsrc.clip = music1;
            music = 1;
        }
        if (music == 1)
        {
            audsrc.clip = music2;
            music = 0;
        }
    }
}
