using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimic : MonoBehaviour
{
    public MovimientoOchoDirecciones movimientoOchoDirecciones ;

    int valor;
    int score, score1;
    // Start is called before the first frame update
    void Start()
    {
        //int score = 0;

        //scriptA.SumarPuntos(puntosASumar);
    }

    // Update is called once per frame
    void Update()
    {
         if (CompareTag("tesoro1"))
        {
            valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score += score1; 
            }
            else if (valor <= 4)
            {
                score1 -= score1;
            }

            
        }

        
         if (CompareTag("tesoro2"))
        {
            valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score1 += score1; 
            }
            else if (valor <= 4)
            {
                score1 -= score1;

            }

        }

        
         if (CompareTag("tesoro3"))
        {
            valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score1 += score1; 
            }
            else if (valor <= 4)
            {
            score1 -= score1;
            }

            
        }

        
    }
}
