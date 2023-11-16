using UnityEngine;

public class DamageTiles : MonoBehaviour
{
    [SerializeField] GameController GM;

    [SerializeField] private AudioClip audioDamage;


     private void Awake() 
    {

    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            GM.PlayerHP--;
            ControllAudio.Instance.EjecutarSound(audioDamage);
            ScreenShakeV2.Instance.ShakeCamera(3f, 0.1f);
        }
    }
}
