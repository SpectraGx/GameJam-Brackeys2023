using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class MimicMachineState : MonoBehaviour
{
    Animator animator;
    private string currentState;            // Estado Actual

    // ESTADOS DE ANIMACIÓN
    const string tesoro1 = "Tesoro";
    const string mimic1 = "Mimic";

    public int MChance;             // Probabilidad de Mimic

    //          CONTADOR DE MIMICS          //  
    public MimicCount mc;


    //          SCORE           //


    public int MimicAllow;

    [SerializeField] private AudioClip audioTes;
    [SerializeField] private AudioClip audioMimic;

    //          MAQUINA DE ESTADO           //
    [SerializeField] public Transform player;
    [SerializeField] private float dist;
    public Vector3 startingPoint;
    private SpriteRenderer spriteRenderer;

    //          GM          //
    [SerializeField] GameController GM;

    public BoxCollider2D BoxColl;


    void Awake()
    {
        MimicChance();

    }
    void Start()
    {
        animator = GetComponent<Animator>();
        startingPoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ColliderFirst();

        switch (MChance)
        {
            case 0:
                {
                    ChangeAnimationsState(tesoro1);
                    break;
                }
            case 1:
                {
                    ChangeAnimationsState(mimic1);
                    break;
                }

            default:
                {
                    ChangeAnimationsState(tesoro1);
                    break;
                }
        }
    }

    void ChangeAnimationsState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }


    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (MChance == 0)
        {
            if (Collision.gameObject.CompareTag("nave"))
            {
                GM.PartsCount++;
                GM.gameScore += 1000;
                ControllAudio.Instance.EjecutarSound(audioTes);
                Destroy(gameObject);
            }
        }


        if (MChance == 1)
        {
            if (Collision.gameObject.tag == "nave")
            {
                GM.PlayerHP--;
                GM.activeIFrames = GM.playerIFrames;
                ControllAudio.Instance.EjecutarSound(audioMimic);
                Destroy(gameObject);
            }
        }

    }

    void MimicChance()
    {
        /*if (MimicAllow <= 0 || MimicAllow >= 3) MimicAllow = 2;
        MChance = Random.Range(0, MimicAllow);
        Debug.Log("tiro" + MChance);*/

        if (mc.mimicCount<mc.mimicsAllowedinLevel){
            MChance=1;
            mc.mimicCount++;
        }
        else {
            MChance=0;
        }
    }

    private void Update()
    {
        if (MChance == 1)
        {
            dist = Vector2.Distance(transform.position, player.position);
            animator.SetFloat("Distancia", dist);
        }
    }


    public void Girar(Vector3 objetivo)
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

    public void Collider2()
    {
        BoxColl.size = new Vector2(1f, 1f);
        BoxColl.offset = new Vector2(0.0f, 0.5f);
    }

    public void ColliderFirst()
    {
        BoxColl.size = new Vector2(2.2f, 1.7f);
        BoxColl.offset = new Vector2(0.0f, -0.3f);
    }

}


