using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class mimic : MonoBehaviour
{
    /*
    private enum State{
        Tesoro,
        Mimic
    }

    private State currentState;
    */

    Animator animator;
    private string currentState;            // Estado Actual

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

    // Implementacion Maquina de estado Mimic
    [SerializeField] public Transform player;
    [SerializeField] private float dist;
    public Vector3 startingPoint;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        MimicChance();
        //SetupStateMachine();

    }
    void Start()
    {
        animator = GetComponent<Animator>();

        
        switch (MChance)
        {
            case 0:
                {
                    switch (TSize)
                    {
                        case 0:
                            {
                                //Pequeño asi que suma 10 puntos;
                                ScoreVar = 10;
                                // Cambia Anim a T Small
                                ChangeAnimationsState(tesoro1);

                                break;
                            }

                        case 1:
                            {
                                //Pequeño asi que suma 20 puntos;
                                ScoreVar = 20;
                                // Cambia Anim a T Med
                                ChangeAnimationsState(tesoro2);

                                break;
                            }

                        case 2:
                            {
                                //Grande asi que suma 30 puntos;
                                ScoreVar = 30;
                                // Cambia Anim a T Big
                                ChangeAnimationsState(tesoro3);

                                break;
                            }


                        default:

                            ChangeAnimationsState(tesoro1);
                            ScoreVar = 10;

                            break;
                    }

                    break;
                }
            case 1:
                {
                    //Aqui es un mimic
                    ScoreVar = Random.Range(0, -30);
                    switch (TSize)
                    {
                        case 0:

                            // Cambia Anim a T Small
                            ChangeAnimationsState(mimic1);

                            break;

                        case 1:

                            // Cambia Anim a T Med
                            ChangeAnimationsState(mimic2);

                            break;

                        case 2:

                            // Cambia Anim a T Big
                            ChangeAnimationsState(mimic3);

                            break;


                        default:

                            ChangeAnimationsState(mimic1);

                            break;

                    }



                    break;
                }

            default:
                {
                    ChangeAnimationsState(tesoro1);
                    ScoreVar = 10;
                    break;
                }


        }

        /*
        switch (currentState)
        {
            case State.Tesoro:
                {
                    switch (TSize)
                    {
                        // Configuraciones para el tesoro
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
                    // Configuraciones para el mimic
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
        */

    }

    /*
    void Update(){
        switch (currentState)
        {
            case State.Tesoro:
                // Lógica específica para el estado de tesoro (si es necesario)
                break;

            case State.Mimic:
                // Lógica específica para el estado de mimic
                dist = Vector2.Distance(transform.position, player.position);
                animator.SetFloat("Distancia", dist);
                Girar(player.position);
                break;
        }
    }
    */

    void ChangeAnimationsState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;  // Quitar al implemntar la maquina
    }


    private void OnTriggerEnter2D(Collider2D Collision)
    {

        if (Collision.gameObject.tag == "nave")
        {
            ScoreUpdate();
            
            if (MChance == 0)
            {
                ControllAudio.Instance.EjecutarSound(audioTes);
            }

            else if (MChance == 1)
            {
                ControllAudio.Instance.EjecutarSound(audioMimic);
            }

            /*
            if (currentState == State.Tesoro)
            {
                ControllAudio.Instance.EjecutarSound(audioTes);
            }
            else if (currentState == State.Mimic)
            {
                ControllAudio.Instance.EjecutarSound(audioMimic);
            }
            */

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

    /*
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
    */
}


