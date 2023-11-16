using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    public GameController GM;
    SpriteRenderer spriteRenderer;
    Animator animator;
    private string currentState;

    // Anim States
    [SerializeField] const string Player_Idle = "PlayerFullHP";
    [SerializeField] const string Player_Idle2 = "Player2HP";
    [SerializeField] const string Player_Idle3 = "Player1HP";
    [SerializeField] const string Player_Death = "DeathPlayer";

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.Play("PlayerFullHP");
    }

    void Start()
    {
        StartCoroutine(PlayerFlash());
    }

    void ChangeAnimationsState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    void Update()
    {
        switch (GM.PlayerHP)
        {
            case 3:
                {
                    ChangeAnimationsState(Player_Idle);
                    break;
                }

            case 2:
                {
                    ChangeAnimationsState(Player_Idle2);
                    break;
                }

            case 1:
                {
                    ChangeAnimationsState(Player_Idle3);
                    break;
                }

            case 0:
                {
                    ChangeAnimationsState(Player_Death);
                    break;
                }
        }
    }

    public IEnumerator PlayerFlash()
    {
        while (true)
        {
            if(GM.activeIFrames > 0)
            {
                if (spriteRenderer.color != new Color(1, 1, 1, 1))
                {
                    spriteRenderer.color = new Color(1, 1, 1, 1);
                }
                else
                {
                    spriteRenderer.color = new Color(1, 1, 1, 0.5f);
                }
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }





            yield return new WaitForSeconds(0.1f);
        }
    }


    void OnDeath()
    {
        SceneManager.LoadScene("Death");
        PlayerPrefs.SetFloat("Hi-Score", GM.gameScore);
    }
}
