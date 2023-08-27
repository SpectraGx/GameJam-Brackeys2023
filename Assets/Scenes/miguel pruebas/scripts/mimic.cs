using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class mimic : MonoBehaviour
{
    Animator animator;
    private string currentState;

    const string tesoro1="tesoro1";
    const string tesoro2="tesoro2";
    const string tesoro3="tesoro3";
    const string mimic1="mimic1";
    const string mimic2="mimic2";
    const string mimic3="mimic3";
    public int MChance;
    public int TSize;
    public float ScoreVar;
    public FloatVariable Score;

    public int MimicAllow;

    private AudioSource audioSource;
    [SerializeField] private AudioClip audioTes;
    [SerializeField] private AudioClip audioMimic;

    void Awake()
    {
        MimicChance();
        audioSource = GetComponent<AudioSource>();
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
    }

     void ChangeAnimationsState(string newState)
    {
        if(currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {

        if(Collision.gameObject.tag == "nave")
        {
            ScoreUpdate();
            if (MChance==0)
            {
                ControllAudio.Instance.EjecutarSound(audioTes);
            }

            else if (MChance==1)
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
        if(MimicAllow <= 0 || MimicAllow >= 3) MimicAllow = 2; 
        MChance = Random.Range(0,MimicAllow);
        TSize = Random.Range(0,3);
        Debug.Log("tiro" + MChance + TSize);
    }
}


