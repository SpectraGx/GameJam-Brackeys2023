using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mimic : MonoBehaviour
{
    public int score ;
     [SerializeField] int valor = 0 ;
    
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
         if (CompareTag("tesoro1"))
        {
            valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score += score; 
            }
            else if (valor <= 4)
            {
                score -= score;
            }

            
        }

        
         if (CompareTag("tesoro2"))
        {
            valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor >= 5)
            {
                score += score; 
            }   
            
            else if (valor <= 4)
            {
                score -= score;
            }
        }
        
         if (CompareTag("tesoro3"))
        {
            valor = Random.Range(0, 10); // Genera un numero aleatorio entre 1 y 10
            
            if (valor == 5)
            {
                score += score; 
            }
            else if (valor <= 4)
            {
                score -= score;
            }

            
        }

        
    }
}
