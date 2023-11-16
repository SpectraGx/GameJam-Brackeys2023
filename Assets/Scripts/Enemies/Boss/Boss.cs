using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss : MonoBehaviour
{
    public Transform pj; // Referencia al transform del jugador
    public float moveSpeed = 5f; // Velocidad de movimiento del enemigo

    [SerializeField] private AudioClip audioDamage;


    [SerializeField] float scShakeIntensity = 5f;
    [SerializeField] float scShakeDuration = 0.2f;

    public GameController GM;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            GM.PlayerHP--;
            GM.activeIFrames = GM.playerIFrames;
            ControllAudio.Instance.EjecutarSound(audioDamage);
            ScreenShakeV2.Instance.ShakeCamera(scShakeIntensity, scShakeDuration);
        }
    }

    private void Update()
    {
        MovePlayer();
        LookAtPlayer();
    }

    void MovePlayer()
    {
        if(GM.activeIFrames < 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, pj.position, Time.deltaTime * moveSpeed * GM.GameTime);
        }
        else
        {
            return;
        }
    }

    void LookAtPlayer()
    {
        Vector3 aimDir = (pj.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
