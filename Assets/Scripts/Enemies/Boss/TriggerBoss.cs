using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    [SerializeField] GameController GM;

    [SerializeField] Transform BossSpawn;
    [SerializeField] Transform[] bossParts;
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
        animator.Play("BossSleeps");
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
        for(int i = 0; i < bossParts.Length; i++)
        {
            bossParts[i].transform.position = BossSpawn.transform.position;
        }
    }
}
