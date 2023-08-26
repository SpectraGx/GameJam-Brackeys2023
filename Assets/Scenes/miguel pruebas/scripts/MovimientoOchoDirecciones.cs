using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoOchoDirecciones : MonoBehaviour
{
    Animator animator;
    public float velocidad = 5f; // Velocidad de movimiento
    public int score;

    private string currentState;

    //estados de animacion
    const string Player_Idel="FullHPPlayerIdle";
    const string Player_Horizontal="PlayerIdleDerecha";
    const string Player_1_hit="FirstHitPlayerAnim";
    const string Player_Idel2="2HPPlayerIdle";
    const string Player_1hit_Move="PLayerIdelDErechaDaño1";
    const string Player_2_hit="SecondHitPlayerAnim";
    const string Player_Idel3="LastHPPlayerIdle";
    const string Player_2hit_Move="playerIdelDerechadaño2";
       void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("FullHPPlayerIdle");
        score = 0;
    }

    void ChangeAnimationsState(string newState)
    {
        if(currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {

        if(Collision.gameObject.tag == "tesoro1")
        {
            score+= 1;
            Debug.Log(score);
        }
                if(Collision.gameObject.tag == "tesoro2")
        {
            score+= 2;
            Debug.Log(score);
        }
                if(Collision.gameObject.tag == "tesoro3")
        {
            score+= 3;
            Debug.Log(score);
        }

        if(Collision.gameObject.tag == "mimic1")
            {
                score-= 1;
                Debug.Log(score);
            }
                    if(Collision.gameObject.tag == "mimic2")
            {
                score-= 2;
                Debug.Log(score);
            }
                    if(Collision.gameObject.tag == "mimic3")
            {
                score-= 3;
                Debug.Log(score);
            }

    }

          
        

    void Update()
    {
        // Obtener la entrada del jugador (teclas de flecha o W,S,A,D)
        
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento en la dirección
        Vector3 desplazamiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f) * velocidad * Time.deltaTime;

        // Aplicar el desplazamiento al objeto
        transform.Translate(desplazamiento);

        if (movimientoHorizontal<0)
        {
            //desplazamiento = -velocidad;
           transform.localScale = new Vector3(-1f,1f,0f); 
           ChangeAnimationsState(Player_Horizontal);
        }
        else if (movimientoHorizontal>0)
        {
            //desplazamiento = velocidad;
            transform.localScale = new Vector3(1f,1f,0f);
            ChangeAnimationsState(Player_Horizontal);
        }
        else
        {
            //desplazamiento = 0f;
            ChangeAnimationsState(Player_Idel);
        }

    }
}