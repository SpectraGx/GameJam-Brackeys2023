using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] GameController GM;
    [SerializeField] GameObject musicSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave") && !GM.isBossActive)
        {
            musicSource.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        musicSource.gameObject.GetComponent<AudioSource>().Stop();
    }

    private void Update() {
        if (GM.isBossActive == true)
        {
            musicSource.gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}