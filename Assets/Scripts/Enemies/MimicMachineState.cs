using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class MimicMachineState : MonoBehaviour
{
    private enum State
    {
        Tesoro,
        Mimic
    }

    private State currentState;

    // ESTADOS DE ANIMACIÓN
    const string tesoro1 = "tesoro1";
    const string tesoro2 = "tesoro2";
    const string tesoro3 = "tesoro3";
    const string mimic1 = "mimic1";
    const string mimic2 = "mimic2";
    const string mimic3 = "mimic3";
    public int MChance;             // Probabilidad de Mimic
    public int TSize;               // Tipo de Mimic/Tesoro
    public float ScoreVar;
    public FloatVariable Score;

    public int MimicAllow;

    [SerializeField] private AudioClip audioTes;
    [SerializeField] private AudioClip audioMimic;

    // Implementacion de IAmimic
    [SerializeField] public Transform player;
    [SerializeField] private float dist;
    public Vector3 startingPoint;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        MimicChance();
        SetupStateMachine();
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        switch (currentState)
        {
            case State.Tesoro:
                {
                    switch (TSize)
                    {
                        case 0:
                            ScoreVar = 10;
                            ChangeAnimationsState(tesoro1);
                            break;

                        case 1:
                            ScoreVar = 20;
                            ChangeAnimationsState(tesoro2);
                            break;

                        case 2:
                            ScoreVar = 30;
                            ChangeAnimationsState(tesoro3);
                            break;

                        default:
                            ChangeAnimationsState(tesoro1);
                            ScoreVar = 10;
                            break;
                    }
                    break;
                }

            case State.Mimic:
                {
                    ScoreVar = Random.Range(0, -30);

                    switch (TSize)
                    {
                        case 0:
                            ChangeAnimationsState(mimic1);
                            break;

                        case 1:
                            ChangeAnimationsState(mimic2);
                            break;

                        case 2:
                            ChangeAnimationsState(mimic3);
                            break;

                        default:
                            ChangeAnimationsState(mimic1);
                            break;
                    }
                    break;
                }
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Tesoro:
                // Lógica para el tesoro 
                break;

            case State.Mimic:
                // Lógica para el mimic
                dist = Vector2.Distance(transform.position, player.position);
                animator.SetFloat("Distancia", dist);
                Girar(player.position);
                break;
        }
    }

    void ChangeAnimationsState(string newState)
    {
        if (currentState == State.Tesoro) return; // Evitar cambiar el estado si es un tesoro

        animator.Play(newState);
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "nave")
        {
            ScoreUpdate();

            if (currentState == State.Tesoro)
            {
                ControllAudio.Instance.EjecutarSound(audioTes);
            }
            else if (currentState == State.Mimic)
            {
                ControllAudio.Instance.EjecutarSound(audioMimic);
            }

            Destroy(gameObject);
        }
    }

    void ScoreUpdate()
    {
        Score.floatValue += ScoreVar;
    }

    void MimicChance()
    {
        if (MimicAllow <= 0 || MimicAllow >= 3) MimicAllow = 2;
        MChance = Random.Range(0, MimicAllow);
        TSize = Random.Range(0, 3);
        Debug.Log("tiro" + MChance + TSize);
    }

    void SetupStateMachine()
    {
        if (MChance == 0)
        {
            currentState = State.Tesoro;
        }
        else if (MChance == 1)
        {
            currentState = State.Mimic;
        }
    }

    void Girar(Vector3 objetivo)
    {
        if (transform.position.x < objetivo.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
