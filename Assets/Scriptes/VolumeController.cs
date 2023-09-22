using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] Slider _sfxslider;
    
    public void Togglesfx()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void Diable()
    {
        gameObject.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void ToggleSFXVolume()
    {
        AudioManager.instance.sfxVolume(_sfxslider.value);
    }
}
