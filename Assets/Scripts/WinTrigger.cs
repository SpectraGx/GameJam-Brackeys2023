using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] GameController GM;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave") && GM.isBossActive)
        {
            //Pon aqui el cambio de escena.
        }
    }
}
