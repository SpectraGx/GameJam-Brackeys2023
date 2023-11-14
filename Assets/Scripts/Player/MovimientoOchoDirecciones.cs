using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoOchoDirecciones : MonoBehaviour
{
    public FloatVariable HP;
    public FloatVariable Score;
    Animator animator;
    public float velocidad = 5f;

    [SerializeField] InputSystem inputSystem;
    Rigidbody2D rb;

    private string currentState;

    // Anim States
    const string Player_Idle = "FullHPPlayerIdle";
    const string Player_Idle2 = "2HPPlayerIdle";
    const string Player_Idle3 = "LastHPPlayerIdle";
    const string Player_Death = "PlayerDeath";

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.Play("FullHPPlayerIdle");
        Score.floatValue = 0;
    }

    void ChangeAnimationsState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    void Update()
    {
        Inputs();
        

        switch (HP.floatValue)
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
                    OnDeath();
                    ChangeAnimationsState(Player_Death);
                    break;
                }
        }
    }

    void Inputs()
    {
        inputSystem.xMove = Input.GetAxis("Horizontal");
        inputSystem.yMove = Input.GetAxis("Vertical");

 
        inputSystem.moveL = Input.GetKey(KeyCode.A);
        inputSystem.moveR = Input.GetKey(KeyCode.D);
        inputSystem.moveD = Input.GetKey(KeyCode.S);
        inputSystem.moveU = Input.GetKey(KeyCode.W);

        rb.velocity = new Vector2(inputSystem.xMove * velocidad, inputSystem.yMove * velocidad);
    }

    void OnDeath()
    {
        SceneManager.LoadScene("Death"); 
        PlayerPrefs.SetFloat("Hi-Score", Score.floatValue);
    }
}


