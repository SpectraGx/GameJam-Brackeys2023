using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    [SerializeField] GameController GM;

    [SerializeField] Transform BossSpawn;
    [SerializeField] Transform[] bossParts;

    [SerializeField] Boss boss;
    Animator animator;
    AudioSource monsterSource;
    [SerializeField] AudioClip monsterScream;
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
        if (other.gameObject.CompareTag("nave") && GM.KeysObtained >= GM.KeysAmount)
        {
            ChangeAnimationsState(M_Awakes);
            
        }
    }


    public void PlayAudio()
    {
        ControllAudio.Instance.EjecutarSound(monsterScream);
    }

    public void StartChase()
    {
        GM.isBossActive = true;
        monsterSource.Play();
    }

    public void RestartBoss()
    {
        ChangeAnimationsState(M_Sleep);
        monsterSource.Stop();
        boss.isColliding = false;
        for(int i = 0; i < bossParts.Length; i++)
        {
            bossParts[i].transform.position = BossSpawn.transform.position;
        }
    }
}
