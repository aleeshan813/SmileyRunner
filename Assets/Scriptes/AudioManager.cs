using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sounds[] sfxsounds;
    public AudioSource sfxsource;

    public void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public void PlaySFX(string name)
    {
        Sounds s = Array.Find(sfxsounds, x => x.name == name);

        if (s == null)
        {
            return;
        }

        else
        {
            sfxsource.PlayOneShot(s.Clip);
        }
    }

    public void ToggleSFX() 
    {
        sfxsource.mute = !sfxsource.mute;    
    }
    public void sfxVolume(float volume) 
    {
        sfxsource.volume = volume;
    }
}

