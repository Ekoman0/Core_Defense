using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudSys : MonoBehaviour
{
    public AudioSource MenuMusic;
    public AudioSource GameMusic;
    public Slider slider;

    public AudioSource ShootEffect;
    public AudioSource ElectricTurretShootEffect;
    public AudioSource DrillWorkEffect;
    public AudioSource FactoryWorkEffect;
    public AudioSource PlayerShootEffect;
    public AudioSource BuildEffect;
    public AudioSource SpawnEffect;
    public Slider sliderefct;

    private void Start()
    {
        LoadAudio();
        LoadAudioEfct();


    }
    public void SettAudio(float value)

    {
        MenuMusic.volume = slider.value;
        GameMusic.volume = slider.value;
        //audsrc.volume = value;
        SaveAudio();
        LoadAudio();
    }
    public void SettAudioEfct(float value)

    {
        ShootEffect.volume = sliderefct.value;
        ElectricTurretShootEffect.volume = sliderefct.value;
        DrillWorkEffect.volume = sliderefct.value;
        FactoryWorkEffect.volume = sliderefct.value;
        PlayerShootEffect.volume = sliderefct.value;
        BuildEffect.volume = sliderefct.value;
        SpawnEffect.volume = sliderefct.value;

        SaveAudioEfct();
        LoadAudioEfct();
    }
    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("MusicAudio", slider.value);
    }
    private void SaveAudioEfct()
    {
        PlayerPrefs.SetFloat("EffectAudio", sliderefct.value);
        
    }

    private void LoadAudio()
    {
        if (PlayerPrefs.HasKey("MusicAudio"))
        {
            slider.value = PlayerPrefs.GetFloat("MusicAudio");
            MenuMusic.volume = slider.value;
            GameMusic.volume = slider.value;

        }
        else
        {
            PlayerPrefs.SetFloat("MusicAudio", 0.3f);
            slider.value = PlayerPrefs.GetFloat("MusicAudio");
            MenuMusic.volume = slider.value;
            GameMusic.volume = slider.value;

        }

    }
    private void LoadAudioEfct()
    {
        if (PlayerPrefs.HasKey("EffectAudio"))
        {
            sliderefct.value = PlayerPrefs.GetFloat("EffectAudio");
            ShootEffect.volume = sliderefct.value;
            ElectricTurretShootEffect.volume = sliderefct.value;
            DrillWorkEffect.volume = sliderefct.value;
            FactoryWorkEffect.volume = sliderefct.value;
            PlayerShootEffect.volume = sliderefct.value;
            BuildEffect.volume = sliderefct.value;
            SpawnEffect.volume = sliderefct.value;



        }
        else
        {
            PlayerPrefs.SetFloat("EffectAudio", 0.5f);
            sliderefct.value = PlayerPrefs.GetFloat("EffectAudio");
            ShootEffect.volume = sliderefct.value;
            ElectricTurretShootEffect.volume = sliderefct.value;
            DrillWorkEffect.volume = sliderefct.value;
            FactoryWorkEffect.volume = sliderefct.value;
            PlayerShootEffect.volume = sliderefct.value;
            BuildEffect.volume = sliderefct.value;
            SpawnEffect.volume = sliderefct.value;



        }

    }
}
