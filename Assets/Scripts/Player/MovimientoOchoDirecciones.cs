using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoOchoDirecciones : MonoBehaviour
{
    public FloatVariable HP;
    public FloatVariable Score;
    Animator animator;
    public float velocidad = 5f; // Velocidad de movimiento

    [SerializeField] InputSystem inputSystem;
    Rigidbody2D rb;

    private string currentState;

    // Estados de animación
    const string Player_Idel = "FullHPPlayerIdle";
    const string Player_Horizontal = "PlayerIdleDerecha";
    const string Player_Idel2 = "2HPPlayerIdle";
    const string Player_1hit_Move = "PLayerIdelDErechaDaño1";
    const string Player_Idel3 = "LastHPPlayerIdle";
    const string Player_2hit_Move = "playerIdelDerechadaño2";
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
        // Obtener la entrada del jugador (teclas de flecha o W,S,A,D)
        //inputSystem.xMove = Input.GetAxis("Horizontal");
        //inputSystem.yMove = Input.GetAxis("Vertical");

        //rb.velocity = new Vector2(inputSystem.xMove * velocidad, inputSystem.yMove * velocidad);

        // Calcular el desplazamiento en la dirección
        //Vector3 desplazamiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f) * velocidad * Time.deltaTime;

        // Aplicar el desplazamiento al objeto
        //transform.Translate(desplazamiento);

        switch (HP.floatValue)
        {
            case 3:
                {
                    if (inputSystem.xMove < 0)
                    {
                        transform.localScale = new Vector3(-1f, 1f, 0f);
                        ChangeAnimationsState(Player_Horizontal);
                    }
                    else if (inputSystem.xMove > 0)
                    {
                        transform.localScale = new Vector3(1f, 1f, 0f);
                        ChangeAnimationsState(Player_Horizontal);
                    }
                    else
                    {
                        ChangeAnimationsState(Player_Idel);
                    }
                    break;
                }

            case 2:
                {
                    if (inputSystem.xMove < 0)
                    {
                        transform.localScale = new Vector3(-1f, 1f, 0f);
                        ChangeAnimationsState(Player_1hit_Move);
                    }
                    else if (inputSystem.xMove > 0)
                    {
                        transform.localScale = new Vector3(1f, 1f, 0f);
                        ChangeAnimationsState(Player_1hit_Move);
                    }
                    else
                    {
                        ChangeAnimationsState(Player_Idel2);
                    }
                    break;
                }

            case 1:
                {
                    if (inputSystem.xMove < 0)
                    {
                        transform.localScale = new Vector3(-1f, 1f, 0f);
                        ChangeAnimationsState(Player_2hit_Move);
                    }
                    else if (inputSystem.xMove > 0)
                    {
                        transform.localScale = new Vector3(1f, 1f, 0f);
                        ChangeAnimationsState(Player_2hit_Move);
                    }
                    else
                    {
                        ChangeAnimationsState(Player_Idel3);
                    }
                    break;
                }

            case 0:
                {
                    ChangeAnimationsState(Player_Death);
                    break;
                }
        }
    }

    void Inputs()
    {
        inputSystem.xMove = Input.GetAxis("Horizontal");
        inputSystem.yMove = Input.GetAxis("Vertical");

        /*
        if(Input.GetKey(KeyCode.A))
        {
            inputSystem.moveR = true;
        }
        else
        {

        inputSystem.moveR = false;
        }

        if(Input.GetKey(KeyCode.D))
        {
            inputSystem.moveL = true;
        }
        else
        {
        inputSystem.moveL = false;
        }

        if(Input.GetKey(KeyCode.S))
        {
            inputSystem.moveD = true;
        }
        else
        {
        inputSystem.moveD = false;
        }

        if(Input.GetKey(KeyCode.W))
        {
            inputSystem.moveU = true;
        }
        else
        {
        inputSystem.moveU = false;
        }
        */

        inputSystem.moveR = Input.GetKey(KeyCode.A);
        inputSystem.moveL = Input.GetKey(KeyCode.D);
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
