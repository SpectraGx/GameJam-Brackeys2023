using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    public FloatVariable PlayerHP;

    private AudioSource audioSource;
    [SerializeField] private AudioClip audioCris;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            PlayerHP.floatValue--;
            ControllAudio.Instance.EjecutarSound(audioCris);
            ScreenShakeV2.Instance.ShakeCamera(3f, 0.1f);
        }
    }
    

 
}
