using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;



    private void Start()
    {
        if ( PlayerPrefs.HasKey("musicVolumen")) 
        {
            LoadVolumen();
        }
        else 
        {
            LoadVolumen();
        }



    }


    public void CambiarVolumen()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolumen", volume);
    }

    private void LoadVolumen() 
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolumen");
        CambiarVolumen();
    }
   
}
