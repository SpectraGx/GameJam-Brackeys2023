using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMusic : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] GameController gm;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave") && !gm.isBossActive)
        {
            ControllAudio.Instance.EjecutarSound(music);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        ControllAudio.Instance.PauseMusic();
    }

    private void Update() {
        if (gm.isBossActive==true){
            ControllAudio.Instance.PauseMusic();
        }
    }
}
