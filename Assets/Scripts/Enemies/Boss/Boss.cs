using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Boss : MonoBehaviour
{
    public Transform pj; // Referencia al transform del jugador
    public float moveSpeed = 5f; // Velocidad de movimiento del enemigo

    [SerializeField] private AudioClip audioDamage;


    [SerializeField] float scShakeIntensity = 5f;
    [SerializeField] float scShakeDuration = 0.2f;

    [SerializeField] Transform[] parts;


    [SerializeField] public bool isColliding = false;

    public GameController GM;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave") && GM.isBossActive)
        {
            isColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave") && GM.isBossActive)
        {
            isColliding = false;
        }
    }


    private void Update()
    {
        if(GM.isBossActive)
        {
            MovePlayer();
            LookAtPlayer();
            if(parts != null)
            {
                MoveParts();
            }

            if(GM.activeIFrames < 0 && isColliding)
            {
                GM.PlayerHP--;
                GM.activeIFrames = GM.playerIFrames;
                ControllAudio.Instance.EjecutarSound(audioDamage);
                ScreenShakeV2.Instance.ShakeCamera(scShakeIntensity, scShakeDuration);
            }
        }

    }

    void MovePlayer()
    {
        if(GM.activeIFrames > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, pj.position, Time.deltaTime * (moveSpeed/2) * GM.GameTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pj.position, Time.deltaTime * moveSpeed * GM.GameTime);
        }
    }

    void LookAtPlayer()
    {
        Vector3 aimDir = (pj.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void MoveParts()
    {
        for(int i = 0; i < parts.Length; i++)
        {
            var part = parts[i];

            var dist = 0;


            if(i == 0)
            {
                dist = (int) Vector2.Distance((Vector2)part.position, (Vector2) transform.position);
            }
            else
            {
                dist = (int) Vector2.Distance((Vector2)part.position, (Vector2) parts[i - 1].position);
            }

             

            if(dist > 3f)
            {
                if(i == 0)
                {
                    part.position = Vector2.MoveTowards((Vector2) part.position, transform.position, Time.deltaTime * moveSpeed * GM.GameTime);

                    var partAngle = Mathf.Atan2(transform.position.y - part.position.y, transform.position.x - part.position.x ) * Mathf.Rad2Deg;
                    part.rotation = Quaternion.Euler(new Vector3(0, 0, partAngle));
                }

                else
                {
                    part.position = Vector2.MoveTowards((Vector2) part.position, parts[i - 1].position, Time.deltaTime * moveSpeed * GM.GameTime);

                    var partAngle = Mathf.Atan2(parts[i - 1].position.y - part.position.y, parts[i - 1].position.x - part.position.x ) * Mathf.Rad2Deg;
                    part.rotation = Quaternion.Euler(new Vector3(0, 0, partAngle));
                }




            }
;        }
    }

}
