using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimic : MonoBehaviour
{
    public int score ;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
         if (CompareTag("tesoro1"))
        {
            int valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score += score; 
            }

            
        }
        else
        {
            valor<=4;
            score -= score;

        }
        
         if (CompareTag("tesoro2"))
        {
            int valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score += score; 
            }

            
        }
        else
        {
            valor<=4;
            score -= score;

        }
        
         if (CompareTag("tesoro3"))
        {
            int valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score += score; 
            }

            
        }
        else
        {
            valor<=4;
            score -= score;

        }
        
    }
}
