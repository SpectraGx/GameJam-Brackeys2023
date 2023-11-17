using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    [SerializeField] GameController GM;

    [SerializeField] float scShakeIntensity = 5f;
    [SerializeField] float scShakeDuration = 0.2f;

    [SerializeField] private AudioClip audioDamage;

    private void Awake()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave") && GM.activeIFrames < 0)
        {
            GM.PlayerHP--;
            GM.activeIFrames = GM.playerIFrames;
            ControllAudio.Instance.EjecutarSound(audioDamage);
            ScreenShakeV2.Instance.ShakeCamera(scShakeIntensity, scShakeDuration);
        }
    }
    

 
}
