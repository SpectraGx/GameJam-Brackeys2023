using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoOchoDirecciones : MonoBehaviour
{
    public FloatVariable HP;
    public FloatVariable Score;
    Animator animator;
    public float velocidad = 5f; // Velocidad de movimiento


    private string currentState;

    //estados de animacion
    const string Player_Idel = "FullHPPlayerIdle";
    const string Player_Horizontal = "PlayerIdleDerecha";
    const string Player_1_hit = "FirstHitPlayerAnim";
    const string Player_Idel2 = "2HPPlayerIdle";
    const string Player_1hit_Move = "PLayerIdelDErechaDaño1";
    const string Player_2_hit = "SecondHitPlayerAnim";
    const string Player_Idel3 = "LastHPPlayerIdle";
    const string Player_2hit_Move = "playerIdelDerechadaño2";
    void Start()
    {
        animator = GetComponent<Animator>();
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
        // Obtener la entrada del jugador (teclas de flecha o W,S,A,D)

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento en la dirección
        Vector3 desplazamiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f) * velocidad * Time.deltaTime;

        // Aplicar el desplazamiento al objeto
        transform.Translate(desplazamiento);

        switch (HP.floatValue)
        {
            case 3:
                {

                    if (movimientoHorizontal < 0)
                    {

                        transform.localScale = new Vector3(-1f, 1f, 0f);
                        ChangeAnimationsState(Player_Horizontal);
                    }
                    else if (movimientoHorizontal > 0)
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
                    if (movimientoHorizontal < 0)
                    {

                        transform.localScale = new Vector3(-1f, 1f, 0f);
                        ChangeAnimationsState(Player_1hit_Move);
                    }
                    else if (movimientoHorizontal > 0)
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
                  if (movimientoHorizontal < 0)
                    {

                        transform.localScale = new Vector3(-1f, 1f, 0f);
                        ChangeAnimationsState(Player_2hit_Move);
                    }
                    else if (movimientoHorizontal > 0)
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


        }

    }
}