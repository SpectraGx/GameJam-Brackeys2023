using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoOchoDirecciones : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    public int score;
       void Start()
    {
        score = 0;
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
    }
}