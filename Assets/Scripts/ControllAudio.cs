using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllAudio : MonoBehaviour
{
    public static ControllAudio Instance;
    private AudioSource audioSource;

    private void Awake()
    
    {
        if (Instance==null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void EjecutarSound(AudioClip sound)
    {
        audioSource?.PlayOneShot(sound);
    }

    public void PauseMusic(){
        audioSource?.Pause();
    }
}
