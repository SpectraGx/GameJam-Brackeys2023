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


    //          DIALOGO         //
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 5)] private string[] dialogueLines;

    private float typingTime = 0.05f;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;


    void Awake()
    {
        MimicChance();

    }
    void Start()
    {
        animator = GetComponent<Animator>();
        startingPoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch (MChance)
        {
            case 0:
                {
                    ScoreVar = 10;
                    ChangeAnimationsState(tesoro1);
                    break;
                }
            case 1:
                {
                    ScoreVar = Random.Range(0, -30);
                    // Cambia Anim a T Small
                    ChangeAnimationsState(mimic1);
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
                isPlayerInRange = true;
                dialogueMark.SetActive(true);
                Debug.Log("Se puede activar dialogo");
            }
        }

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
        Debug.Log("tiro" + MChance);
    }

    private void Update()
    {
        if (MChance == 0)
        {
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
            {

                if (!didDialogueStart)
                {
                    StartDialogue();
                }
                else if (dialogueText.text == dialogueLines[lineIndex])
                {
                    NextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[lineIndex];
                }
            }
        }



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


    //          METODOS DIALOGO         //
    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (MChance == 0)
        {
            if (other.gameObject.CompareTag("nave"))
            {
                isPlayerInRange = false;
                dialogueMark.SetActive(false);
                Debug.Log("No se puede activar dialogo");
            }
        }
    }

}


