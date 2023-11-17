using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] GameController GM;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave") && GM.isBossActive)
        {
            SceneManager.LoadScene("NewWinScene");
        }
    }
}
