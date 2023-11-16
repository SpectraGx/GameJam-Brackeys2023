using UnityEngine;

public class TangleTiles : MonoBehaviour
{
    [SerializeField] GameController GM;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            GM.currentSpeed = 3f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            GM.currentSpeed = GM.maxSpeed;
        }
    }
}
