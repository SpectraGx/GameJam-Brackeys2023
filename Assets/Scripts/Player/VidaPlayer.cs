using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    public GameController GM;

    Animator animator;
    private string currentState;

    // Anim States
    [SerializeField]const string Player_Idle = "FullHPPlayerIdle";
    [SerializeField]const string Player_Idle2 = "2HPPlayerIdle";
    [SerializeField]const string Player_Idle3 = "LastHPPlayerIdle";
    [SerializeField]const string Player_Death = "PlayerDeath";

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("FullHPPlayerIdle");
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
    

    void OnDeath()
    {
        SceneManager.LoadScene("Death"); 
        PlayerPrefs.SetFloat("Hi-Score", GM.gameScore);
    }
}
