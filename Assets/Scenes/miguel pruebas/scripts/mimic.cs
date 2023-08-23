using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimic : MonoBehaviour
{
    public MovimientoOchoDirecciones movimientoOchoDirecciones ;
    // Start is called before the first frame update
    void Start()
    {
        int score = score1
        scriptA.SumarPuntos(puntosASumar);
    }

    // Update is called once per frame
    void Update()
    {
         if (CompareTag("tesoro1"))
        {
            int valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score1 += score1; 
            }

            
        }
        else
        {
            valor<=4;
            score1 -= score1;

        }
        
         if (CompareTag("tesoro2"))
        {
            int valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score1 += score1; 
            }

            
        }
        else
        {
            valor<=4;
            score1 -= score1;

        }
        
         if (CompareTag("tesoro3"))
        {
            int valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score1 += score1; 
            }

            
        }
        else
        {
            valor<=4;
            score1 -= score1;

        }
        
    }
}
