using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    [SerializeField] GameController GM;

    Animator animator;
    AudioSource monsterSource;
    private string currentState;

    //estados de animacion

    
    const string M_Sleep = "BossSleeps";
    const string M_Awakes = "BossAwakens";


    void ChangeAnimationsState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        monsterSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        animator.Play("BaitBoss");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nave"))
        {
            ChangeAnimationsState(M_Awakes);
            
        }
    }


    public void PlayAudio()
    {
        monsterSource?.Play();
    }

    public void StartChase()
    {
        GM.isBossActive = true;
    }

    public void RestartBoss()
    {
        
    }
}
